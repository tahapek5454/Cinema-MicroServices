import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/helloWorld/index.vue'; // @, /src'ye karşılık gelir
import MovieCarousel from '@/components/movieCarousel/index.vue'; // @, /src'ye karşılık gelir
import MovieCardList from '@/components/movieCardList/index.vue'; // @, /src'ye karşılık gelir
import Campaign from '@/components/campaign/index.vue'; // @, /src'ye karşılık gelir
import MobileAdvertisement from '@/components/mobileAdvertisement/index.vue'; // @, /src'ye karşılık gelir

@Component({
  components: {
    HelloWorld,
    MovieCarousel,
    MovieCardList,
    Campaign,
    MobileAdvertisement
  },
})
export default class HomeView extends Vue {}