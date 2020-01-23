import Vuex from 'vuex'
import Vue from 'vue'

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

}

const mutations = {

}

export default new Vuex.Store({
  state,
  getters,
  actions,
  mutations
})
