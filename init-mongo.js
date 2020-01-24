db.createUser(
    {
        user: "bt_service",
        pwd: "bt_pwd",
        roles: [
            {
                role: "readWrite",
                db: "bugtracker"
            }
        ]
    }
)