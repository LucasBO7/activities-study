import logo from './logo.svg';
import './App.css';
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';
import { useEffect, useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { MessagesList } from './Components/MessagesList';

function App() {
  const [connection, setConnection] = useState();
  const [message, setMessage] = useState("");
  const [allMessages, setAllMessages] = useState([]);
  const [isConnected, setIsConnected] = useState(false);

  const joinChatRoom = async (username = "Batata", chatroom = "1") => {
    try {
      const conn = new HubConnectionBuilder()
        .withUrl("http://localhost:5005/chat")
        .configureLogging(LogLevel.Information)
        .build();

      // Set up handler
      conn.on("JoinSpecificChatRoom", (username, msg) => {
        alert("msg: ", msg);
      })

      await conn.start();
      await conn.invoke("JoinSpecificChatRoom", {
        username: username,
        chatroom: chatroom
      });

      setConnection(connection);
    } catch (e) {
      console.log(e);
    }
  }

  useEffect(() => {
    async function OnConnectedUser() {
      try {
        const conn = new HubConnectionBuilder()
          .withUrl("http://localhost:5005/chat")
          .configureLogging(LogLevel.Information)
          .build();

        // Set up handler
        conn.on("ReceiveMessage", (username, msg) => {
          if (!isConnected) {
            // alert(`Conectado! ${username}: ${msg}`);
            setIsConnected(true);
          } else {
            setAllMessages([...allMessages, { username, msg }]);
          }
        })

        await conn.start();
        if (!connection)
          setConnection(conn);
      } catch (e) {
        console.log(e);
      }
    }
    OnConnectedUser();
  }, []);

  return (
    <div className="App">
      <main>
        <Container>
          <Row className='px-5 my-5'>
            <Col sm='12'>
              <h1 className='font-weight-light'>Chat com SignalR</h1>

              {/* User Input */}
              <label htmlFor="user-input">Usuário</label>
              <input id='user-input' value={message.user} onChange={e => setMessage({ ...message, user: e.target.value })} />

              {/* Message Input */}
              <label htmlFor="message-input">Mensagem</label>
              <input id='message-input' value={message.text} onChange={e => setMessage({ ...message, text: e.target.value })} />

              <button onClick={() => {
                connection.invoke("SendMessageForAll", message.text);
              }}>Enviar mensagem para todos</button>

              <MessagesList messages={allMessages} />
            </Col>
          </Row>
        </Container>
      </main>
    </div >
  );
}

export default App;
