import React, { useEffect, useState } from "react";
import OpenAI from "openai";

// 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
const key = "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";
const org = "jarvis_tech";

// EM toda requisição HTTP, deve ser passado a key no "Authorization"
// Authorization: Bearer OPENAI_API_KEY

// lucasbianchezzi700
// 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

// lucasbo.notes@gmail.com / Saculeoeht*01
// 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

const HomePage = () => {
    const [requestResponse, setRequestResponse] = useState();

    // useEffect(() => {

    // }, [requestResponse])

    const openai = new OpenAI({ apiKey: key, dangerouslyAllowBrowser: true });
    async function doRequest() {
        unableButton();
        const completion = await openai.chat.completions.create({
            messages: [
                {
                    role: "system",
                    content: "Mensagem do sistema padrão."
                },
                { role: "user", content: "Quem venceu a copa de 2018?" }
            ],
            model: "gpt-3.5-turbo",
            // response_format: { type: "json_object" }
        });

        setRequestResponse(completion.choices[0].message.content);
        ableButton();
    }


    function unableButton() {
        const botao = document.getElementById("botao");
        botao.style.display = "none";
    }

    function ableButton() {
        const botao = document.getElementById("botao");
        botao.style.display = "block";
    }

    return (
        <div>
            <h1>Página inicial</h1>

            <button id="botao" onClick={() => { doRequest() }}>Fazer requisição</button>
            <p>{requestResponse}</p>
        </div>
    );
};

export default HomePage;