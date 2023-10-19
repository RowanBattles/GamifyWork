import { filterTasksByRecurring } from "../utils/filters/taskFilters";
import useFetch from "../hooks/useFetch";
import getTasks from "../utils/api";
import NavBar from "../components/NavBar";
import SearchBar from "../components/SearchBar";
import LabelButton from "../components/Labels";
import TaskTable from "../components/TaskTable";

function HomePage() {
  const { data: tasks, loading, error } = useFetch(getTasks);
  const recurringTasks = filterTasksByRecurring(tasks, true);
  const todoTasks = filterTasksByRecurring(tasks, false);

  return (
    <>
      {loading ? (
        <div className="h-screen blue flex justify-center content-center items-center">
          <img
            src="/src/assets/GamifyWorkLogoWhite.png"
            className="h-1/4 animate-pulse"
          />
        </div>
      ) : (
        <>
          <NavBar />
          <div className="p-4 bg-slate-50 h-screen">
            <div className="flex justify-center gap-5">
              <SearchBar />
              <LabelButton />
            </div>
            {error !== null ? (
              <div>{error}</div>
            ) : (
              <div className="columns-3">
                <TaskTable tasks={recurringTasks} title="Recurring" />
                <TaskTable tasks={todoTasks} title="To do" />
                <TaskTable tasks={tasks} title="Rewards" />
              </div>
            )}
          </div>
        </>
      )}
    </>
  );
}

export default HomePage;
