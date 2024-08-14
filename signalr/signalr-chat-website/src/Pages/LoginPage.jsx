import React, { Component, useState } from 'react'
import { Text, View } from 'react-native'

export const LoginPage = () => {
    const [user, setUser] = useState({
        id: 0,
        name: "",
        connectionId: "",
        messages: []
    });

    const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7216/chatHub")
        .build();

    connection.start().then(() => {
        // connection.invoke("GetUserConnectionId")
    });

    connection.on("UserConnected", function (userConnectionId) {
        if (userConnectionId)
            setUser({ ...user, connectionId: userConnectionId });

        
    })

    return (
        <>
            <h1>Login</h1>
            <input
                type="text"
                placeholder='Nome do usuário...'
                onChange={txt => setUser(...user, { name: txt.target.value })}
            />
            <button>Logar</button>
        </>
    );
}