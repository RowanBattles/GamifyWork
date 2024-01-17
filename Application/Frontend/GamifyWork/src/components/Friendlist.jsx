import { useEffect, useState } from "react";
import { Blocks } from "react-loader-spinner";
import useFetch from "../hooks/useFetch";
import { getFriends } from "../utils/api";
import ErrorDisplay from "./ErrorDisplay";
import { useKeycloak } from "@react-keycloak/web";

function Friendlist({ selectedFriend, setSelectedFriend }) {
  const { keycloak } = useKeycloak();
  const [friends, setFriends] = useState([]);
  const [loadingState, setLoadingState] = useState(true);
  const [ErrorHeader, setErrorHeader] = useState(null);
  const [ErrorBody, setErrorBody] = useState(null);

  const { data, loading, errorHeader, errorBody } = useFetch(
    getFriends,
    "Friends",
    keycloak.subject
  );

  useEffect(() => {
    setFriends(data);
    setLoadingState(loading);
    setErrorBody(errorBody);
    setErrorHeader(errorHeader);
  }, [data, loading, errorHeader, errorBody]);

  const handleFriendSelection = (friend) => {
    setSelectedFriend(friend);
  };

  return (
    <div className="w-1/3 p-8 border-r-2 border-gray-200 flex flex-col">
      <p className="text-2xl font-medium mb-8">Friends</p>
      <input
        className="w-full py-2 px-3 rounded-md text-lg border border-gray-300 outline-none focus:border-blue transition-colors mb-8"
        placeholder="Search username..."
      />
      {loadingState ? (
        <div className="flex justify-center">
          <Blocks height="150" width="150" ariaLabel="blocks-loading" />
        </div>
      ) : (
        <>
          {ErrorHeader && ErrorBody ? (
            <>
              <ErrorDisplay errorHeader={ErrorHeader} errorBody={ErrorBody} />
            </>
          ) : (
            <>
              {friends.length == 0 ? (
                <p>No friends available</p>
              ) : (
                <ul className="overflow-y-auto grid gap-1">
                  {friends.map((u) => (
                    <li
                      key={u.user_ID}
                      className={`w-full cursor-pointer rounded-md border hover:border-blue hover:shadow-md ${
                        selectedFriend == u
                          ? "bg-blue-100 border-blue"
                          : "bg-white border-gray-300"
                      }`}
                      onClick={() => handleFriendSelection(u)}
                    >
                      <div className="p-6 flex gap-5">
                        <img
                          src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
                          className="h-12 w-12 bg-gray-300 rounded-full p-1"
                        />
                        <div className="grid text-md">
                          {u.username == null ? (
                            <span className="text-gray-500 font-semibold italic">
                              undefinied
                            </span>
                          ) : (
                            <span className="font-semibold">{u.username}</span>
                          )}
                          <span className="text-gray-400">offline</span>
                        </div>
                      </div>
                    </li>
                  ))}
                </ul>
              )}
            </>
          )}
        </>
      )}
    </div>
  );
}

export default Friendlist;
