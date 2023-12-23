function RewardTable({ rewards, title }) {
  return (
    <div className="px-4 pt-5 min-h-[556px]">
      <div className="flex justify-between items-center">
        <div className="text-lg font-bold" data-testid="RewardTable">
          {title}
        </div>
      </div>
      <div className="p-2 bg-neutral-100 h-full">
        <textarea
          className="text-sm resize-none h-10 border border-neutral-200 border-solid bg-neutral-200 w-full transition-all focus:bg-white focus:border hover:bg-neutral-300 hover:border hover:border-blue hover:border-solid placeholder-bold"
          placeholder="Add reward"
        ></textarea>
        {rewards.map((reward, index) => (
          <div className="flex shadow-md mb-1" key={index}>
            <div className="flex-col items-center py-2 px-2 rounded-l bg-red-200">
              <img
                src="https://static.vecteezy.com/system/resources/previews/015/271/916/original/gold-coin-icon-with-dollar-sign-yuan-euro-pound-and-baht-illustration-free-png.png"
                className="w-8 max-w-none "
                alt="coin-icon"
              />
              <span className="flex justify-center">{reward.cost}</span>
            </div>
            <div className="bg-white rounded-r w-full p-2">
              <p>{reward.title}</p>
              <p className="text-xs">{reward.description}</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default RewardTable;
