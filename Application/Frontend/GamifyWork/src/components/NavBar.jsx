import { Tooltip } from "flowbite-react";
import { useState, useEffect, useRef } from "react";
import { useKeycloak } from "@react-keycloak/web";
import { getUser } from "../utils/api";
import { useNavigate } from "react-router-dom";

function NavBar({ title }) {
  const navigate = useNavigate();
  const { keycloak } = useKeycloak();
  const [dropDownOpen, setDropDownOpen] = useState(false);
  const dropdownRef = useRef(null);
  const [points, setPoints] = useState(0);

  const handleTabClick = (title) => {
    if (title === "tasks") {
      navigate("/");
    } else if (title === "friends") {
      navigate("/friends");
    }
  };

  const handleToggleDropDown = () => {
    setDropDownOpen(!dropDownOpen);
  };

  const handleClickOutside = (event) => {
    if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
      setDropDownOpen(false);
    }
  };

  useEffect(() => {
    const getPoints = async () => {
      try {
        const userData = await getUser(keycloak.subject);
        setPoints(userData.points);
      } catch (error) {
        console.error("Error fetching user data:", error);
      }
    };

    const handleAuthentication = async () => {
      if (keycloak.authenticated) {
        await getPoints();
      }
    };

    handleAuthentication();

    document.addEventListener("click", handleClickOutside);
    return () => {
      document.removeEventListener("click", handleClickOutside);
    };
  }, [keycloak.authenticated]);

  return (
    <>
      <nav className="blue px-24 py-2 flex justify-between items-center h-14 text-white font-sans text-lg font-semibold">
        <div className="flex items-center gap-5">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-8"
            alt="LogoImage"
          />
          <img
            src="/src/assets/GamifyWorkLogoText.png"
            className="h-6"
            alt="LogoText"
          />
          <div className="pl-10 flex justify-center">
            <div
              className={`px-5 pb-[7px] pt-[15px] border-blue-600 cursor-pointer hover:bg-blue-600 ${
                title == "tasks" ? "border-b-[6px]" : "border-none"
              }`}
              onClick={() => handleTabClick("tasks")}
            >
              Tasks
            </div>
            <div
              className={`px-5 pb-[7px] pt-[15px] border-blue-600 cursor-pointer hover:bg-blue-600 ${
                title == "friends" ? "border-b-[6px]" : "border-none"
              }`}
              onClick={() => handleTabClick("friends")}
            >
              Friends
            </div>
          </div>
        </div>
        <div className="flex items-center gap-10">
          <div className="flex items-center gap-2">
            <img
              src="https://static.vecteezy.com/system/resources/previews/015/271/916/original/gold-coin-icon-with-dollar-sign-yuan-euro-pound-and-baht-illustration-free-png.png"
              className="h-6"
              alt="coin-icon"
            />
            <span>{points}</span>
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
                } top-12 right-8 z-50 min-w-[20rem] bg-white text-black font-normal shadow-lg rounded border border-gray-20 cursor-pointer`}
              >
                <div className="text-center p-4 cursor-default">
                  <div className="font-bold" data-testid="KeycloakUsername">
                    {keycloak.tokenParsed.preferred_username}
                  </div>
                  <div data-testid="KeycloakEmail">
                    {keycloak.tokenParsed.email}
                  </div>
                </div>
                <hr />
                <div
                  className="px-6 py-2 hover:text-blue hover:underline hover:bg-blue-50"
                  onClick={() => {
                    window.location.href = keycloak.createAccountUrl();
                  }}
                >
                  profile
                </div>
                <div
                  className="px-6 py-2 hover:text-blue hover:underline hover:bg-blue-50"
                  onClick={() => keycloak.logout()}
                  data-testid="KeycloakLogoutButton"
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
