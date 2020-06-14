import Vue from 'vue';
import './plugins/bootstrap-vue';
import { BootstrapVueIcons } from 'bootstrap-vue';
import App from './App.vue';
import router from './router';
import axios from 'axios';
import VueApexCharts from 'vue-apexcharts';
Vue.use(VueApexCharts);
Vue.component('apexchart', VueApexCharts);

Vue.use(BootstrapVueIcons);
Vue.config.productionTip = false;
Vue.prototype.$axios = axios.create();
Vue.prototype.$axios.interceptors.request.use(function(config) {
  const token = localStorage.getItem('token');
  config.headers.Authorization = `Bearer ${token}`;

  return config;
});
new Vue({
  router,
  render: (h) => h(App),
}).$mount('#app');
