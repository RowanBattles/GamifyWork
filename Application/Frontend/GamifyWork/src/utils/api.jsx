import axios from "axios";
import EndPoints from "./Constants";

export async function getFriends(id) {
  const url = EndPoints.getFriends(id);
  try {
    const response = await axios.get(url);
    console.log("response", response);
    return response.data;
  } catch (error) {
    console.log(error);
    throw error;
  }
}

export async function getUserById(id) {
  const url = EndPoints.GetUserById(id);

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function createUser(id) {
  const url = EndPoints.CreateUser(id);

  try {
    const response = await axios.post(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

// export async function getTasks() {
//   const url = EndPoints.GetAllTasks;

//   try {
//     const response = await axios.get(url);
//     return response.data;
//   } catch (error) {
//     throw error;
//   }
// }

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
  const url = EndPoints.MarkTask(Id);

  try {
    await axios.patch(url);
  } catch (error) {
    throw error;
  }
}

export async function DeleteTask(Id, accessToken) {
  const url = EndPoints.DeleteTask(Id);

  try {
    await axios.delete(url, {
      headers: {
        Authorization: `Bearer ${accessToken}`,
        "Content-Type": "application/json",
      },
    });
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
