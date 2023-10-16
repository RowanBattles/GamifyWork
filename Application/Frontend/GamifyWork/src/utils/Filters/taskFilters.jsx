export function filterTasksByRecurring(tasks, isRecurring) {
  return tasks.filter((task) => task.recurring === isRecurring);
}
