import "./styles/tailwind.css";
import HomePage from "./pages/HomePage";
import { ToastContainer } from "react-toastify";

function App() {
  return (
    <>
      <HomePage />
      <ToastContainer />
    </>
  );
}

export default App;
