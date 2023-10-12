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
      </div>
    </div>
  );
}

export default TaskTable;
