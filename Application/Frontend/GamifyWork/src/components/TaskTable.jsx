import React, { useState } from "react";
import { filterTasksByStatus } from "../utils/Filters/taskFilters";

function TaskTable({ tasks, title }) {
  const [activeFilter, setActiveFilter] = useState("All");
  const filteredTasks = filterTasksByStatus(tasks, activeFilter);

  if (tasks === null) {
    return null;
  }

  return (
    <div className="px-4 pt-5 min-h-[556px]">
      <div className="flex justify-between items-center">
        <div className="text-lg font-bold">{title}</div>
        <div className="text-xs flex font-bold text-gray-600">
          <div
            className={`p-2 cursor-pointer hover:text-blue ${
              activeFilter === "All" ? "text-blue border-b-4 border-blue" : ""
            }`}
            onClick={() => setActiveFilter("All")}
          >
            All
          </div>
          <div
            className={`p-2 cursor-pointer hover:text-blue ${
              activeFilter === "Active"
                ? "text-blue border-b-4 border-blue"
                : ""
            }`}
            onClick={() => setActiveFilter("Active")}
          >
            Active
          </div>
          <div
            className={`p-2 cursor-pointer hover:text-blue ${
              activeFilter === "Completed"
                ? "text-blue border-b-4 border-blue"
                : ""
            }`}
            onClick={() => setActiveFilter("Completed")}
          >
            Completed
          </div>
        </div>
      </div>
      <div className="p-2 bg-neutral-100 h-full">
        <textarea
          className="text-sm resize-none h-10 border border-neutral-200 border-solid bg-neutral-200 w-full transition-all focus:bg-white focus:border hover:bg-neutral-300 hover:border hover:border-blue hover:border-solid placeholder-bold"
          placeholder="Add task"
        ></textarea>
        {filteredTasks.map((task) => (
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
