import { render, screen } from "@testing-library/react";
import HomePage from "../../src/pages/HomePage";
import { vi } from "vitest";
import useFetch from "../../src/hooks/useFetch";
import { useTaskContext } from "../../src/hooks/TaskContext";

vi.mock("@react-keycloak/web", () => ({
  ...vi.importActual("@react-keycloak/web"),
  useKeycloak: () => ({
    keycloak: {
      subject: "dummysubject",
      tokenParsed: { preferred_username: "dummyname" },
    },
  }),
}));
vi.mock("../../src/hooks/TaskContext");
vi.mock("../../src/hooks/useFetch");

useTaskContext.mockReturnValue({
  tasks: [],
});

it("renders loading state", async () => {
  useFetch.mockReturnValue({
    data: null,
    loading: true,
    errorHeader: null,
    errorBody: null,
  });

  render(<HomePage />);

  const loadingIndicator = screen.getByAltText("LogoLoading");
  expect(loadingIndicator).toBeInTheDocument();
});

it("renders error state", async () => {
  useFetch.mockReturnValue({
    data: null,
    loading: false,
    errorHeader: "error",
    errorBody: "error",
  });

  render(<HomePage />);

  const errorDisplay = screen.getByTestId("ErrorDisplayId");
  expect(errorDisplay).toBeInTheDocument();
});

it("renders tasks and rewards", async () => {
  useFetch.mockReturnValue({
    data: [],
    loading: false,
    errorHeader: null,
    errorBody: null,
  });

  console.log(screen.debug());

  render(<HomePage />);

  const TodoTasks = screen.getByTestId("TaskTable-Recurring");
  expect(TodoTasks).toBeInTheDocument();
  const RecurringTasks = screen.getByTestId("TaskTable-To do");
  expect(RecurringTasks).toBeInTheDocument();
  const Rewards = screen.getByTestId("RewardTable");
  expect(Rewards).toBeInTheDocument();
});
