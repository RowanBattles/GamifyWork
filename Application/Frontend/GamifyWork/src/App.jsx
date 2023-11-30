import "./styles/tailwind.css";
import HomePage from "./pages/HomePage";
import { ToastContainer } from "react-toastify";
import { TaskProvider } from "./hooks/TaskContext";

function App() {
  return (
    <TaskProvider>
      <HomePage />
      <ToastContainer />
    </TaskProvider>
  );
}

export default App;
