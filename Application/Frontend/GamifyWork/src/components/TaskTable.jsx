import React from "react";

function TaskTable({ tasks, title }) {
  if (tasks === null) {
    return null;
  }

  return (
    <div className="px-4 pt-5 min-h-[556px]">
      <div className="flex justify-between items-center">
        <div className="text-lg font-bold">{title}</div>
        <div className="text-sm flex gap-2">
          <div>All</div>
          <div>Active</div>
          <div>Completed</div>
        </div>
      </div>
      <div className="p-2 bg-neutral-100 h-full">
        <textarea
          className="text-sm resize-none h-10 border border-neutral-200 border-solid bg-neutral-200 w-full transition-all focus:bg-white focus:border hover:bg-neutral-300 hover:border hover:border-blue hover:border-solid placeholder-bold"
          placeholder="Add task"
        ></textarea>
        {tasks &&
          tasks.map((task) => (
            <div key={task.task_ID}>
              <div className="flex shadow-md mb-1">
                <div className="flex items-center py-4 px-2 rounded-l bg-yellow-300">
                  <input
                    id={`checkbox-${task.task_ID}`}
                    type="checkbox"
                    value=""
                    className="w-8 h-8 cursor-pointer border-none bg-yellow-100 hover:border hover:border-blue hover:border-solid rounded focus:ring-0"
                  />
                </div>
                <div className="bg-white rounded-r w-full p-2">
                  <p>{task.title}</p>
                  <p className="text-xs">{task.description}</p>
                </div>
              </div>
            </div>
          ))}
      </div>
    </div>
  );
}

export default TaskTable;
