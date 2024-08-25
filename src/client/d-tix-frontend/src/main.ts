import './assets/main.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import '@mdi/font/css/materialdesignicons.css'
import { createApp } from 'vue'
import vuetify from '../vuetify.config';

import 'vuetify/styles';

import Vue3Toasity from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';
import customToastyConfig from '../customtoasity.config';

import App from './App.vue'
import router from './router'


const app = createApp(App)

app.use(router)

app.use(vuetify);

app.use(
    Vue3Toasity,
    customToastyConfig
  );

app.mount('#app')
