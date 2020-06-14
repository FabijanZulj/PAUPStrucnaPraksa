import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'pregled',
    component: () => import('../views/Pocetna.vue'),
  },
  {
    path: '/dokumenti',
    name: 'dokumenti',
    component: () =>
      import(/* webpackChunkName: "about" */ '../views/Dokumenti.vue'),
  },
  {
    path: '/adminPregled',
    name: 'adminPregled',
    component: () => import('../views/AdminPregled.vue'),
    beforeEnter: adminCheck,
  },
  {
    path: '/adminGraf',
    name: 'adminGraf',
    component: () => import('../views/AdminGraf.vue'),
    beforeEnter: adminCheck,
  },
];

function adminCheck(to, from, next) {
  if (localStorage.getItem('ADMIN') === 'Admin') {
    next();
  } else {
    next('/');
  }
}
const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
