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
    errorHeader: errorHeaderTasks,
    errorBody: errorBodyTasks,
  } = useFetch(getTasks, "tasks");
  const {
    data: rewards,
    loading: loadingRewards,
    errorHeader: errorHeaderRewards,
    errorBody: errorBodyRewards,
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
            {(errorHeaderTasks || errorHeaderRewards) !== null ? (
              <>
                <div className="border border-gray-400 bg-white border-solid mt-5 p-5">
                  <div className="text-red-500 font-extrabold text-2xl mb-2">
                    {errorHeaderTasks}
                  </div>
                  <div className="text-s font-semibold">
                    <div>{errorBodyTasks}</div>
                    <div>{errorBodyRewards}</div>
                  </div>
                </div>
                <span className="px-5">
                  Try again &nbsp;
                  <a
                    className="text-blue underline"
                    href="http://localhost:5173"
                  >
                    here
                  </a>
                  , or Contact Us about the problem.
                </span>
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
