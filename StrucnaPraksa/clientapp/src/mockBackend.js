let users = [
    {
        username: 'fabijan',
        password: 'admin',
    },
    {
        username: 'test',
        password: 'test',
    }
]
const mockBackEnd = {
    getAllUsers() {
            return users;
    },
    login(username, pw) {
        if (username === "fabijan" && pw === "admin") {
            return {
                token: "TEST_TOKEN",
                admin: true,
            }
        }
        if (username === "test" && pw === "test") {
            return {
                token: "TESTT_TEST__TOKEN",
                admin: false,
            }
        }
        else {
            return null;
        }
    },
    register(username, password) {
        users.push(
            {
                username,
                password,
            }
        );
    }
}

export default mockBackEnd;
