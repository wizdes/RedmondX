exports.post = function(request, response) {
    var messageTypes = { PlayerJoinedRoom : 0, TradeCard : 1 };
    var usersInRoomsTable = request.service.tables.getTable('usersinroom');
    var usersTable = request.service.tables.getTable('users');
    var body = request.body;
    var item = { room_name: body.roomName, username:body.username};
    var push = request.service.push;
    usersInRoomsTable.insert(
        item,
        { success: function(userAddedToRoom)
            {
                sendNotificationToUsers();
            }
        });
    
    function sendNotificationToUsers()
    {
        var mssql = request.service.mssql;
        var sqlQuery = "SELECT username, notification_url from users WHERE username IN (SELECT username from usersinroom where room_name = ?)";
        mssql.query(
            sqlQuery,
            body.roomName,
            {
                success: function(currentUsersInRoom)
                {

                    if (currentUsersInRoom.length > 0)
                    {
                        var message = JSON.stringify(
                        { 
                            type : "PlayerJoinedRoom",
                            content: body.username
                        });

                        var s="";
                        for(var i = 0; i < currentUsersInRoom.length; i++)
                        {
                            if (currentUsersInRoom[i].username != body.username)
                            {
                                console.log("Will try sending message to " + currentUsersInRoom[i].username);
                                
                                push.mpns.sendRaw(
                                    currentUsersInRoom[i].notification_url, 
                                    {
                                        payload: message
                                    });
                                    
                                s  = s.concat(currentUsersInRoom[i].username.concat(","));
                            }                            
                        }
                    }                    
                    
                    var resp = { users: s};                             
                    response.send(200, resp);
                }
            });
    }
}

exports.get = function(request, response) {
    response.send(statusCodes.OK, { message : 'Hello World!' });
};

exports.del = function(request, response) {
    var usersInRoomsTable = request.service.tables.getTable('Usersinroom');
    var body = request.body;
    var item = { room_id: body.room_id, username:body.username};
    usersInRoomsTable.del(item);
    response.send(statusCodes.OK);
}