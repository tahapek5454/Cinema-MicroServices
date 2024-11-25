import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './index.css'
import './plugins/toastification.ts'
import './plugins/myPlugin.ts'
import './plugins/BusPlugin.ts'
import vuetify from './plugins/vuetify'
import VueDragResize from 'vue-drag-resize'

Vue.component('vue-drag-resize', VueDragResize)



Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
