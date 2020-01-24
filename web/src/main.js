import Vue from 'vue';
import VueResource from 'vue-resource';
import router from './router';
import modal from './modal';
import App from './App.vue';
import axios from 'axios';
import store from './store';
import '@/assets/main.css';

Vue.use(VueResource);
Vue.use(modal);

Vue.config.productionTip = false;
axios.defaults.baseURL = "http://localhost:5000/v1/api";

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app');
