export function taskCorrect() {
  cy.intercept(
    "GET",
    "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
    {
      statusCode: 200,
      fixture: "../fixtures/tasks.json",
    }
  ).as("getTasks");
}

export function taskError() {
  cy.intercept(
    "GET",
    "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
    {
      statusCode: 500,
    }
  ).as("getTasks");
}

export function taskCustomError() {
  cy.intercept(
    "GET",
    "https://localhost:7017/api/task/60ad8b86-edf7-4e40-87d0-90a153732e8a",
    {
      statusCode: 500,
      fixture: "../fixtures/error.json",
    }
  ).as("getTasks");
}

export function rewardCorrect() {
  cy.intercept("GET", "https://localhost:7017/api/reward", {
    statusCode: 200,
    fixture: "../fixtures/rewards.json",
  }).as("getRewards");
}

export function rewardError() {
  cy.intercept("GET", "https://localhost:7017/api/reward", {
    statusCode: 500,
  }).as("getRewards");
}

export function rewardCustomError() {
  cy.intercept("GET", "https://localhost:7017/api/reward", {
    statusCode: 500,
    fixture: "../fixtures/error.json",
  }).as("getRewards");
}
