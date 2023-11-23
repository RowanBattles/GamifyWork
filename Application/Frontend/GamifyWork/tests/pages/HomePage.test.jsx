import { render, screen } from "@testing-library/react";
import HomePage from "../../src/pages/HomePage";

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
    errorHeader: "Unexpected error",
    errorBody: `Couldn't fetch tasks`,
  });

  mocks.useFetch.mockReturnValueOnce({
    data: null,
    loading: false,
    errorHeader: "Unexpected error",
    errorBody: `Couldn't fetch rewards`,
  });

  render(<HomePage />);
  const errorElements = await screen.findAllByText(/Couldn't fetch/);
  expect(errorElements.length).toBe(2);
});

it("renders tasks and rewards", async () => {
  mocks.useFetch.mockReturnValue({
    data: [
      { id: 1, title: "Reward 1" },
      { id: 2, title: "Reward 2" },
    ],
    loading: false,
    errorHeader: null,
    errorBody: null,
  });

  render(<HomePage />);

  // Assert on rewards
  const rewardElement = await screen.getByText("Reward 1");
  const rewardElement2 = await screen.getByText("Reward 2");
  const RecurringTasks = await screen.getByText("To do");
  const TodoTasks = await screen.getByText("Recurring");
  expect(rewardElement).toBeInTheDocument();
  expect(rewardElement2).toBeInTheDocument();
});
