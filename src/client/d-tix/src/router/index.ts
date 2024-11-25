import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import HomeView from '../views/home/index.vue'
import MovieDetailView from '@/views/movieDetail/index.vue'
import PlayGroundView from '@/views/playGround/index.vue'
import TicketBuy from '@/views/ticketBuy/index.vue'
import AuthView from '@/views/auth/index.vue'
import Categories from '@/views/categories/index.vue'
import Branches from "@/views/branches/index.vue";
import TicketBuyAlternative from "@/views/ticketBuyAlternative/index.vue";

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
  },
  {
    path: '/ticketBuy',
    name: 'ticketBuy',
    component: TicketBuyAlternative
  },
  {
    path: '/categories',
    name: 'categories',
    component: Categories
  },
  {
    path: '/branches',
    name: 'branches',
    component: Branches
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
