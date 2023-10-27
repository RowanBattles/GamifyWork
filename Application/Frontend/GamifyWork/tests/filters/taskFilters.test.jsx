import { test, expect, describe } from "vitest";
import {
  filterTasksByRecurring,
  filterTasksByStatus,
  filterTasksByTitle,
} from "../../src/utils/Filters/taskFilters";

describe("filterTasksByRecurring", () => {
  const tasks = [
    { id: 1, recurring: true },
    { id: 2, recurring: false },
    { id: 3, recurring: true },
    { id: 4, recurring: false },
  ];

  test("should return filters tasks correctly", () => {
    const recurringTasks = filterTasksByRecurring(tasks, true);
    const nonRecurringTasks = filterTasksByRecurring(tasks, false);

    expect(recurringTasks).toEqual([
      { id: 1, recurring: true },
      { id: 3, recurring: true },
    ]);

    expect(nonRecurringTasks).toEqual([
      { id: 2, recurring: false },
      { id: 4, recurring: false },
    ]);
  });

  test("should return null when tasks are null", () => {
    const recurringTasks = filterTasksByRecurring(null, true);
    const nonRecurringTasks = filterTasksByRecurring(null, false);

    expect(recurringTasks).toBe(null);
    expect(nonRecurringTasks).toBe(null);
  });
});

describe("filterTasksByStatus", () => {
  const tasks = [
    { id: 1, title: "Task 1", completed: true },
    { id: 2, title: "Task 2", completed: false },
    { id: 3, title: "Task 3", completed: true },
    { id: 4, title: "Task 4", completed: false },
  ];

  test("should return completed tasks", () => {
    const completedTasks = filterTasksByStatus(tasks, "Completed");
    expect(completedTasks).toHaveLength(2);
    expect(completedTasks.every((task) => task.completed === true)).toBe(true);
  });

  test("should return active tasks", () => {
    const activeTasks = filterTasksByStatus(tasks, "Active");
    expect(activeTasks).toHaveLength(2);
    expect(activeTasks.every((task) => task.completed === false)).toBe(true);
  });

  test("should return null when tasks are null", () => {
    const activeTasks = filterTasksByStatus(null, "Active");
    const completedTasks = filterTasksByStatus(null, "Completed");

    expect(activeTasks).toBe(null);
    expect(completedTasks).toBe(null);
  });
});

describe("filterTasksByTitle", () => {
  const tasks = [
    { id: 1, title: "Task 1" },
    { id: 2, title: "Task 2" },
    { id: 3, title: "Another Task" },
  ];

  test("should return an empty array if no tasks match the query", () => {
    const result = filterTasksByTitle(tasks, "Nonexistent Task");
    expect(result).toEqual([]);
  });

  test("should return tasks that include the query (case insensitive)", () => {
    const result = filterTasksByTitle(tasks, "task");
    expect(result).toEqual([
      { id: 1, title: "Task 1" },
      { id: 2, title: "Task 2" },
      { id: 3, title: "Another Task" },
    ]);
  });

  test("should return all tasks if query is an empty string", () => {
    const result = filterTasksByTitle(tasks, "");
    expect(result).toEqual(tasks);
  });

  test("should handle special characters in the query", () => {
    const result = filterTasksByTitle(tasks, "Anoth");
    expect(result).toEqual([{ id: 3, title: "Another Task" }]);
  });

  test("should return null when tasks are null", () => {
    const result = filterTasksByTitle(null, "");
    expect(result).toBe(null);
  });
});
