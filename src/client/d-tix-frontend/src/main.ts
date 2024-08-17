import './assets/main.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import '@mdi/font/css/materialdesignicons.css'
import { createApp } from 'vue'
import vuetify from '../vuetify.config';

import 'vuetify/styles';

import App from './App.vue'
import router from './router'


const app = createApp(App)

app.use(router)

app.use(vuetify);

app.mount('#app')
