function TituloComObj({ objetoInserido }) {
    return (
        <div>
            <p>Nome: {objetoInserido.nome}</p>
            <p>Bonita?: {objetoInserido.bonita}</p>
        </div>
    );
}

export default TituloComObj;