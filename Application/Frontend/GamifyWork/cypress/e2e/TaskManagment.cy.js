describe("Creating task", () => {
  beforeEach(() => {
    cy.kcLogout();
    cy.kcLogin("user");
    cy.visit("/");
  });

  it("Create todo task succesfully", () => {
    cy.intercept("POST", "https://localhost:7017/api/task", {
      statusCode: 200,
    }).as("createTask");

    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).should("be.enabled");
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).click();
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).type("new todo task");
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).type("{enter}");

    cy.wait("@createTask");
    cy.get(".Toastify__toast-body > :nth-child(2)").should(
      "have.text",
      "created task succesfully!"
    );
  });

  it("Create todo task fails, unexpected error", () => {
    cy.intercept("POST", "https://localhost:7017/api/task", (req) => {
      req.reply({
        statusCode: 500,
      });
    }).as("createTask");

    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).should("be.enabled");
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).click();
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).type("new todo task");
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).type("{enter}");

    cy.wait("@createTask");
    cy.get(".Toastify__toast-body > :nth-child(2)").should(
      "have.text",
      "Error: failed creating task."
    );
  });

  it("Create todo task fails, with message", () => {
    cy.intercept("POST", "https://localhost:7017/api/task", (req) => {
      req.reply({
        statusCode: 500,
        fixture: "../fixtures/error.json",
      });
    }).as("createTask");

    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).should("be.enabled");
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).click();
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).type("new todo task");
    cy.get(
      ':nth-child(2) > .bg-neutral-100 > [data-testid="addTaskTextarea"]'
    ).type("{enter}");

    cy.wait("@createTask");
    cy.get(".Toastify__toast-body > :nth-child(2)").should(
      "have.text",
      "1: Message"
    );
  });
});

describe("Viewing tasks", () => {
  beforeEach(() => {
    cy.kcLogout();
    cy.kcLogin("user");
    cy.visit("/");
  });

  it("View tasks and rewards succesfully", () => {
    cy.intercept(
      "GET",
      "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
      {
        statusCode: 200,
        fixture: "../fixtures/tasks.json",
      }
    ).as("getTasks");

    cy.wait("@getTasks");
    cy.get('[data-testid="task-1"]').should(
      "have.attr",
      "data-testid",
      "task-1"
    );
    cy.get('[data-testid="task-1"]').should(
      "have.text",
      "Recurring task - Cypress"
    );
    cy.get('[data-testid="task-1"]').should("be.visible");
    cy.get('[data-testid="task-2"]').should(
      "have.attr",
      "data-testid",
      "task-2"
    );
    cy.get('[data-testid="task-2"]').should(
      "have.text",
      "To do task - Cypress"
    );
    cy.get('[data-testid="task-2"]').should("be.visible");
  });

  it("View error, tasks error", () => {
    cy.intercept(
      "GET",
      "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
      {
        statusCode: 500,
      }
    ).as("getTasks");
    cy.wait("@getTasks");

    cy.get('[data-testid="errorHeader"]').should(
      "have.text",
      "Unexpected error"
    );
    cy.get('[data-testid="errorHeader"]').should("be.visible");
    cy.get('[data-testid="errorBody"]').should(
      "have.text",
      "Couldn't fetch tasks."
    );
    cy.get('[data-testid="errorBody"]').should("be.visible");
  });

  it("View error, rewards error", () => {
    cy.intercept("GET", "https://localhost:7017/api/reward", {
      statusCode: 500,
    }).as("getRewards");
    cy.wait("@getRewards");

    cy.get('[data-testid="errorHeader"]').should(
      "have.text",
      "Unexpected error"
    );
    cy.get('[data-testid="errorHeader"]').should("be.visible");
    cy.get('[data-testid="errorBody"]').should(
      "have.text",
      "Couldn't fetch rewards."
    );
    cy.get('[data-testid="errorBody"]').should("be.visible");
  });

  it("View error, tasks and rewards error", () => {
    cy.intercept(
      "GET",
      "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
      {
        statusCode: 500,
      }
    ).as("getTasks");

    cy.intercept("GET", "https://localhost:7017/api/reward", {
      statusCode: 500,
    }).as("getRewards");

    cy.get('[data-testid="errorBody"]').should(
      "have.text",
      "Couldn't fetch tasks. Couldn't fetch rewards."
    );
  });

  it("View error, tasks error custom message", () => {
    cy.intercept(
      "GET",
      "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
      {
        statusCode: 500,
        fixture: "../fixtures/error.json",
      }
    ).as("getTasks");
    cy.wait("@getTasks");

    cy.get('[data-testid="errorHeader"]').should("have.text", "1");
    cy.get('[data-testid="errorBody"]').should("have.text", "Message. ");
  });
});
