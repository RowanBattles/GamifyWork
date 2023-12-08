import "./styles/tailwind.css";
import HomePage from "./pages/HomePage";
import { ToastContainer } from "react-toastify";
import { TaskProvider } from "./hooks/TaskContext";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import PrivateRoute from "./utils/Helpers/PrivateRoute";
import keycloak from "./utils/Keycloak";

function App() {
  return (
    <ReactKeycloakProvider authClient={keycloak}>
      <BrowserRouter>
        <Routes>
          <Route
            exact
            path="/"
            element={
              <PrivateRoute>
                <TaskProvider>
                  <HomePage />
                  <ToastContainer />
                </TaskProvider>
              </PrivateRoute>
            }
          />
        </Routes>
      </BrowserRouter>
    </ReactKeycloakProvider>
  );
}

export default App;
