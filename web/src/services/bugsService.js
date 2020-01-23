import axios from "axios";

export default {
  createBug: function (title, description) {
    return axios.post("bugs", {title, description}).then(r => r.data);
  },
  listBugs: function() {
    return axios.get("bugs").then(r => r.data);
  },
  closeBug: function(bugId) {
    return axios.delete(`bugs/${bugId}`).then(r => r.data);
  },
  assignBug: function(bugId, userId) {
    return axios.post("bugs/${bugId}/assign", {userId}).then(r => r.data);
  }
}
