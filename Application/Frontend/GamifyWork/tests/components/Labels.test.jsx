import { render, screen } from "@testing-library/react";
import LabelButton from "../../src/components/Labels";

it("renders LabelButton component", () => {
  render(<LabelButton />);

  // Check if the button and dropdown are rendered
  const buttonElement = screen.getByText("Labels");
  const dropdownElement = screen.getByRole("list");

  expect(buttonElement).toBeInTheDocument();
  expect(dropdownElement).toBeInTheDocument();
});
