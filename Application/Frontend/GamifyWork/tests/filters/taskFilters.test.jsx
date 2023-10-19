import { test, expect } from "vitest";
import { filterTasksByRecurring } from "../../src/utils/filters/taskFilters";

test("filterTasksByRecurring filters tasks correctly", () => {
  const tasks = [
    { id: 1, recurring: true },
    { id: 2, recurring: false },
    { id: 3, recurring: true },
    { id: 4, recurring: false },
  ];

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
