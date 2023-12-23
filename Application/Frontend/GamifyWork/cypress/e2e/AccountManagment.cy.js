describe("Account managment", () => {
  beforeEach;

  it("Visits the app", () => {
    cy.visit("/");
    cy.get('[data-testid="HeaderTextIntroduction"]').should(
      "have.text",
      "Turning tasks into triumphs!"
    );
    cy.get('[data-testid="IntroductionImage"]').should("be.visible");
  });

  it("Should register", () => {
    cy.register({
      root: "http://localhost:8080",
      realm: "GamifyWork",
      client_id: "GamifyWork",
      redirect_uri: "http://localhost:5173",
      username: "newUser",
      email: "newUser@example.com",
      password: "password123",
      passwordConfirm: "password123",
      additionalAttributes: {
        customAttribute: "customValue",
      },
    });

    cy.visit("/");
    cy.get('[data-testid="GetStartedItsFreeButton"]').should(
      "have.attr",
      "data-testid",
      "GetStartedItsFreeButton"
    );
    cy.get('[data-testid="GetStartedItsFreeButton"]').should("be.enabled");
    cy.get('[data-testid="SignUpForFreeButton"]').should(
      "have.attr",
      "data-testid",
      "SignUpForFreeButton"
    );
    cy.get('[data-testid="SignUpForFreeButton"]').should("be.enabled");
  });

  it("Should LogIn", () => {
    cy.kcLogin("user");
    cy.visit("/");
    cy.get(".invert").should("have.attr", "alt", "user-icon");
    cy.get(".invert").click();
    cy.get('[data-testid="KeycloakUsername"]').should(
      "have.attr",
      "data-testid",
      "KeycloakUsername"
    );
    cy.get('[data-testid="KeycloakUsername"]').should("be.visible");
    cy.get('[data-testid="KeycloakEmail"]').should(
      "have.attr",
      "data-testid",
      "KeycloakEmail"
    );
    cy.get('[data-testid="KeycloakEmail"]').should("be.visible");
  });

  it("Should LogOut", () => {
    cy.kcLogout();
    cy.kcLogin("user");
    cy.visit("/");
    cy.get(".invert").click();
    cy.get('[data-testid="KeycloakLogoutButton"]').should(
      "have.attr",
      "data-testid",
      "KeycloakLogoutButton"
    );
    cy.get('[data-testid="KeycloakLogoutButton"]').should("be.visible");
    cy.get('[data-testid="KeycloakLogoutButton"]').click();
    cy.get('[data-testid="HeaderTextIntroduction"]').should(
      "have.attr",
      "data-testid",
      "HeaderTextIntroduction"
    );
    cy.get('[data-testid="HeaderTextIntroduction"]').should("be.visible");
  });
});
