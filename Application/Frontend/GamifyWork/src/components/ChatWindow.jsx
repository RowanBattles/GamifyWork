import { useRef, useEffect, useState } from "react";
import signalRService from "../utils/Helpers/SignalRService";
import { useKeycloak } from "@react-keycloak/web";
import { filterMessagesByUsers } from "../utils/Filters/messageFilters";
import PropTypes from "prop-types";

function ChatWindow({ selectedFriend }) {
  ChatWindow.propTypes = {
    selectedFriend: PropTypes.shape({
      username: PropTypes.string,
      user_ID: PropTypes.string.isRequired,
    }),
  };

  const [scrollButton, setScrollButton] = useState(false);
  const [scrollToBottomValue, setScrollToBottom] = useState(false);
  const { keycloak } = useKeycloak();
  const messageInputRef = useRef();
  const messageListRef = useRef();
  const [messages, setMessages] = useState([]);
  const [filteredMessages, setFilteredMessages] = useState([]);

  useEffect(() => {
    signalRService.startConnection();

    signalRService.receiveMessage((message) => {
      setMessages((prevMessages) => {
        const AllMessages = [...prevMessages, message];
        filterMessages(AllMessages);
        return AllMessages;
      });
    });

    if (messages.length !== 0) {
      filterMessages(messages);
    }

    setTimeout(() => {
      scrollToBottom();
    }, 10);

    return () => {
      signalRService.stopConnection();
    };
  }, [selectedFriend]);

  useEffect(() => {
    if (scrollToBottomValue) {
      setScrollToBottom(false);
      setTimeout(() => {
        scrollToBottom();
      }, 100);
    }
  }, [scrollToBottomValue]);

  useEffect(() => {
    if (selectedFriend) {
      if (scrollButton) {
        setScrollButton(true);
      }
      setTimeout(() => {
        CalculateScrollBoolean();
      }, 101);

      messageListRef.current.addEventListener("scroll", CalculateScrollBoolean);

      return () => {
        if (messageListRef.current != null) {
          messageListRef.current.removeEventListener(
            "scroll",
            CalculateScrollBoolean
          );
          setScrollButton(false);
        }
      };
    }
  }, [selectedFriend, filteredMessages]);

  const filterMessages = (messages) => {
    if (selectedFriend !== null) {
      setFilteredMessages(
        filterMessagesByUsers(
          messages,
          keycloak.subject,
          selectedFriend.user_ID
        )
      );
    }
  };

  const sendMessage = () => {
    const message = messageInputRef.current.value;
    if (
      message !== "" &&
      selectedFriend &&
      signalRService.connection.state === "Connected"
    ) {
      const messageModel = {
        UserSender: keycloak.subject,
        UserReceiver: selectedFriend.user_ID,
        Message: message,
      };
      signalRService.sendMessage(messageModel);
      messageInputRef.current.value = "";
      setScrollToBottom(true);
    }
  };

  const handleKeyDown = (event) => {
    if (event.key === "Enter") {
      event.preventDefault();
      sendMessage();
    }
  };

  const scrollToBottom = () => {
    if (messageListRef.current) {
      messageListRef.current.scrollTop = messageListRef.current.scrollHeight;
    }
  };

  const CalculateScrollBoolean = () => {
    const isScrolledToBottom =
      messageListRef.current.scrollHeight - messageListRef.current.scrollTop <=
      messageListRef.current.clientHeight + 51;

    setScrollButton(!isScrolledToBottom);
  };

  return (
    <div className="w-2/3 bg-slate-50 p-8 flex flex-col">
      <div className="flex justify-between font-medium text-2xl mb-6 items-center">
        <span>Chat</span>
        {selectedFriend && (
          <div className="flex gap-5">
            <img
              src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
              className="h-9 w-9 bg-gray-300 rounded-full p-1"
            />
            {selectedFriend.username == null ? (
              <span className="text-gray-400 italic">undefinied</span>
            ) : (
              <span>{selectedFriend.username}</span>
            )}
          </div>
        )}
      </div>
      <div className="relative w-full bg-white flex-grow mb-5 min-h-[200px] rounded-md border border-gray-300">
        {selectedFriend ? (
          <ul
            className="overflow-y-auto no-scrollbar h-full relative"
            ref={messageListRef}
          >
            {filteredMessages.map((msg, index) => (
              <li
                key={index}
                className={`px-4 py-1 flex gap-5 items-center ${
                  msg.userSender === keycloak.subject ? "justify-end" : ""
                }`}
              >
                {msg.userSender !== keycloak.subject && (
                  <img
                    src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
                    className="h-9 w-9 bg-gray-300 rounded-full p-1"
                  />
                )}
                <p
                  className={`text-xl p-2 rounded-md ${
                    msg.userSender === keycloak.subject
                      ? "bg-blue-600 text-white"
                      : "bg-gray-100"
                  }`}
                >
                  {msg.message}
                </p>
                {msg.userSender === keycloak.subject && (
                  <img
                    src="https://cdn-icons-png.flaticon.com/512/666/666201.png"
                    className="h-9 w-9 bg-gray-300 rounded-full p-1"
                  />
                )}
              </li>
            ))}
          </ul>
        ) : (
          <div className="w-full h-full bg-slate-200"></div>
        )}
        {scrollButton && (
          <div className="w-10 h-10 absolute bottom-2 right-5 rounded-full">
            <button className="blue p-3 rounded-full" onClick={scrollToBottom}>
              <img
                src="https://d29fhpw069ctt2.cloudfront.net/icon/image/39091/preview.png"
                className="invert h-full w-full"
              />
            </button>
          </div>
        )}
      </div>
      <input
        ref={messageInputRef}
        className="w-full py-2 px-3 rounded-md text-lg border border-gray-300 outline-none focus:border-blue transition-colors mb-8"
        placeholder="Type a message"
        onKeyDown={handleKeyDown}
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
