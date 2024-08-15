import { HubConnectionBuilder } from "@microsoft/signalr";
import { StatusBar } from "expo-status-bar";
import { useEffect, useState } from "react";
import { StyleSheet, Text, TextInput, View } from "react-native";
import { WebSocketSignalR } from "./Classes/WebSocketSignalRClass";

export default function App() {
  const [socketConnectionReady, setSocketConnectionReady] = useState(false);

  const [user, setUser] = useState({
    id: 0,
    name: "",
    connectionId: "",
    messages: [],
  });

  useEffect(() => {
    if (!socketConnectionReady) {
      WebSocketSignalR.initSocketConnection(() => {
        setSocketConnectionReady(true);
      });
    }
  }, []);

  // const connection = new HubConnectionBuilder()
  //   .withUrl("http://localhost:5180/chatHub")
  //   .build();

  // connection
  //   .start()
  //   .then(() => console.log("Connected to SignalR hub"))
  //   .catch((err) => console.error("Error connecting to hub:", err));

  // connection.on("UserConnected", (message) => {
  //   console.log("Received message:", message);
  // });

  // connection.start().then(() => {
  //   // connection.invoke("GetUserConnectionId")
  // });

  // connection.on("UserConnected", function (userConnectionId) {
  //   console.log("Mensagem recebida: ", userConnectionId);
  //   if (userConnectionId) setUser({ ...user, connectionId: userConnectionId });
  // });

  return (
    <View style={styles.container}>
      {socketConnectionReady && (
        <>
          <Text>Login!</Text>
          <Text>{user.connectionId}</Text>

          <TextInput placeholder="Nome do usuário..."></TextInput>
        </>
      )}
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
