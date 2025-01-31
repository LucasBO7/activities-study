import React, { useState } from 'react';

const Galeria = () => {
    const [valor, setValor] = useState(1);

    function AdicionarUm() {
        setValor(valor + 1);
    }

    return (
        <div>
            <p>{valor}</p>
            <button onClick={() => { AdicionarUm() }}>+1</button>
        </div>
    );
};

export default Galeria;