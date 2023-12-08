import React from "react";
import { useKeycloak } from "@react-keycloak/web";

function LoginPage() {
  const { keycloak } = useKeycloak();

  return (
    <div>
      <button onClick={() => keycloak.login()}>hoi</button>
      <button onClick={() => keycloak.register()}>hoi</button>
    </div>
  );
}

export default LoginPage;
