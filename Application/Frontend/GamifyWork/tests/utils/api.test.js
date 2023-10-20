import { test, expect, describe, vi } from "vitest";
import getTasks from "../../src/utils/api";
import axios from "axios";

vi.mock("axios");

describe("getTasks", () => {
  test("should return an array of tasks", async () => {
    const mockData = [
      { id: 1, title: "Task 1" },
      { id: 2, title: "Task 2" },
    ];
    axios.get.mockResolvedValue({ data: mockData });

    const tasks = await getTasks();
    expect(tasks).toEqual(mockData);
  });

  test("getTasks handles errors", async () => {
    const errorMessage = "An error occurred";
    axios.get.mockRejectedValue(new Error(errorMessage));

    try {
      await getTasks();
    } catch (error) {
      expect(error.message).toEqual(errorMessage);
    }
  });
});
