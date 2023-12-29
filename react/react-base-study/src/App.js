import './App.css';
import Galeria from './Components/Galeria/Galeria';
import Titulo from './Components/Titulo/Titulo';
import TituloComObj from './Components/Titulo/TituloComObj';

function App() {
  const objeto = { nome: "maconha", bonita: "sim" };

  return (

    <div className="App">
      {/* 
      ================ COMPONENTE ================
      <h1>Página inicial</h1>
      <h3>Com parâmetros:</h3>
      <Titulo nome={objeto.nome} bonita={objeto.bonita} />

      <h3>Com obj:</h3>
      <TituloComObj objetoInserido={objeto} />
       */}

      <Galeria />
    </div>
  );
}

export default App;
