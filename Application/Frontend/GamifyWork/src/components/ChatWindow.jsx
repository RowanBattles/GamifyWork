import { useRef, useEffect, useState } from "react";
import signalRService from "../utils/Helpers/SignalRService";
import { useKeycloak } from "@react-keycloak/web";

function ChatWindow() {
  const { keycloak } = useKeycloak();
  const messageInputRef = useRef();
  const [messages, setMessages] = useState([]);

  useEffect(() => {
    signalRService.startConnection();

    signalRService.receiveMessage((message) => {
      console.log("Received message:", message);
      setMessages((prevMessages) => [...prevMessages, message]);
    });
  }, []);

  const sendMessage = () => {
    const message = messageInputRef.current.value;
    if (message != "" && signalRService.connection.state == "Connected") {
      const user = keycloak.subject;
      signalRService.sendMessage({ user, message });
      messageInputRef.current.value = "";
    }
  };

  return (
    <div className="w-2/3 bg-slate-50 p-8 flex flex-col">
      <p className="font-medium text-2xl mb-8">Chat</p>
      <div className="w-full bg-white flex-grow mb-5 min-h-[200px] rounded-md border border-gray-300">
        <ul className="overflow-y-auto h-full">
          {messages.map((msg, index) => (
            <li
              key={index}
              className={`px-4 py-1 flex gap-5 items-center ${
                msg.user === keycloak.subject ? "justify-end" : ""
              }`}
            >
              {msg.user !== keycloak.subject && (
                <img
                  src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
                  className="h-9 w-9 bg-gray-300 rounded-full p-1"
                />
              )}
              <p
                className={`text-xl p-2 rounded-md ${
                  msg.user === keycloak.subject
                    ? "bg-blue-600 text-white"
                    : "bg-gray-100"
                }`}
              >
                {msg.message}
              </p>
              {msg.user === keycloak.subject && (
                <img
                  src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
                  className="h-9 w-9 bg-gray-300 rounded-full p-1"
                />
              )}
            </li>
          ))}
        </ul>
      </div>
      <input
        ref={messageInputRef}
        className="w-full py-2 px-3 rounded-md text-lg border border-gray-300 outline-none focus:border-blue transition-colors mb-8"
        placeholder="Type a message"
      />
      <button
        onClick={sendMessage}
        className="w-full bg-black text-white font-medium py-2 rounded-md text-2xl"
      >
        Send
      </button>
    </div>
  );
}

export default ChatWindow;
