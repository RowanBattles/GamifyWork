import { render, screen } from "@testing-library/react";
import HomePage from "../../src/pages/HomePage";
import { vi } from "vitest";
import useFetch from "../../src/hooks/useFetch";

vi.mock("@react-keycloak/web", () => ({
  ...vi.importActual("@react-keycloak/web"),
  useKeycloak: () => ({
    keycloak: {
      subject: "dummysubject",
      tokenParsed: { preferred_username: "dummyname" },
    },
  }),
}));
vi.mock("../../src/hooks/useFetch");

it("renders loading state", async () => {
  useFetch.mockReturnValue({
    data: null,
    loading: true,
    errorHeader: null,
    errorBody: null,
  });

  render(<HomePage />);

  const loadingIndicator = screen.getByAltText("LogoLoading");
  expect(loadingIndicator).toBeInTheDocument();
});

it("renders error state", async () => {
  useFetch.mockReturnValue({
    data: null,
    loading: false,
    errorHeader: "error",
    errorBody: "error",
  });

  render(<HomePage />);

  const errorDisplay = screen.getByTestId("ErrorDisplayId");
  expect(errorDisplay).toBeInTheDocument();
});
