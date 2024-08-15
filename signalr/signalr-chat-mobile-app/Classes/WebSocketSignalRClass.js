import * as signalR from "@microsoft/signalr";

export class WebSocketSignalR {
  static async initSocketConnection(callback) {
    if (!this.connection) {
      this.connection = await new signalR.HubConnectionBuilder()
        .withUrl(`http://localhost:5180/chatHub`, {
          skipNegotiation: true,
          transport: signalR.HttpTransportType.WebSockets,
        })
        .withAutomaticReconnect()
        .withHubProtocol(new signalR.JsonHubProtocol())
        .configureLogging(signalR.LogLevel.Information)
        .build();
      WebSocketSignalR.startConnection(callback);
    }
  }

  static startConnection(callback = undefined) {
    Object.defineProperty(WebSocket, "OPEN", { value: 1 }); // ISSO FARÁ COM QUE A NOSSA CONEXÃO PERMANEÇA SEMPRE ABERTA.
    this.connection
      .start()
      .then(callback)
      .catch(() => setTimeout(() => WebSocketSignalR.startConnection(), 5000));
  }

  static onReceiveMessage(name, callback) {
    this.connection.on(name, callback);
  }
}
