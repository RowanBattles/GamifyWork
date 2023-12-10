import "./styles/tailwind.css";
import HomePage from "./pages/HomePage";
import { ToastContainer } from "react-toastify";
import { TaskProvider } from "./hooks/TaskContext";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import PrivateRoute from "./utils/Helpers/PrivateRoute";
import keycloak from "./utils/Keycloak";
import NotFound from "./pages/static/NotFound";

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
          <Route path="*" element={<NotFound />} />
        </Routes>
      </BrowserRouter>
    </ReactKeycloakProvider>
  );
}

export default App;
