import React, { useState } from "react";
import { filterTasksByStatus } from "../utils/Filters/taskFilters";
import { CreateTask, DeleteTask, MarkTask, getTasksByUser } from "../utils/api";
import { failed, succes } from "../utils/Helpers/toast";
import { useTaskContext } from "../hooks/TaskContext";
import keycloak from "../utils/Keycloak";

function TaskTable({ tasks, title }) {
  const [activeFilter, setActiveFilter] = useState("Active");
  const [newTask, setNewTask] = useState("");
  const [hoveredTask, setHoveredTask] = useState(null);
  const filteredTasks = filterTasksByStatus(tasks, activeFilter);
  const { updateTasks } = useTaskContext();

  const handleInputChange = (event) => {
    setNewTask(event.target.value);
  };

  let isHandlingKeyDown = false;

  const handleKeyDown = async (event) => {
    if (isHandlingKeyDown) {
      return;
    }

    isHandlingKeyDown = true;

    if (event.key === "Enter") {
      event.preventDefault();
      const recurring = title === "Recurring" ? true : false;
      const recurrenceType = title === "Recurring" ? "Weekly" : null;
      const recurrenceInterval = title === "Recurring" ? 1 : null;
      const taskData = {
        title: newTask.trim(),
        user_ID: 1,
        recurring: recurring,
        recurrenceType: recurrenceType,
        recurrenceInterval: recurrenceInterval,
        user: keycloak.subject,
      };
      if (newTask.trim() !== "") {
        try {
          await CreateTask(taskData);
          succes("created task succesfully!");
          setNewTask("");
        } catch (error) {
          if (error.response && error.response.data) {
            const data = error.response.data;
            const errorMessage = data.Message || "failed creating task.";
            failed(`${data.ErrorCode || "Error"}: ${errorMessage}`);
          } else {
            failed("Failed creating task. An unexpected error occurred.");
          }
        }

        try {
          const updatedTasks = await getTasksByUser(keycloak.subject);
          updateTasks(updatedTasks);
        } catch (error) {
          if (error.response && error.response.data) {
            const data = error.response.data;
            const errorMessage = data.Message || "failed updating task.";
            failed(`${data.ErrorCode || "Error"}: ${errorMessage}`);
          } else {
            failed("Failed updating task. An unexpected error occurred.");
          }
        }
      }

      isHandlingKeyDown = false;
      event.target.blur();
    }
  };

  const markTask = async (id) => {
    try {
      var error = await PatchFunction(MarkTask, id, "tasks");
      const updatedTasks = await getTasksByUser(keycloak.subject);
      updateTasks(updatedTasks);
      if (error != null) {
        throw err;
      }
    } catch (err) {
      console.log(err);
      failed(error.errorMessage);
    }
  };

  const deleteTask = async (id) => {
    try {
      const userConfirmed = window.confirm(
        "Are you sure you want to delete this task?"
      );

      if (userConfirmed) {
        await DeleteTask(id, keycloak.token);
        const updatedTasks = await getTasksByUser(keycloak.subject);
        updateTasks(updatedTasks);
      }
    } catch (err) {
      failed("Error deleting task");
    }
  };

  const PatchFunction = async (patchFunction, id, dataMessage) => {
    try {
      await patchFunction(id);
    } catch (error) {
      let errorMessage = "";
      if (error.response.data != null) {
        const { Message, ErrorCode } = error.response.data;
        errorMessage += ErrorCode + " " + Message;
      } else {
        errorMessage += `failed marking ${dataMessage}`;
      }
      return { errorMessage };
    }
  };

  const handleMouseEnter = (task) => {
    setHoveredTask(task);
  };

  const handleMouseLeave = () => {
    setHoveredTask(null);
  };

  return (
    <>
      <div className="px-4 pt-5 min-h-[556px]">
        <div className="flex justify-between items-center">
          <div className="text-lg font-bold" data-testid={`TaskTable-${title}`}>
            {title}
          </div>
          <div className="text-xs flex font-bold text-gray-600">
            <div
              className={`pb-2 px-2 cursor-pointer hover:text-blue ${
                activeFilter === "All" ? "text-blue border-b-4 border-blue" : ""
              }`}
              onClick={() => setActiveFilter("All")}
            >
              All
            </div>
            <div
              className={`pb-2 px-2 cursor-pointer hover:text-blue ${
                activeFilter === "Active"
                  ? "text-blue border-b-4 border-blue"
                  : ""
              }`}
              onClick={() => setActiveFilter("Active")}
            >
              Active
            </div>
            <div
              className={`pb-2 px-2 cursor-pointer hover:text-blue ${
                activeFilter === "Completed"
                  ? "text-blue border-b-4 border-blue"
                  : ""
              }`}
              onClick={() => setActiveFilter("Completed")}
            >
              Completed
            </div>
          </div>
        </div>
        <div className="p-2 bg-neutral-100 h-full">
          <textarea
            className="text-sm resize-none h-10 border border-neutral-200 border-solid bg-neutral-200 w-full transition-all focus:bg-white focus:border hover:bg-neutral-300 hover:border hover:border-blue hover:border-solid placeholder-bold"
            placeholder="Add task"
            value={newTask}
            onChange={handleInputChange}
            onKeyDown={handleKeyDown}
            maxLength={60}
            data-testid="addTaskTextarea"
          ></textarea>
          {filteredTasks.map((task) => (
            <div
              key={task.task_ID}
              className="group flex shadow-md mb-1 hover:outline-1 hover:outline-blue hover:outline hover:rounded hover:shadow-lg"
            >
              <div
                className={`flex items-center py-4 px-2 rounded-l ${
                  task.completed ? "bg-gray-400" : "bg-yellow-300"
                }`}
              >
                <div
                  id={`checkbox-${task.task_ID}`}
                  type="checkbox"
                  className={`w-8 h-8 cursor-pointer border-none active:border active:border-blue active:border-solid hover:bg-slate-50 rounded focus:ring-0 focus:ring-offset-0 ${
                    task.completed ? "bg-gray-100" : "bg-yellow-100"
                  }`}
                  onMouseEnter={() => handleMouseEnter(task)}
                  onMouseLeave={handleMouseLeave}
                  onClick={() => markTask(task.task_ID)}
                >
                  <div
                    className={`p-2 ${
                      hoveredTask === task || task.completed
                        ? "block"
                        : "hidden"
                    }`}
                  >
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16">
                      <path d="M6.54 13c-.3 0-.59-.13-.81-.35L2 8.75l1.62-1.69 2.86 2.98L12.26 3 14 4.56l-6.59 8.02c-.21.25-.51.4-.83.42h-.04z"></path>
                    </svg>
                  </div>
                </div>
              </div>
              <div
                className="bg-white rounded-r w-full p-2 overflow-hidden flex"
                data-testid={`task-${task.task_ID}`}
              >
                <div style={{ width: "calc(100% - 20px)" }}>
                  <p
                    className={`break-normal overflow-hidden ${
                      task.completed ? "text-gray-600" : ""
                    }`}
                  >
                    {task.title}
                  </p>
                  <p
                    className={`text-xs ${
                      task.completed ? "text-gray-400" : "text-gray-600"
                    }`}
                  >
                    {task.description}
                  </p>
                </div>
                <div
                  className="w-[20px] flex justify-end opacity-0 group-hover:opacity-100 transition-all duration-300"
                  onClick={() => deleteTask(task.task_ID)}
                >
                  <svg
                    color="red"
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    className="bi bi-trash cursor-pointer"
                    viewBox="0 0 16 16"
                  >
                    {" "}
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />{" "}
                    <path
                      fillRule="evenodd"
                      d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"
                    />{" "}
                  </svg>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </>
  );
}

export default TaskTable;
