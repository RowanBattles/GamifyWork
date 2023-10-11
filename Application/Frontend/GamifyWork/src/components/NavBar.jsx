import React from "react";

function NavBar() {
  return (
    <>
      <nav className="blue px-4 py-2 flex justify-between items-center h-14 text-white font-sans text-lg font-semibold">
        <div className="flex items-center">
          <img src="/src/assets/GamifyWorkLogoWhite.png" className="h-8 mr-5" />
          <img src="/src/assets/GamifyWorkLogoText.png" className="h-6" />
        </div>
        <div className="flex items-center gap-10">
          <div className="flex items-center gap-2">
            <img
              src="https://static.vecteezy.com/system/resources/previews/015/271/916/original/gold-coin-icon-with-dollar-sign-yuan-euro-pound-and-baht-illustration-free-png.png"
              className="h-6"
            />
            <span>112</span>
          </div>
          <button
            className="hover:bg-blue-500 rounded-full p-1 transition-all"
            data-tooltip-target="UserIcon"
          >
            <img
              src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
              className="invert h-6"
            />
          </button>
          <div
            id="UserIcon"
            className="absolute z-10 invisible inline-block px-3 py-2 text-xs font-medium transition-all duration-150 delay-75 bg-gray-700 rounded-lg shadow-sm opacity-0 tooltip"
          >
            Profile
          </div>
        </div>
      </nav>
    </>
  );
}

export default NavBar;
