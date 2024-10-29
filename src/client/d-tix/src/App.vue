<template>
  <div id="app">
    <!-- <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </nav> -->
    <v-app>
      <Spinner/>
      <Navbar/>
      <div class="tw-text-gray-light">
        <router-view/>
      </div>
      <ChatMascot/>
      <Chat/>
      <BaseFooter class="tw-text-gray-light"></BaseFooter>

    </v-app>
  </div>
</template>

<script>
import { Component, Vue } from 'vue-property-decorator';
import Navbar from '@/components/navbar/index.vue'; // @, /src'ye karşılık gelir
import BaseFooter from '@/components/baseFooter/index.vue';
import Chat from '@/components/chat/index.vue';
import ChatMascot from '@/components/chat/chatMascot/index.vue';
import Spinner from '@/components/spinner/index.vue';


@Component({
  components: {
    Navbar,
    BaseFooter,
    Chat,
    ChatMascot,
    Spinner
  },
})
export default class App extends Vue {

}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  cursor: url('/public/cursor/dmate.png') 16 16, auto;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}


::-webkit-scrollbar {
  width: 20px;
}

::-webkit-scrollbar-track {
  background-color: #111111;
}


::-webkit-scrollbar-thumb {
  background-color: #000000;
}


::-webkit-scrollbar-thumb {
  background-color: #000000;
  border-radius: 20px;
}


::-webkit-scrollbar-thumb {
  background-color: #000000;
  border-radius: 20px;
  border: 6px solid transparent;
  background-clip: content-box;
}


::-webkit-scrollbar-thumb:hover {

background-color: #535353;

}

</style>
