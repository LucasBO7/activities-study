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


_sendButton.addEventListener("click", function (event) {
    var userIdInserted = document.getElementById("connectionidInput").value;
    var messageInserted = document.getElementById("userMessageInput").value;

    connection.invoke("SendMessage", userIdInserted, messageInserted).catch(function (error) {
        return console.error(err.toString());
    })

    event.preventDefault();
})


////Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you
//    // should be aware of possible script injection concerns.
//    li.textContent = ${ user } says ${ message };
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});