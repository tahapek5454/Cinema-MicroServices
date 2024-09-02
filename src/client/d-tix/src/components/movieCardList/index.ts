import { Component, Vue } from 'vue-property-decorator';
import MovieCard from '@/components/movieCard/index.vue'; // @, /src'ye karşılık gelir

@Component({
    components: {
      MovieCard
    },
})
export default class MovieCardList extends Vue {
    basePath: string = '/movieCardImages/';
    movieList: string[] = [
        this.basePath+'alien.png',
        this.basePath+'bayi.webp',
        this.basePath+'dw.jpg',
        this.basePath+'garfield.jpg',
        this.basePath+'tersyuz.png',
        this.basePath+'thor.jpg',
        this.basePath+'transformers.webp',
        this.basePath+'dw2.jpg',
        this.basePath+'damat.webp',
        this.basePath+'bergen.jpg',
        this.basePath+'rafa.webp'
    ]

}