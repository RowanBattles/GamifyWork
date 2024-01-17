const URL = "https://localhost:7017";

const ENDPOINTS = {
  getFriends: (id) => `${URL}/api/user/friends/${id}`,
  GetUserById: (id) => `${URL}/api/user/${id}`,
  CreateUser: (id) => `${URL}/api/user/${id}`,

  GetAllTasks: `${URL}/api/task`,
  GetTasksByUser: (id) => `${URL}/api/task/${id}`,
  CreateTask: `${URL}/api/task`,
  MarkTask: (id) => `${URL}/api/task/MarkTask/${id}`,
  DeleteTask: (id) => `${URL}/api/task/${id}`,

  GetAllRewards: `${URL}/api/reward`,
};

export default ENDPOINTS;
