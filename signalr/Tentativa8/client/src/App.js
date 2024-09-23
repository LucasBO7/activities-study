import './App.css';
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Container } from 'react-bootstrap';
import { useEffect, useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { MessagesList } from './Components/MessagesList';
import { LoginForm, RegisterForm } from './Components/AuthForm';
import api from './Services/Service';

const App = () => {
  const [connection, setConnection] = useState(null);
  const [message, setMessage] = useState("");
  const [connectedUsers, setConnectedUsers] = useState([]);
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
      connection.on("ReceiveMessage", (user, msg) => {
        setAllMessages(prevState => [...prevState, { user, msg }]);
      });

      connection.on("OnConnectedUser", (admin, message) => {
        setConnectedUsers(prevState => [...prevState, { user: admin, msg: message }]);
      })
    }
  }

  const sendEventToServer = (props) => {
    if (connection) {
      connection.invoke("SendMessageForAll", props.user, props.text);
    }
  }

  useEffect(() => {
    alert("Conexão iniciada!");
    startConnection();
  }, [])

  useEffect(() => {
    handleReceiveMessage();
  }, [connection])


  // User Actions
  const [user, setUser] = useState({});

  const RegisterUser = async (prop) => {
    await api.post("/users", {
      id: Date.now().toLocaleString(),
      connectionId: 0,
      name: prop.name,
      password: prop.password,
    })
      .then(response => alert("Usuário cadastrado com sucesso!"))
      .catch(error => alert("Houve um erro! ", error))
  }

  const LoginUser = () => {

  }

  return (
    <div className="App">
      <main>
        {/* User Actions */}
        <Container className='bg-gray'>
          <RegisterForm onSubmitForm={RegisterUser} user={user} setUser={setUser} />
          <LoginForm onSubmitForm={LoginUser} user={user} setUser={setUser} />
        </Container>


        {/* Messages Actions */}
        <Container>
          <h1 className='font-weight-light'>Chat com SignalR</h1>

          {/* User Input */}
          <label htmlFor="user-input">Usuário</label>
          <input id='user-input' value={message.user} onChange={e => setMessage({ ...message, user: e.target.value })} />

          {/* Message Input */}
          <label htmlFor="message-input">Mensagem</label>
          <input id='message-input' value={message.text} onChange={e => setMessage({ ...message, text: e.target.value })} />

          <button onClick={() => sendEventToServer(message)}>Enviar mensagem para todos</button>

          <MessagesList messages={connectedUsers} />
        </Container>
        <MessagesList messages={allMessages} />
      </main>
    </div >
  );
}

export default App;
