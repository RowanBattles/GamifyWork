import { render, screen } from "@testing-library/react";
import HomePage from "../../src/pages/HomePage";

it("renders error state", async () => {
  vi.mock("./useFetch", () => ({
    useFetch: vi.fn().mockReturnValue({
      data: [],
      loading: false,
      errorHeader: "Error occured",
      errorBody: "Error occured",
    }),
  }));

  vi.mock("./useTaskContext", () => ({
    useTaskContext: vi.fn().mockReturnValue({
      tasks: [],
    }),
  }));

  render(<HomePage />);
  const errorElements = await screen.findAllByText(/Couldn't fetch/);
  expect(errorElements.length).toBe(1);
});

it("renders tasks and rewards", async () => {
  mocks.useFetch.mockReturnValueOnce({
    data: { tasks: [] },
    loading: false,
    errorHeader: null,
    errorBody: null,
  });

  mocks.useTaskContext.mockReturnValue({
    tasks: [],
    updateTasks: vi.fn(),
  });

  render(<HomePage />);

  // Assert on rewards
  const rewardElement = await screen.getByText("Reward 1");
  const rewardElement2 = await screen.getByText("Reward 2");
  const RecurringTasks = await screen.getByText("To do");
  const TodoTasks = await screen.getByText("Recurring");
  expect(rewardElement).toBeInTheDocument();
  expect(rewardElement2).toBeInTheDocument();
  expect(RecurringTasks).toBeInTheDocument();
  expect(TodoTasks).toBeInTheDocument();
});
