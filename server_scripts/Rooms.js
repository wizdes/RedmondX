exports.post = function(request, response) {
    var roomsTable = request.service.tables.getTable('Rooms');
    var username = request.body.createdBy;
    var roomName = request.body.roomName;
    var roomItem = { room_name: roomName, createdBy:username, is_active: true };
    var result = roomsTable.insert(
        roomItem,
        { 
            success: function(insertedRoom)
            {
                var usersInRoomsTable = request.service.tables.getTable('usersinroom');
                var item = { room_name:roomName, username:username};
                usersInRoomsTable.insert(
                    item,
                    {
                        success: function(result)
                        {
                            response.send(statusCodes.OK, result);
                        }
                    });
            }
        });    
};

exports.get = function(request, response) {
    var roomsTable = request.service.tables.getTable('Rooms');
    var friendNames = request.query.friends;
    if (friendNames != undefined && friendNames != null)
    {
        
    }
    
    roomsTable.where( {is_active : true}).take(10).read(
        {
            success: function(results)
            {   
                response.send(200, results);
            }
        },
        {
            error: function(results)
            {
                console.log("error occurred while reading rooms.");
                response.send(200);
            }
        });
};