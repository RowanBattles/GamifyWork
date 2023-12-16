function LabelButton() {
  return (
    <>
      <button
        data-dropdown-toggle="dropdown"
        className="bg-white hover:text-blue hover:shadow-md active:shadow-none active:border-solid active:border-blue active:border focus:border-solid focus:border focus:border-blue transition-all shadow font-medium rounded text-xs px-5 py-0 h-auto text-center inline-flex items-center"
        type="button"
      >
        Labels
        <svg
          className="w-2.5 h-2.5 ml-2.5"
          aria-hidden="true"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 10 6"
        >
          <path
            stroke="currentColor"
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth={2}
            d="m1 1 4 4 4-4"
          />
        </svg>
      </button>

      <div
        id="dropdown"
        className="z-10 hidden bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700"
      >
        <ul
          className="py-2 text-sm text-gray-700 dark:text-gray-200"
          aria-labelledby="dropdownDefaultButton"
        >
          <li>
            <div>Label 1</div>
          </li>
        </ul>
      </div>
    </>
  );
}

export default LabelButton;
