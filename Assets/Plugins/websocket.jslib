var WebSocketLibrary = {
    $webSocket: {},
    SocketConnect: function (url) {
        var str = Pointer_stringify(url);
        webSocket = new WebSocket(str);
        webSocket.onopen = function (e) {
            SendMessage('WebSocketController', 'Open');
        };
        webSocket.onclose = function (e) {
            SendMessage('WebSocketController', 'Close');
        };
        webSocket.onmessage = function (e) {
            SendMessage('WebSocketController', 'OnMessage', e.data);
        }
    },
    SocketSendMessage: function (msg) {
        webSocket.send(Pointer_stringify(msg));
    },
    SocketClose: function () {
        webSocket.close();
    }

}
autoAddDeps(WebSocketLibrary, '$webSocket');
mergeInto(LibraryManager.library, WebSocketLibrary);