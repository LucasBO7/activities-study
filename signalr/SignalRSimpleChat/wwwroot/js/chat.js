"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var connectionId = document.getElementById("mineIdLabel");
var _sendButton = document.getElementById("sendMessageBtn");

_sendButton.disabled = true;

connection.start().then(function () {
    _sendButton.disabled = false;
    connection.invoke("GetUserConnectionId")
        .then(function (id) {
            connectionId.textContent = id;
            console.log("ConnectionId: " + id);
        });
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (message) {
    const li = document.createElement("li");
    li.textContent = message;
    document.getElementById("messagesList").appendChild(li);
})

connection.on("UserConnected", function (connectionId) {
    const userConnectedId = document.createElement("li");
    userConnectedId.textContent = connectionId;
    document.getElementById("usersList").appendChild(userConnectedId);
})


_sendButton.addEventListener("click", function (event) {
    var userIdInserted = document.getElementById("connectionidInput").value;
    var messageInserted = document.getElementById("userMessageInput").value;

    connection.invoke("SendMessage", userIdInserted, messageInserted).catch(function (error) {
        return console.error(err.toString());
    })

    event.preventDefault();
})