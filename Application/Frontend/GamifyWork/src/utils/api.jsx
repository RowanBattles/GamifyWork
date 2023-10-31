import axios from "axios";
import EndPoints from "./Constants";

export async function getTasks() {
  const url = EndPoints.GetAllTasks;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function getRewards() {
  const url = EndPoints.GetAllRewards;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}
