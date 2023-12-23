import React from "react";

function ErrorDisplay({ errorHeader, errorBody }) {
  return (
    <>
      <div
        className="border border-gray-400 bg-white border-solid mt-5 p-5"
        data-testid="ErrorDisplayId"
      >
        <div
          className="text-red-500 font-extrabold text-2xl mb-2"
          data-testid="errorHeader"
        >
          {errorHeader}
        </div>
        <div
          className="text-s font-semibold break-words"
          data-testid="errorBody"
        >
          {errorBody}
        </div>
      </div>
      <span className="px-5">
        Try again &nbsp;
        <a className="text-blue underline" href="http://localhost:5173">
          here
        </a>
        , or Contact Us about the problem.
      </span>
    </>
  );
}

export default ErrorDisplay;
