import React, { useState } from "react";
import NavBar from "../components/NavBar";
import Friendlist from "../components/Friendlist";
import ChatWindow from "../components/ChatWindow";

function FriendsPage() {
  const [selectedFriend, setSelectedFriend] = useState(null);

  return (
    <>
      <NavBar title="friends" />
      <div className="flex bg-slate-50 h-[calc(100vh-56px)]">
        <Friendlist
          selectedFriend={selectedFriend}
          setSelectedFriend={setSelectedFriend}
        />
        <ChatWindow selectedFriend={selectedFriend} />
      </div>
    </>
  );
}

export default FriendsPage;
