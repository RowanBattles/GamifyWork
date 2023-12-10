import React from "react";
import { useKeycloak } from "@react-keycloak/web";
import Login from "../../pages/static/Login";

const PrivateRoute = ({ children }) => {
  const { keycloak, initialized } = useKeycloak();

  if (!initialized) {
    return (
      <>
        <div className="h-screen blue flex justify-center content-center items-center">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-1/4 animate-pulse"
            alt="LogoLoading"
          />
        </div>
      </>
    );
  }

  if (!keycloak.authenticated) {
    return <Login />;
  }

  return children;
};

export default PrivateRoute;
