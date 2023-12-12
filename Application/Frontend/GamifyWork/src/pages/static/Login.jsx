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
          <button
            className="border-blue border-b-4 py-4 hover:border-white  transition-all"
            onClick={() => keycloak.login()}
          >
            Sign in
          </button>
          <button
            className="border border-slate-400 p-4 rounded-xl hover:border-white  transition-all"
            onClick={() => keycloak.register()}
          >
            Sign up for free
          </button>
        </div>
      </nav>
      <div className="px-80 flex w-full pt-60">
        <div className="w-1/2 flex flex-col justify-center">
          <p className="text-6xl font-['Open_Sans'] font-bold">
            Turning tasks into triumphs!
          </p>
          <p className="text-xl mt-10">
            Join millions of people to capture ideas, organize life, and do
            something creative everyday.
          </p>
          <button
            className="blue text-white px-10 py-5 rounded-2xl mt-10 font-bold text-xl w-fit"
            onClick={() => keycloak.register()}
          >
            Get started - it's free
          </button>
        </div>
        <div className="w-1/2 flex justify-center items-center">
          <img
            src="https://d107mjio2rjf74.cloudfront.net/sites/res/home/common/header.png"
            className="w-3/4"
          />
        </div>
      </div>
    </>
  );
}

export default LoginPage;
