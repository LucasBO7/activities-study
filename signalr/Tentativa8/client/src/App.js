import logo from './logo.svg';
import './App.css';
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';
import { useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

function App() {
  const [connection, setConnection] = useState();

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

  return (
    <div className="App">
      <main>
        <Container>
          <Row className='px-5 my-5'>
            <Col sm='12'>
              <h1 className='font-weight-light'>Hello World!</h1>

              <button onClick={joinChatRoom}>Entrar</button>
            </Col>
          </Row>
        </Container>
      </main>
    </div>
  );
}

export default App;
