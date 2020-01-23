import axios from "axios"

export default {
    createUser(userName) {
        return axios.post("users", {userName}).then(r => r.data);
    },
    updateUser(userId, userName) {
        return axios.patch(`users/${userId}`, {userName}).then(r => r.data);
    },
    listUsers() {
        return axios.get("users").then(r => r.data);
    }
}
