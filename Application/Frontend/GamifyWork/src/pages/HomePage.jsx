import React, { useState, useEffect } from "react";
import getTasks from "../utils/api";
import NavBar from "../components/NavBar";
import SearchBar from "../components/SearchBar";
import LabelButton from "../components/Labels";
import TaskTable from "../components/TaskTable";

function HomePage() {
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    async function fetchTasks() {
      try {
        const tasksFromServer = await getTasks(); // Await the promise
        setTasks(tasksFromServer);
      } catch (error) {
        console.error(error);
        // Handle errors, e.g., show an error message to the user
      }
    }

    fetchTasks();
  }, []);

  return (
    <>
      <NavBar />
      <div className="p-4 bg-slate-50 h-screen">
        <div className="flex justify-center gap-5">
          <SearchBar />
          <LabelButton />
        </div>
        <div className="columns-3">
          <TaskTable tasks={tasks} title="Recurring" />
          <TaskTable tasks={tasks} title="To do" />
          <TaskTable tasks={tasks} title="Rewards" />
        </div>
      </div>
    </>
  );
}

export default HomePage;

{
  /*       
import TaskTable from "../components/TaskTable";
import getTasks from "../utils/api";

      const [tasks, setTasks] = useState([]);

      <div>
        {tasks.length > 0 && <TaskTable tasks={tasks} setTasks={setTasks} />}
      </div>
      <button
        onClick={() => getTasks(setTasks)}
        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full"
      >
        Get all tasks
      </button>*/
}
