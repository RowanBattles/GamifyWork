import React from "react";
import { useKeycloak } from "@react-keycloak/web";

function LoginPage() {
  const { keycloak } = useKeycloak();

  return (
    <>
      <nav className="blue px-64 h-24 flex justify-between items-center text-white font-sans text-lg font-semibold">
        <div className="flex items-center">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-16 mr-5"
            alt="LogoImage"
          />
          <img
            src="/src/assets/GamifyWorkLogoText.png"
            className="h-6"
            alt="LogoText"
          />
        </div>
        <div className="flex gap-10 text-xl items-center">
          <button className="border-blue border-b-4 py-4 hover:border-white  transition-all">
            Sign in
          </button>
          <button className="border border-slate-400 p-4 rounded-xl hover:border-white  transition-all">
            Sign up for free
          </button>
        </div>
      </nav>
      <div className="px-24 flex w-full pt-24">
        <div className="w-1/2">
          <div>
            <h2>Level up your productivity with GamifyWork</h2>
            <h2>Turning tasks into triumphs!</h2>
          </div>
          <div>Uitleg</div>
          <div>Button</div>
        </div>
        <div className="w-1/2">Image</div>
      </div>
    </>
  );
}

export default LoginPage;
