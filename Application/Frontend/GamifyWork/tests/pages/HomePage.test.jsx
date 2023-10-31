import { render, screen } from "@testing-library/react";
import HomePage from "../../src/pages/HomePage";
import { vi } from "vitest";

const mocks = vi.hoisted(() => {
  return {
    useFetch: vi.fn(),
  };
});

vi.mock("../../src/hooks/useFetch.jsx", () => {
  return {
    default: mocks.useFetch,
  };
});

it("renders loading state", async () => {
  mocks.useFetch.mockReturnValue({
    data: null,
    loading: true,
    error: null,
  });

  render(<HomePage />);
  const loadingElement = await screen.findByAltText("LogoLoading");
  expect(loadingElement).toBeInTheDocument();
});

it("renders error state", async () => {
  mocks.useFetch.mockReturnValueOnce({
    data: null,
    loading: false,
    error: "Error: Couldn't fetch tasks",
  });

  mocks.useFetch.mockReturnValueOnce({
    data: null,
    loading: false,
    error: "Error: Couldn't fetch rewards",
  });

  render(<HomePage />);
  const errorElements = await screen.findAllByText(/Error: Couldn't fetch/);
  expect(errorElements.length).toBe(2);
});

it("renders tasks", async () => {
  mocks.useFetch.mockReturnValue({
    data: [
      { id: 1, title: "Task 1" },
      { id: 2, title: "Task 2" },
    ],
    loading: false,
    error: null,
  });

  render(<HomePage />);
  const taskElement = await screen.getByText("Task 1");
  const taskElement2 = await screen.getByText("Task 2");
  expect(taskElement).toBeInTheDocument();
  expect(taskElement2).toBeInTheDocument();
});
