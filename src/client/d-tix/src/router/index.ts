import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import HomeView from '../views/home/index.vue'
import MovieDetailView from '@/views/movieDetail/index.vue'
import PlayGroundView from '@/views/playGround/index.vue'
import AuthView from '@/views/auth/index.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/auth',
    name: 'auth',
    component: AuthView
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/about/index.vue')
  },
  {
    path: '/movieDetail',
    name: 'movieDetail',
    component: MovieDetailView
  },
  {
    path: '/playground',
    name: 'playground',
    component: PlayGroundView
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
