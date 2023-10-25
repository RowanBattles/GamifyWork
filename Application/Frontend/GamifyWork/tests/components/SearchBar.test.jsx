import { render, screen } from "@testing-library/react";
import SearchBar from "../../src/components/SearchBar";

it("renders SearchBar component", () => {
  render(<SearchBar />);

  // Check if the search input and search icon are rendered
  const searchInput = screen.getByPlaceholderText("Search");
  const searchIcon = screen.getByTestId("search-icon");

  expect(searchInput).toBeInTheDocument();
  expect(searchIcon).toBeInTheDocument();
});
