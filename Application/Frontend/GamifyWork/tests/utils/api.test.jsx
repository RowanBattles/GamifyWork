import { getTasksByUser, CreateTask, getRewards } from "../../src/utils/api";
import axios from "axios";

vi.mock("axios");

describe("getTasks", () => {
  test("should return an array of tasks", async () => {
    const mockData = [
      { id: 1, title: "Task 1" },
      { id: 2, title: "Task 2" },
    ];
    axios.get.mockResolvedValue({ data: mockData });

    const tasks = await getTasksByUser(1);
    expect(tasks).toEqual(mockData);
  });

  test("getTasks handles errors", async () => {
    const errorMessage = "An error occurred";
    axios.get.mockRejectedValue(new Error(errorMessage));

    try {
      await getTasksByUser(1);
    } catch (error) {
      expect(error.message).toEqual(errorMessage);
    }
  });
});

describe("CreateTask", () => {
  test("should create a new task", async () => {
    const taskData = {
      title: "New Task",
      description: null,
      points: 0,
      completed: false,
      recurring: false,
      recurrenceType: null,
      recurrenceInterval: null,
      nextDueDate: null,
      user_ID: 1,
    };

    const responseData = { id: 1, ...taskData };

    axios.post.mockResolvedValueOnce({ data: responseData });

    const createdTask = await CreateTask(taskData);

    expect(createdTask).toEqual(responseData);
    expect(axios.post).toHaveBeenCalledWith(expect.any(String), taskData);
  });

  test("should throw an error if request fails", async () => {
    const taskData = {
      title: "New Task",
      description: null,
      points: 0,
      completed: false,
      recurring: false,
      recurrenceType: null,
      recurrenceInterval: null,
      nextDueDate: null,
      user_ID: 1,
    };

    const errorMessage = "Failed to create task";

    axios.post.mockRejectedValueOnce(new Error(errorMessage));

    try {
      await CreateTask(taskData);
    } catch (error) {
      expect(error.message).toBe(errorMessage);
    }

    expect(axios.post).toHaveBeenCalledWith(expect.any(String), taskData);
  });
});

describe("getRewards", () => {
  test("should return an array of rewards", async () => {
    const mockData = [
      { id: 1, title: "Reward 1" },
      { id: 2, title: "Reward 2" },
    ];
    axios.get.mockResolvedValue({ data: mockData });

    const rewards = await getRewards();
    expect(rewards).toEqual(mockData);
  });

  test("getRewards handles errors", async () => {
    const errorMessage = "An error occurred";
    axios.get.mockRejectedValue(new Error(errorMessage));

    try {
      await getRewards();
    } catch (error) {
      expect(error.message).toEqual(errorMessage);
    }
  });
});
