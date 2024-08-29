import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { StatusBar } from 'expo-status-bar';
import { useEffect } from 'react';
import { Alert, StyleSheet, Text, View } from 'react-native';

export default function App() {

  // async function joinChatFunction() {
  //   Alert("Entrou!");
  //   const connection = HubConnectionBuilder()
  //     .withUrl('http://localhost:5057/chathub')
  //     .configureLogging(LogLevel.Information)
  //     .build();

  //   // set up handler
  //   connection.on("ReceiveMessage", (user, message) => {
  //     Alert("Send:  ", user, message);
  //   });

  //   await connection.start();
  // }

  const joinChat = async () => {
    try {
      console.log('CHUPA MEU PAU');
      // Alert("Entrou!");
      const connection = await HubConnectionBuilder()
        .withUrl('http://localhost:5057/chathub')
        .configureLogging(LogLevel.Information)
        .build();

      // set up handler
      connection.on("ReceiveMessage", (user, message) => {
        console.log('Send: ', user, message);
      });

      await connection.start();
    } catch (error) {
      console.log(error);
    }
  }

  useEffect(() => {
    joinChat();
  }, [])

  return (
    <View style={styles.container}>
      <Text>Open up App.js to start working on your app!</Text>
      <StatusBar style="auto" />
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
