exports.post = function(request, response) {
    var usersTable = request.service.tables.getTable('Users');
    var item = {
        username : request.body.username,
        notification_url:request.body.notification_url,
        is_active: request.body.is_active
    };

    var userid = request.body.id;
    if (userid == null)
    {        
        usersTable.insert(item,
        {
            success: function(createdUser)
            {
                response.send(statusCodes.OK, createdUser);
            }
        });
    }
    else
    {
        item["id"] = userid;
        usersTable.update(item,
        {
            success: function(createdUser)
            {
                response.send(statusCodes.OK, createdUser);
            }
        });
    }
};

exports.get = function(request, response) {
    response.send(statusCodes.OK, {message: "blah"});
};