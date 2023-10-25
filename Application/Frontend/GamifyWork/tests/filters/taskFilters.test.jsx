import { test, expect, describe } from "vitest";
import {
  filterTasksByRecurring,
  filterTasksByStatus,
} from "../../src/utils/Filters/taskFilters";

describe("filterTasksByRecurring", () => {
  const tasks = [
    { id: 1, recurring: true },
    { id: 2, recurring: false },
    { id: 3, recurring: true },
    { id: 4, recurring: false },
  ];

  test("filterTasksByRecurring filters tasks correctly", () => {
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
});
