function SearchBar({ setSearchQuery }) {
  const handleInputChange = (event) => {
    setSearchQuery(event.target.value);
  };

  return (
    <div className="relative">
      <div className="relative">
        <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
          <svg
            className="w-4 h-4 text-gray-500"
            fill="none"
            viewBox="0 0 20 20"
            data-testid="search-icon"
          >
            <path
              stroke="currentColor"
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth={2}
              d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
            />
          </svg>
        </div>
        <input
          className="outline-none block w-full px-4 py-2 pl-10 text-sm text-gray-900 border border-gray-300 rounded bg-white focus:border-blue transition-all duration-300"
          placeholder="Search"
          onChange={handleInputChange}
        />
      </div>
    </div>
  );
}

export default SearchBar;
