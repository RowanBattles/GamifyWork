import React from "react";

function TaskTable({ tasks, setTasks }) {
  function renderTaskTable() {
    return (
      <>
        <table className="w-full h-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3">
                TaskID
              </th>
              <th scope="col" className="px-6 py-3">
                Title
              </th>
              <th scope="col" className="px-6 py-3">
                Description
              </th>
              <th scope="col" className="px-6 py-3">
                Points
              </th>
              <th scope="col" className="px-6 py-3">
                Completed
              </th>
              <th scope="col" className="px-6 py-3">
                Recurring
              </th>
              <th scope="col" className="px-6 py-3">
                RecurrenceType
              </th>
              <th scope="col" className="px-6 py-3">
                RecurrenceInterval
              </th>
              <th scope="col" className="px-6 py-3">
                NextDueDate
              </th>
              <th scope="col" className="px-6 py-3">
                UserID
              </th>
            </tr>
          </thead>
          <tbody>
            {tasks.map((task) => (
              <tr
                className="bg-white border-b dark:bg-gray-800 dark:border-gray-700"
                key={task.task_ID}
              >
                <th
                  scope="row"
                  className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white"
                >
                  {task.task_ID}
                </th>
                <td className="px-6 py-4">{task.title}</td>
                <td className="px-6 py-4">{task.description}</td>
                <td className="px-6 py-4">{task.points}</td>
                <td className="px-6 py-4">{task.completed ? "Yes" : "No"}</td>
                <td className="px-6 py-4">{task.recurring ? "Yes" : "No"}</td>
                <td
                  className={`px-6 py-4 ${task.recurrenceType ? "" : "italic"}`}
                >
                  {task.recurrenceType ?? "NULL"}
                </td>
                <td
                  className={`px-6 py-4 ${
                    task.recurrenceInterval ? "" : "italic"
                  }`}
                >
                  {task.recurrenceInterval ?? "NULL"}
                </td>
                <td className="px-6 py-4">{task.nextDueDate}</td>
                <td className="px-6 py-4">{task.user_ID}</td>
              </tr>
            ))}
          </tbody>
        </table>

        <button
          onClick={() => setTasks([])}
          className="bg-white hover:bg-gray-100 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow"
        >
          Empty tasks
        </button>
      </>
    );
  }

  return renderTaskTable();
}

export default TaskTable;