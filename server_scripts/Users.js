exports.post = function(request, response) {
    var usersTable = request.service.tables.getTable('Users');
    var item = {
        username : request.body.username,
        notification_url:request.body.notification_url,
        is_active: request.body.is_active
    };
    
    usersTable.insert(item,
     { success: function(createdUser)
        {
            response.send(statusCodes.OK, createdUser);
        }
     });
};

exports.get = function(request, response) {
    response.send(statusCodes.OK, {message: "blah"});
};