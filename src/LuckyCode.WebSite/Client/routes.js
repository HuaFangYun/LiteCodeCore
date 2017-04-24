import HomeView from './views/Home.vue';
import NewsView from './views/News.vue';
export const routes = [{
    name: 'home',
    path: '/home',
    component: HomeView,
}, {
    name: 'news',
    path: '/news',
    component: NewsView
}];