import {
  filterTasksByRecurring,
  filterTasksByTitle,
} from "../utils/Filters/taskFilters.jsx";
import { useState, useEffect } from "react";
import useFetch from "../hooks/useFetch.jsx";
import { getRewards, getTasksByUser } from "../utils/api.jsx";
import NavBar from "../components/NavBar.jsx";
import SearchBar from "../components/SearchBar.jsx";
import LabelButton from "../components/Labels.jsx";
import TaskTable from "../components/TaskTable.jsx";
import RewardTable from "../components/RewardTable.jsx";
import ErrorDisplay from "../components/ErrorDisplay.jsx";
import keycloak from "../utils/Keycloak.jsx";
import { useTaskContext } from "../hooks/TaskContext.jsx";

function HomePage() {
  const taskContext = useTaskContext();
  const [tasks, setTask] = useState(null);
  const [rewards, setRewards] = useState(null);
  const [errorHeader, setErrorHeader] = useState(null);
  const [errorBody, setErrorBody] = useState(null);
  const [loading, setLoading] = useState(true);

  const {
    data: Gettasks,
    loading: loadingTasks,
    errorHeader: errorHeaderTasks,
    errorBody: errorBodyTasks,
  } = useFetch(getTasksByUser, "tasks", keycloak.subject);
  const {
    data: Getrewards,
    loading: loadingRewards,
    errorHeader: errorHeaderRewards,
    errorBody: errorBodyRewards,
  } = useFetch(getRewards, "rewards");

  useEffect(() => {
    setTask(Gettasks);

    if (taskContext.tasks.length !== 0) {
      setTask(taskContext.tasks);
    }

    setRewards(Getrewards);
    if ((loadingTasks && loadingRewards) == false) {
      setLoading(false);
    }
    if (errorHeaderTasks || errorHeaderRewards) {
      let errMessage = "";
      errMessage += errorHeaderTasks || errorHeaderRewards;
      setErrorHeader(errMessage);
    }
    if (errorBodyTasks || errorBodyRewards) {
      let errMessage = "";
      if (errorBodyTasks) {
        errMessage += errorBodyTasks;
      }
      if (errorBodyRewards) {
        if (errorBodyTasks) {
          errMessage += " ";
        }
        errMessage += errorBodyRewards;
      }
      setErrorBody(errMessage);
    }
  }, [Getrewards, Gettasks, loadingTasks, loadingRewards, taskContext.tasks]);

  const [searchQuery, setSearchQuery] = useState("");
  const recurringTasks = filterTasksByRecurring(tasks, true);
  const todoTasks = filterTasksByRecurring(tasks, false);
  const searchedRecurringTasks = filterTasksByTitle(
    recurringTasks,
    searchQuery
  );
  const searchedTodoTasks = filterTasksByTitle(todoTasks, searchQuery);

  return (
    <>
      {loading ? (
        <div className="h-screen blue flex justify-center content-center items-center">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-1/4 animate-pulse"
            alt="LogoLoading"
          />
        </div>
      ) : (
        <>
          <NavBar title="tasks" />
          <div className="p-4 bg-slate-50 h-[93vh]">
            <div className="flex justify-center gap-5">
              <SearchBar setSearchQuery={setSearchQuery} />
              <LabelButton />
            </div>
            {errorHeader !== null ? (
              <ErrorDisplay errorHeader={errorHeader} errorBody={errorBody} />
            ) : (
              <div className="grid-cols-3 grid">
                <TaskTable tasks={searchedRecurringTasks} title="Recurring" />
                <TaskTable tasks={searchedTodoTasks} title="To do" />
                <RewardTable rewards={rewards} title="Rewards" />
              </div>
            )}
          </div>
        </>
      )}
    </>
  );
}

export default HomePage;
