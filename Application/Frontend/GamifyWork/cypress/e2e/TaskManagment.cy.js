import {
  taskCorrect,
  taskError,
  taskCustomError,
  rewardCorrect,
  rewardError,
  rewardCustomError,
} from "../interceptions";

describe("Creating task", () => {
  beforeEach(() => {
    cy.kcLogout();
    cy.kcLogin("user");
    cy.visit("/");

    cy.intercept(
      "POST",
      "https://localhost:7017/api/user/60ad8b86-edf7-4e40-87d0-90a153732e8a",
      {
        statusCode: 200,
      }
    ).as("login");

    taskCorrect();
    rewardCorrect();
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
      "Failed creating task. An unexpected error occurred."
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

describe("Viewing tasks and rewards", () => {
  beforeEach(() => {
    cy.kcLogout();
    cy.kcLogin("user");
    cy.visit("/");

    cy.intercept(
      "POST",
      "https://localhost:7017/api/user/60ad8b86-edf7-4e40-87d0-90a153732e8a",
      {
        statusCode: 200,
      }
    ).as("login");
  });

  it("View tasks and rewards succesfully", () => {
    taskCorrect();
    rewardCorrect();

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
    taskError();
    rewardCorrect();

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
    taskCorrect();
    rewardError();

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
    taskError();
    rewardError();

    cy.get('[data-testid="errorBody"]').should(
      "have.text",
      "Couldn't fetch tasks. Couldn't fetch rewards."
    );
  });

  it("View error, tasks error custom message", () => {
    taskCustomError();
    rewardCorrect();
    cy.get('[data-testid="errorHeader"]').should("have.text", "1");
    cy.get('[data-testid="errorBody"]').should("have.text", "Message. ");
  });

  it("View error, rewards error custom message", () => {
    taskCorrect();
    rewardCustomError();
    cy.get('[data-testid="errorHeader"]').should("have.text", "1");
    cy.get('[data-testid="errorBody"]').should("have.text", "Message. ");
  });
});
