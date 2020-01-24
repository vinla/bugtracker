import Vuex from 'vuex'
import Vue from 'vue'
import usersService from "./services/usersService"

Vue.use(Vuex)

const state = {
    users: []
}

const getters = {
    users: state => {
        return state.users;
    }
}

const actions = {
    loadUsers ({commit}) {
        usersService.listUsers().then(d => commit('setUsers', d));
    }
}

const mutations = {
    setUsers (state, users) {
        state.users = users;
    }
}

export default new Vuex.Store({
  state,
  getters,
  actions,
  mutations
})
