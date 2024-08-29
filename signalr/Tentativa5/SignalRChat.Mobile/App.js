import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { useEffect, useState } from 'react';
import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

// class WebSocketSignalR {
//   static async initSocketConnection(callback) {
//     if (!this.connection) {
//       this.connection = await new signalR.HubConnectionBuilder()
//         .withUrl(`http://localhost:5057/chatHub`, {
//           skipNegotiation: true,
//           transport: signalR.HttpTransportType.WebSockets
//         })
//         .withAutomaticReconnect()
//         .withHubProtocol(new signalR.JsonHubProtocol())
//         .configureLogging(signalR.LogLevel.Information)
//         .build();

//       WebSocketSignalR.startConnection(callback);
//     }
//   }

//   static startConnection(callback = undefined) {
//     Object.defineProperty(WebSocket, 'OPEN', { value: 1 });
//     this.connection
//       .start()
//       .then(callback)
//       .catch(() => setTimeout(() => WebSocketSignalR.startConnection(), 5000));
//   }

//   static onReceiveMessage(name, callback) {
//     this.connection.on(name, callback);
//   }

//   static unsubscribeMessage(name, callback) {
//     this.connection.off(name, callback);
//   }
// }


export default function App() {
  // const [socketConnectionReady, setSocketConnectionReady] = useState(false);

  // useEffect(() => {
  //   // const connection = new signalR.HubConnectionBuilder()
  //   //   .withUrl('http://localhost:5057/chatHub')
  //   //   .configureLogging(signalR.LogLevel.Information)
  //   //   .build();

  //   // // const proxy = connection.createHubProxy('chatHub');

  //   // connection.on("ReceiveMessage", (user, message) => {
  //   //   console.log('Mensagem recebida: ', user, message);
  //   // })

  //   // async function startConnection() {
  //   //   try {
  //   //     await connection.start();
  //   //     console.log("Conexão iniciada");
  //   //   } catch (err) {
  //   //     console.error(err);
  //   //   }
  //   // }

  //   // startConnection();


  //   // if (!socketConnectionReady) {
  //   //   const connection = new signalR.HubConnectionBuilder()
  //   //     .withUrl("https://LinkOfTheEndPoin", {
  //   //       accessTokenFactory: () => 'JWT_TOKEN_HERE',
  //   //     })
  //   //     .withAutomaticReconnect()
  //   //     .configureLogging(signalR.LogLevel.Information)
  //   //     .build();

  //   //   connection.start();

  //   //   connection.on("send", data => {
  //   //     console.log(data);
  //   //   });

  //   //   connection.start()
  //   //     .then(() => connection.invoke("send", "Hello"));

  //   //   // WebSocketSignalR.initSocketConnection(() => {
  //   //   //   setSocketConnectionReady(true)
  //   //   // })
  //   // }

  //   // socketConnectionReady && WebSocketSignalR.onReceiveMessage('ReceiveMessage', async function (user, message) {
  //   //   console.log(user, message);
  //   // });


  // }, []);


  const [hubConnection, setHubConnection] = useState();

  useEffect(() => {
    createHubConnection();
  }, [])

  const createHubConnection = async () => {
    const hubConnection = new HubConnectionBuilder()
    .withUrl("http://localhost:5057/chathub")
    .build();
    try {
      await hubConnection.start();
      console.log('Conectado!');
    } catch (error) {
      console.log("error: ", error);
    }
  }



  return (
    <View style={styles.container}>
      <Text>Open up App.js to start working on your app!</Text>
      <StatusBar style="auto" />

      {/* {socketConnectionReady && (
        <Text>Conectou!</Text>
      )} */}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
