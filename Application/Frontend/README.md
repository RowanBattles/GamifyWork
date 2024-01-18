# Frontend

This application is constructed using React and Vite, offering a streamlined setup for a swift and effective development environment. The following instructions detail how to utilize and execute the application, now enhanced with TypeScript support.

## Table of Contents

- [Using the application](#using-the-application)
  - [Scripts](#scripts)
  - [Dependencies](#dependencies)
  - [Build](#build)
  - [Testing](#testing)

## Using the application

First of all, go into the GamifyWork folder in this directory before you run any code!

### Scripts

The following scripts are available for development, testing, and deployment:

- predeploy: Runs before deploying to build the application.
- deploy: Deploys the application to GitHub Pages using gh-pages.
- dev: Starts the development server with Vite.
- build: Compiles TypeScript and builds the application.
- scan:translations: Scans translations using i18next-scanner.
- lint: Lints the code using ESLint.
- preview: Previews the production build locally.
- test: Runs Cypress tests in headless mode.
- test:open: Opens Cypress test runner for interactive testing.

### Dependencies

Start with installing the dependancies with:

```
yarn install
```

Key dependencies used in this project:

- React: A JavaScript library for building user interfaces.
- Vite: A fast and efficient development server and bundler.
- Vitest: A fast and efficient test framework derived from jest.
- Axios: A promise-based HTTP client for making requests.
- SignalR: Enables real-time, bidirectional, and event-based communication.

For a complete list, refer to the package.json file.

### Build

To build the application for production, run:

```
yarn build
```

### Dev

To run the application for production, run:

```
yarn dev
```

### Vitest

To run the component and integration tests, run:

```
yarn test
```

### End-to-end testing

First of all, you have to run the project in a separate console [here](#dev)

To run Cypress tests in headless mode, use:

```
yarn cypress run
```

For interactive testing, run:

```
yarn cypress open
```
