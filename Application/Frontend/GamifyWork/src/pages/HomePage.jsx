import {
  filterTasksByRecurring,
  filterTasksByTitle,
} from "../utils/Filters/taskFilters.jsx";
import { useState } from "react";
import { useTaskContext } from "../hooks/TaskContext.jsx";
import useFetch from "../hooks/useFetch";
import { getRewards, getTasksByUser } from "../utils/api";
import NavBar from "../components/NavBar";
import SearchBar from "../components/SearchBar";
import LabelButton from "../components/Labels";
import TaskTable from "../components/TaskTable";
import RewardTable from "../components/RewardTable.jsx";
import ErrorDisplay from "../components/ErrorDisplay.jsx";
import keycloak from "../utils/Keycloak.jsx";

function HomePage() {
  const {
    data: tasks,
    loading: loadingTasks,
    errorHeader: errorHeaderTasks,
    errorBody: errorBodyTasks,
  } = useFetch(getTasksByUser, "tasks", keycloak.subject);
  const {
    data: rewards,
    loading: loadingRewards,
    errorHeader: errorHeaderRewards,
    errorBody: errorBodyRewards,
  } = useFetch(getRewards, "rewards");

  const context = useTaskContext();
  const contextTasks = context?.tasks || [];
  if (contextTasks === 0) {
    context.tasks = tasks;
  }

  const [searchQuery, setSearchQuery] = useState("");
  const recurringTasks = filterTasksByRecurring(contextTasks, true);
  const todoTasks = filterTasksByRecurring(contextTasks, false);
  const searchedRecurringTasks = filterTasksByTitle(
    recurringTasks,
    searchQuery
  );
  const searchedTodoTasks = filterTasksByTitle(todoTasks, searchQuery);

  return (
    <>
      {loadingTasks || loadingRewards ? (
        <div className="h-screen blue flex justify-center content-center items-center">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-1/4 animate-pulse"
            alt="LogoLoading"
          />
        </div>
      ) : (
        <>
          <NavBar />
          <div className="p-4 bg-slate-50 h-fit">
            <div className="flex justify-center gap-5">
              <SearchBar setSearchQuery={setSearchQuery} />
              <LabelButton />
            </div>
            {(errorHeaderTasks || errorHeaderRewards) !== null ? (
              <ErrorDisplay
                data-testid="error-display"
                errorHeader={errorHeaderTasks || errorHeaderRewards}
                errorBody={
                  (errorBodyTasks || "") + " " + (errorBodyRewards || "")
                }
              />
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
