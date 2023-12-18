const URL = "https://localhost:7017";

const ENDPOINTS = {
  GetAllTasks: `${URL}/api/task`,
  GetTasksByUser: (id) => `${URL}/api/task/${id}`,
  CreateTask: `${URL}/api/task`,
  MarkTask: `${URL}/api/task/MarkTask/`,

  GetAllRewards: `${URL}/api/reward`,
};

export default ENDPOINTS;
