function RewardTable({ rewards, title }) {
  const activeFilter = "All";

  return (
    <div className="px-4 pt-5 min-h-[556px]">
      <div className="flex justify-between items-center">
        <div className="text-lg font-bold">{title}</div>
        <div className="text-xs flex font-bold text-gray-600">
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
        <div className="flex shadow-md mb-1">
          <div className="flex items-center py-4 px-2 rounded-l bg-yellow-300">
            <input
              type="checkbox"
              value=""
              className="w-8 h-8 cursor-pointer border-none bg-yellow-100 hover:border hover:border-blue hover:border-solid rounded focus:ring-0"
            />
          </div>
          <div className="bg-white rounded-r w-full p-2">
            <p>Reward title</p>
            <p className="text-xs">Reward description</p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default RewardTable;
