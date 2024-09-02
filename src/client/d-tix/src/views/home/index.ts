import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/helloWorld/index.vue'; // @, /src'ye karşılık gelir
import MovieCarousel from '@/components/movieCarousel/index.vue'; // @, /src'ye karşılık gelir
import MovieCardList from '@/components/movieCardList/index.vue'; // @, /src'ye karşılık gelir

@Component({
  components: {
    HelloWorld,
    MovieCarousel,
    MovieCardList
  },
})
export default class HomeView extends Vue {}