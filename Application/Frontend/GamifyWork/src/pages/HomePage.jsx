import {
  filterTasksByRecurring,
  filterTasksByTitle,
} from "../utils/Filters/taskFilters.jsx";
import { useState } from "react";
import useFetch from "../hooks/useFetch";
import { getTasks, getRewards } from "../utils/api";
import NavBar from "../components/NavBar";
import SearchBar from "../components/SearchBar";
import LabelButton from "../components/Labels";
import TaskTable from "../components/TaskTable";
import RewardTable from "../components/RewardTable.jsx";

function HomePage() {
  const {
    data: tasks,
    loading: loadingTasks,
    error: errorTasks,
  } = useFetch(getTasks, "tasks");
  const {
    data: rewards,
    loading: loadingRewards,
    error: errorRewards,
  } = useFetch(getRewards, "rewards");
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
          <div className="p-4 bg-slate-50 min-h-screen">
            <div className="flex justify-center gap-5">
              <SearchBar setSearchQuery={setSearchQuery} />
              <LabelButton />
            </div>
            {(errorTasks || errorRewards) !== null ? (
              <>
                <div>{errorTasks}</div>
                <div>{errorRewards}</div>
              </>
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
