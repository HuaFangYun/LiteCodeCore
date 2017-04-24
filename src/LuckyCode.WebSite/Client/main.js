import Vue from 'vue'
import VueRouter from 'vue-router'
import VueAxios from 'vue-axios'
import axios from 'axios'
import App from './app.vue';
import { routes, loginPath } from './routes'
import store from './vuex/store'
import shared from './views/shared'


Object.keys(shared).forEach((key) => {
    var name = key.replace(/(\w)/, (v) => v.toUpperCase()); //首字母大写
    Vue.component(`ss${name}`, shared[key]);
});

Vue.use(VueRouter);
Vue.use(VueAxios, axios);


axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';

//axios.interceptors.request.use(config => {
//    if (store.state.user) {
//        config.headers.Authorization = `token ${store.state.user.token}`;
//    }
//    return config;
//}, err => {
//    return Promise.reject(err);
//});

let router = new VueRouter({
    mode: "history",
    routes
});

//router.beforeEach(({meta, path}, from, next) => {
//    var { auth = true } = meta;
//    var isLogin = store.state.user && store.state.user.id;
//    if (auth && !isLogin && path !== loginPath) {
//        return next({ path: loginPath });
//    }
//    next();
//});

var vm = new Vue({
    store,
    router,
    render: h => h(App)
});
vm.$mount('#app');

export default router