const express = require('express');
const app = express();
const server = require('http').createServer(app);
const io = require('socket.io').listen(server);
const port = 3000;

io.on('connection', socket => {
    console.log('connected sucessfuly');
    socket.on('chat message', message => {
        console.log(message);
        io.emit('chat message', message); // emite a mensagem do evento 'chat message' que vem do cliente p todas as conexoes.
    });
});

server.listen(port, () => console.log(`server is running. port: ${port}`));