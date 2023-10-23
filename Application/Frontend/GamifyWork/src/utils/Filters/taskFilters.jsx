export function filterTasksByRecurring(tasks, isRecurring) {
  return tasks.filter((task) => task.recurring === isRecurring);
}

export function filterTasksByStatus(tasks, status) {
  return tasks.filter((task) => {
    if (status === "All") {
      return true;
    } else if (status === "Active") {
      return !task.completed;
    } else if (status === "Completed") {
      return task.completed;
    }
    return true;
  });
}
