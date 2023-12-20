import axios from "axios";
import EndPoints from "./Constants";

export async function getUser(id) {
  const url = EndPoints.GetUser(id);

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function getTasks() {
  const url = EndPoints.GetAllTasks;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function getTasksByUser(id) {
  const url = EndPoints.GetTasksByUser(id);

  try {
    const response = await axios.get(url, id);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function MarkTask(Id) {
  const url = EndPoints.MarkTask + Id;

  try {
    await axios.patch(url);
  } catch (error) {
    throw error;
  }
}

export async function CreateTask(taskData) {
  const url = EndPoints.CreateTask;

  try {
    const response = await axios.post(url, taskData);
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
