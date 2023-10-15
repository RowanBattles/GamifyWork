import React from "react";

function TaskTable() {
  const name = "Recurring Tasks";

  return (
    <div className="px-4 pt-5 ">
      <div className="flex justify-between items-center">
        <div className="text-lg font-bold">{name}</div>
        <div className="text-sm flex gap-2">
          <div>Every</div>
          <div>Completed</div>
          <div>Active</div>
        </div>
      </div>
      <div className="p-2 bg-neutral-100">
        <textarea
          className="text-sm resize-none h-10 border border-neutral-200 border-solid bg-neutral-200 w-full transition-all focus:bg-white focus:border hover:bg-neutral-300 hover:border hover:border-blue hover:border-solid placeholder-bold"
          placeholder="Add task"
        ></textarea>
        <div>
          <div className="flex">
            <div class="flex items-center mb-4">
              <input
                id="default-checkbox"
                type="checkbox"
                value=""
                class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600"
              />
            </div>
            <div className="bg-red-500 w-full">Taak informatie</div>
          </div>
          <div>taak 2</div>
        </div>
      </div>
    </div>
  );
}

export default TaskTable;
