import React, { useEffect, useState } from "react";
import { useKeycloak } from "@react-keycloak/web";
import Login from "../../pages/static/Login";
import { createUser, getUserById } from "../api";

const PrivateRoute = ({ children }) => {
  const { keycloak, initialized } = useKeycloak();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const validateUser = async () => {
      try {
        await getUserById(keycloak.subject);
        console.log(keycloak.token);
        setLoading(false);
        setError(null);
      } catch (error) {
        await createOrValidateUser();
      }
    };

    const createOrValidateUser = async () => {
      try {
        await createUser(keycloak.subject);
        await validateUser();
        setError(null);
      } catch (error) {
        setError(error);
        setLoading(false);
      }
    };

    if (keycloak.authenticated) {
      validateUser();
    } else {
      setLoading(false);
    }
  }, [keycloak.authenticated]);

  if (!initialized || loading) {
    return (
      <div className="h-screen blue flex justify-center content-center items-center">
        <img
          src="/src/assets/GamifyWorkLogoWhite.png"
          className="h-1/4 animate-pulse"
          alt="LogoLoading"
        />
      </div>
    );
  }

  if (error !== null) {
    alert("User couldn't be loaded. Try refreshing the page");
  }

  if (!keycloak.authenticated) {
    return <Login />;
  }

  return children;
};

export default PrivateRoute;
