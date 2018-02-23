const express = require('express');
const http = require('http');
const WebSocket = require('ws');
const uuidv1 = require('uuid/v1');

const app = express();
const server = http.createServer(app);
const wss = new WebSocket.Server({ server });
var InitializeMessage = [];
var Camp = [
    {color: 'Orange',isUsed: false}, 
    {color :'Blue',isUsed: false}, 
    {color: 'Green',isUsed: false}, 
    {color: 'Purple',isUsed: false}
];
var Position = [
    {x: 0, y: 0, isUsed: false},
    {x: 50, y: 50, isUsed: false},
    {x: 100, y: 100, isUsed: false},
    {x: 150, y: 150, isUsed: false}
]
var AllPlayerPosition = [];

wss.broadcast = function broadcast(data) {
    wss.clients.forEach(function each(client) {
      if (client.readyState === WebSocket.OPEN) {
        client.send(data);
      }
    });
  };

wss.on('connection', function(conn) {
    console.log('a user has connected');
    InitializeMessage.forEach(element => {
        var OtherMessage = {
            Type: 'OtherInitializeMessage',
            Message: JSON.stringify(element)
        };
        console.log('send others' + JSON.stringify(OtherMessage));
        conn.send(JSON.stringify(OtherMessage));
    });
    while(true) {
        var Init = {};
        var i = Math.round(Math.random() * 3);
        if(!Camp[i].isUsed) {
            Camp[i].isUsed = true;
            Init.Camp = Camp[i].color;
            while(true) {
                var j = Math.round(Math.random() * 3);
                if (!Position[j].isUsed) {
                    Position[j].isUsed = true;
                    var HingePosition = {
                        x: Position[j].x,
                        y: Position[j].y
                    }
                    var PlayerPosition = {
                        x: Position[j].x + 10,
                        y: Position[j].y + 10
                    }
                    Init.HingePosition = JSON.stringify(HingePosition);
                    Init.PlayerPosition = JSON.stringify(PlayerPosition);
                    Init.PlayerID = uuidv1();
                    Init.HingeID = uuidv1();
                    var OwnInitializeMessage = {
                        Type: 'InitializeMessage',
                        Message: JSON.stringify(Init)
                    }
                    console.log('send own' + JSON.stringify(OwnInitializeMessage));
                    conn.send(JSON.stringify(OwnInitializeMessage));
                    InitializeMessage.push(Init);
                }
                break;
            }
            break;
        }
    }

    conn.on('message', function incoming(data) {
        var messageBase = JSON.parse(data);
        switch (messageBase.Type) {
            case 'PlayerPosition':
                var flag = 0;
                var PP = JSON.parse(messageBase.Message);
                AllPlayerPosition.forEach(e => {
                    if (e.id == PP.id) {
                        e.x = PP.x;
                        e.y = PP.y;
                        flag = 1;
                    }
                });
                if (!flag) AllPlayerPosition.push(PP);
                AllPlayerPosition.forEach(e => {
                    if (e.id != PP.id) {
                        wss.broadcast(JSON.stringify(e));
                    }
                })
            break;
        }
    })

    conn.on('close', function(e) {
        console.log('client close');
    });
    conn.on("error", function (code, reason) {
        console.log("异常关闭")
    });
})
server.listen(2222, function(){
    console.log('listening on *:2222');
});