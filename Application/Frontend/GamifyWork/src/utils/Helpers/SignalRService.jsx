// signalRService.js
import { HubConnectionBuilder } from "@microsoft/signalr";

class SignalRService {
  connection = null;

  startConnection = () => {
    this.connection = new HubConnectionBuilder()
      .withUrl("https://localhost:7017/chathub")
      .build();

    this.connection.start().then(() => {
      console.log("SignalR connected");
    });
  };

  stopConnection = () => {
    this.connection.stop();
  };

  receiveMessage = (callback) => {
    this.connection.on("ReceiveMessage", (message) => {
      callback(message);
    });
  };

  sendMessage = (message) => {
    this.connection.invoke("SendMessage", message);
  };
}

const signalRService = new SignalRService();
export default signalRService;
