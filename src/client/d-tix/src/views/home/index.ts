import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/helloWorld/index.vue'; // @, /src'ye karşılık gelir

@Component({
  components: {
    HelloWorld,
  },
})
export default class HomeView extends Vue {}