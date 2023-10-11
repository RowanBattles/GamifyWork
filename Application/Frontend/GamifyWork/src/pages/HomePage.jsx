import NavBar from "../components/NavBar";
import SearchBar from "../components/SearchBar";
import LabelButton from "../components/Labels";

function HomePage() {
  return (
    <>
      <NavBar />
      <div className="p-4 flex justify-center bg-slate-200">
        <SearchBar />
        <LabelButton />
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
