import axios from "axios";
import EndPoints from "./Constants";

function getTasks(setTasks) {
  const url = EndPoints.GetAllTasks;

  axios
    .get(url)
    .then((response) => {
      const tasksFromServer = response.data;
      console.log(tasksFromServer);
      setTasks(tasksFromServer);
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
}

export default getTasks;
