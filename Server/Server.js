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

wss.broadcastElse = function broadcastElse(data, conn) {
    wss.clients.forEach(function each(client) {
        if (client !== conn && client.readyState === WebSocket.OPEN) {
          client.send(data);
        }
      });
}

wss.on('connection', function(conn) {
    console.log('a user has connected');
    var id = uuidv1();
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
                    Init.id = id;
                    var OwnInitializeMessage = {
                        Type: 'InitializeMessage',
                        Message: JSON.stringify(Init)
                    }
                    var GiveOther = {
                        Type: 'OtherInitializeMessage',
                        Message: JSON.stringify(Init)
                    }
                    console.log('send own' + JSON.stringify(OwnInitializeMessage));
                    console.log('send others' + JSON.stringify(GiveOther))
                    conn.send(JSON.stringify(OwnInitializeMessage));
                    wss.broadcastElse(JSON.stringify(GiveOther), conn);
                    InitializeMessage.forEach(e => {
                        var GetOthers = {
                            Type: 'OtherInitializeMessage',
                            Message: JSON.stringify(e)
                        }
                        console.log('get others' + JSON.stringify(GetOthers));
                        conn.send(JSON.stringify(GetOthers));
                    })
                    InitializeMessage.push(Init);
                    break;
                }
            }
            break;
        }
    }

    conn.on('message', function incoming(data) {
        var messageBase = JSON.parse(data);
        switch (messageBase.Type) {
            case 'PlayerPosition':
                wss.broadcastElse(data, conn);
            break;
            case 'SendBulletMessage':
                console.log(messageBase);
                var SBM = JSON.parse(messageBase.Message);
                var camp;
                InitializeMessage.forEach(e => {
                    if (e.PlayerID === SBM.ShooterID)
                        camp = e.Camp;
                });
                var message = {
                    Camp: camp,
                    StartPosition: SBM.StartPosition,
                    TargetID: SBM.TargetID
                }
                var SendBulletMessage = {
                    Type: 'BulletMessage',
                    Message: JSON.stringify(message)
                }
                wss.broadcastElse(JSON.stringify(SendBulletMessage), conn);
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