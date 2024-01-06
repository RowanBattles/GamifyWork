import { render, screen } from "@testing-library/react";
import NavBar from "../../src/components/NavBar";
import { useKeycloak } from "@react-keycloak/web";

vi.mock("react-router-dom");
vi.mock("@react-keycloak/web");

it("renders NavBar component", () => {
  useKeycloak.mockReturnValue({
    keycloak: {
      tokenParsed: {
        username: "test",
      },
    },
  });

  render(<NavBar />);

  // Check if the logo images, coin icon, and user icon are rendered
  const logoImage = screen.getByAltText("LogoImage");
  const logoText = screen.getByAltText("LogoText");
  const coinIcon = screen.getByAltText("coin-icon");
  const userIcon = screen.getByAltText("user-icon");

  expect(logoImage).toBeInTheDocument();
  expect(logoText).toBeInTheDocument();
  expect(coinIcon).toBeInTheDocument();
  expect(userIcon).toBeInTheDocument();
});
