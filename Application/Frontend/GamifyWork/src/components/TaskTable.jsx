import React, { useState } from "react";
import { filterTasksByStatus } from "../utils/Filters/taskFilters";
import { CreateTask, MarkTask, getTasksByUser } from "../utils/api";
import { failed, succes } from "../utils/Helpers/toast";
import { useTaskContext } from "../hooks/TaskContext";
import usePatch from "../hooks/usePatch";
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

  const handleKeyDown = async (event) => {
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
          failed("failed creating task");
        }

        try {
          const updatedTasks = await getTasksByUser(keycloak.subject);
          updateTasks(updatedTasks);
        } catch {
          failed("failed updating tasks");
        }
      }
      event.target.blur();
    }
  };

  const markTask = async (id) => {
    try {
      await usePatch(MarkTask, id, "tasks");
      const updatedTasks = await getTasksByUser(keycloak.subject);
      updateTasks(updatedTasks);
    } catch (err) {
      failed("failed marking task");
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
          <div className="text-lg font-bold">{title}</div>
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
          ></textarea>
          {filteredTasks.map((task) => (
            <div key={task.task_ID}>
              <div className="flex shadow-md mb-1 hover:outline-1 hover:outline-blue hover:outline hover:rounded hover:shadow-lg">
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
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 16 16"
                      >
                        <path d="M6.54 13c-.3 0-.59-.13-.81-.35L2 8.75l1.62-1.69 2.86 2.98L12.26 3 14 4.56l-6.59 8.02c-.21.25-.51.4-.83.42h-.04z"></path>
                      </svg>
                    </div>
                  </div>
                </div>
                <div className="bg-white rounded-r w-full p-2 overflow-hidden">
                  <p
                    className={`break-normal ${
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
              </div>
            </div>
          ))}
        </div>
      </div>
    </>
  );
}

export default TaskTable;
