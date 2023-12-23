import React from "react";
import NavBar from "../components/NavBar";
import Friendlist from "../components/Friendlist";
import ChatWindow from "../components/ChatWindow";

function FriendsPage() {
  return (
    <>
      <NavBar title="friends" />
      <div className="flex bg-slate-50 h-[calc(100vh-56px)]">
        <Friendlist />
        <ChatWindow />
      </div>
    </>
  );
}

export default FriendsPage;
