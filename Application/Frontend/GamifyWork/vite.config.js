import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  test: {
    cache: false,
    clearMocks: true,
    globals: true,
    environment: "jsdom",
    setupFiles: "./tests/setup.js",
  },
});
