import { defineConfig } from "cypress";

export default defineConfig({
  projectId: "tjkix2",
  e2e: {
    experimentalStudio: true,
    baseUrl: "http://localhost:5173/",
    viewportWidth: 1920,
    viewportHeight: 1080,
  },
  env: {
    auth_base_url: "http://localhost:8080/auth",
    auth_realm: "GamifyWork",
    auth_client_id: "GamifyWork",
  },
});
