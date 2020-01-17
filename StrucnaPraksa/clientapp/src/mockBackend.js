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
                user: 'fabijan',
            }
        }
        if (username === "test" && pw === "test") {
            return {
                token: "TESTT_TEST__TOKEN",
                admin: false,
                user: "test",
            }
        }
        else {
            return null;
        }
    },
    register(username, password) {
        if(username === '' && password === '') {
            return null;
        } else {
            users.push(
                {
                    username,
                    password,
                }
            );
            return true;
        }
    }
}

export default mockBackEnd;
