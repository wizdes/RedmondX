exports.post = function(request, response) {
    var push = request.service.push;
    var message = request.body;
    var usersInRoomsTable = request.service.tables.getTable('usersinroom');
    var usersTable = request.service.tables.getTable('users');
    usersInRoomsTable.where(
        { room_id: message.room_id })
            .read(
                {
                    success: function(results)
                    {
                        for(var i =0; i< results.length; i++)
                        {
                            usersTable.where( {username: results[i].username}).read(
                            {
                                success: function(users)
                                {
                                    push.mpns.sendRaw(
                                        users[0].notification_url,
                                        {
                                            payload: message
                                        });
                                }                            
                            });
                        }   
                    }
                });
            
    response.send(statusCodes.OK);
};

exports.get = function(request, response) {
    response.send(statusCodes.OK, { message : 'Hello World!' });
};