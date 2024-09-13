import './App.css';
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';
import { useEffect, useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { MessagesList } from './Components/MessagesList';

const App = () => {
  const [connection, setConnection] = useState(null);
  const [message, setMessage] = useState("");
  const [allMessages, setAllMessages] = useState([]);

  const startConnection = async () => {
    try {
      // Cria objeto HubConnection
      const conn = new HubConnectionBuilder()
        .withUrl("http://localhost:5005/chat")
        .configureLogging(LogLevel.Information)
        .build();

      // Inicia a conexão
      await conn.start();

      // Guarda a conexão no state
      setConnection(conn);
    } catch (error) {
      console.log(error);
    }
  }

  const handleReceiveMessage = () => {
    if (connection) {
      connection.on("ReceiveMessage", (username, msg) => {
        setAllMessages(prevState => [...prevState, { username, msg }]);
        // setAllMessages();
      });
    }
  }

  useEffect(() => {
    startConnection();
  }, [])

  useEffect(() => {
    handleReceiveMessage()
  }, [connection])

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
                connection.invoke("SendMessageForAll", message.user, message.text);
              }}>Enviar mensagem para todos</button>

            </Col>
          </Row>
        </Container>
        <MessagesList messages={allMessages} />
      </main>
    </div >
  );
}

export default App;
