export function filterTasksByRecurring(tasks, isRecurring) {
  if (tasks === null) {
    return null;
  }
  return tasks.filter((task) => task.recurring === isRecurring);
}

export function filterTasksByStatus(tasks, status) {
  if (tasks === null) {
    return null;
  }
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

export function filterTasksByTitle(tasks, query) {
  if (tasks === null) {
    return null;
  }
  const lowerCaseQuery = query.toLowerCase();
  return tasks.filter((task) =>
    task.title.toLowerCase().includes(lowerCaseQuery)
  );
}
