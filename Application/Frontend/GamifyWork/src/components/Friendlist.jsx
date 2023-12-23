import React from "react";

function Friendlist() {
  return (
    <div className="w-1/3 p-8 border-r-2 border-gray-200 flex flex-col">
      <p className="text-2xl font-medium mb-8">Friends</p>
      <input
        className="w-full py-2 px-3 rounded-md text-lg border border-gray-300 outline-none focus:border-blue transition-colors mb-8"
        placeholder="Search username..."
      />
      <ul className="overflow-y-auto grid gap-1">
        <li className="w-full bg-white rounded-md border border-gray-300">
          <div className="p-6 flex gap-5">
            <img
              src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
              className="h-12 w-12 bg-gray-300 rounded-full p-1"
            />
            <div className="grid text-md">
              <span className="font-medium">name</span>
              <span className="text-gray-600">offline</span>
            </div>
          </div>
        </li>
      </ul>
    </div>
  );
}

export default Friendlist;
