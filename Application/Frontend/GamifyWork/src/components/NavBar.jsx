import { Tooltip } from "flowbite-react";
import { useState, useEffect, useRef } from "react";
import { useKeycloak } from "@react-keycloak/web";

function NavBar() {
  const { keycloak } = useKeycloak();
  const [dropDownOpen, setDropDownOpen] = useState(false);
  const dropdownRef = useRef(null);

  const handleToggleDropDown = () => {
    setDropDownOpen(!dropDownOpen);
  };

  const handleClickOutside = (event) => {
    if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
      setDropDownOpen(false);
    }
  };

  useEffect(() => {
    console.log(keycloak.subject);
    console.log(keycloak.idTokenParsed.preferred_username);
    console.log(keycloak.idTokenParsed.email);
    console.log(keycloak.idTokenParsed.name);
    console.log(keycloak.idTokenParsed.given_name);
    console.log(keycloak.idTokenParsed.family_name);

    document.addEventListener("click", handleClickOutside);

    return () => {
      document.removeEventListener("click", handleClickOutside);
    };
  }, []);

  return (
    <>
      <nav className="blue px-24 py-2 flex justify-between items-center h-14 text-white font-sans text-lg font-semibold">
        <div className="flex items-center">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-8 mr-5"
            alt="LogoImage"
          />
          <img
            src="/src/assets/GamifyWorkLogoText.png"
            className="h-6"
            alt="LogoText"
          />
        </div>
        <div className="flex items-center gap-10">
          <div className="flex items-center gap-2">
            <img
              src="https://static.vecteezy.com/system/resources/previews/015/271/916/original/gold-coin-icon-with-dollar-sign-yuan-euro-pound-and-baht-illustration-free-png.png"
              className="h-6"
              alt="coin-icon"
            />
            <span>112</span>
          </div>
          <Tooltip
            className="px-5 mt-[3px] rounded-md shadow-lg bg-gray-700 ml-[-20px] hover:hidden"
            content="Profile"
            placement="bottom"
            animation="duration-500"
            arrow={false}
          >
            <div
              className={`hover:bg-blue-500 rounded-full p-1 transition-all cursor-pointer ${
                dropDownOpen ? "bg-blue-500" : ""
              }`}
              data-tooltip-target="UserIcon"
              onClick={handleToggleDropDown}
              ref={dropdownRef}
            >
              <img
                src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
                alt="user-icon"
                className="invert h-6"
              />
              <div
                className={`${
                  dropDownOpen ? "absolute" : "hidden"
                } top-12 right-8 z-50 w-60 bg-white text-black font-normal shadow-lg rounded border border-gray-20 cursor-pointer`}
              >
                <div className="text-center p-4 cursor-default">
                  <div className="font-bold">
                    {keycloak.tokenParsed.preferred_username}
                  </div>
                  <div>{keycloak.tokenParsed.email}</div>
                </div>
                <hr />
                <div className="px-6 py-2 hover:text-blue hover:underline hover:bg-blue-50">
                  profile
                </div>
                <div
                  className="px-6 py-2 hover:text-blue hover:underline hover:bg-blue-50"
                  onClick={() => keycloak.logout()}
                >
                  logout
                </div>
              </div>
            </div>
          </Tooltip>
        </div>
      </nav>
    </>
  );
}

export default NavBar;
