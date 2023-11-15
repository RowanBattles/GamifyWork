import { render, screen, fireEvent } from "@testing-library/react";
import TaskTable from "../../src/components/TaskTable";
import { CreateTask } from "../../src/utils/api";

describe("renderingTaskTable", () => {
  test("renders TaskTable component", () => {
    const tasks = [
      {
        task_ID: 1,
        title: "Task 1",
        description: "Description 1",
        completed: false,
      },
      {
        task_ID: 2,
        title: "Task 2",
        description: "Description 2",
        completed: true,
      },
    ];

    render(<TaskTable tasks={tasks} title="Test Title" />);

    // Check if the title is rendered
    const titleElement = screen.getByText("Test Title");
    expect(titleElement).toBeInTheDocument();

    // Check if the All, Active, Completed filters are rendered
    const allFilter = screen.getByText("All");
    const activeFilter = screen.getByText("Active");
    const completedFilter = screen.getByText("Completed");
    expect(allFilter).toBeInTheDocument();
    expect(activeFilter).toBeInTheDocument();
    expect(completedFilter).toBeInTheDocument();

    // Check if tasks are rendered
    const task1Element = screen.getByText("Task 1");
    const task2Element = screen.getByText("Task 2");
    expect(task1Element).toBeInTheDocument();
    expect(task2Element).toBeInTheDocument();
  });

  test("filters tasks by status", () => {
    const tasks = [
      {
        task_ID: 1,
        title: "Task 1",
        description: "Description 1",
        completed: false,
      },
      {
        task_ID: 2,
        title: "Task 2",
        description: "Description 2",
        completed: true,
      },
    ];

    render(<TaskTable tasks={tasks} title="Test Title" />);

    // Click on the Active filter
    const activeFilter = screen.getByText("Active");
    fireEvent.click(activeFilter);

    // Check if only the active task is rendered
    const task1Element = screen.getByText("Task 1");
    const task2Element = screen.queryByText("Task 2");
    expect(task1Element).toBeInTheDocument();
    expect(task2Element).toBeNull();
  });
});

describe("addingTask", () => {
  vi.mock("../../src/utils/api", () => ({
    CreateTask: vi.fn(),
  }));

  test("handleInputChange updates newTask state correctly", () => {
    const { getByPlaceholderText } = render(
      <TaskTable tasks={[]} title="Recurring" />
    );
    const inputElement = getByPlaceholderText("Add task");

    fireEvent.change(inputElement, { target: { value: "New Task" } });

    expect(inputElement.value).toBe("New Task");
  });

  test("handleKeyDown function works correctly", async () => {
    CreateTask.mockResolvedValueOnce({});

    render(<TaskTable tasks={[]} title="Recurring" />);

    const textarea = screen.getByPlaceholderText("Add task");
    fireEvent.change(textarea, { target: { value: "New Task" } });
    fireEvent.keyDown(textarea, { key: "Enter", code: "Enter" });

    expect(CreateTask).toHaveBeenCalledWith({
      title: "New Task",
      description: null,
      points: 0,
      completed: false,
      recurring: true,
      recurrenceType: null,
      recurrenceInterval: null,
      nextDueDate: null,
      user_ID: 1,
    });
  });
});
