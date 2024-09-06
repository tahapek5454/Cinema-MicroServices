import { Component, Prop, Vue } from 'vue-property-decorator';
import MovieCard from '@/components/movieCard/index.vue';

@Component({
    components:{
        MovieCard
    }
})
export default class MovieDetailView extends Vue {
  @Prop() private msg!: string;

  basePath: string = '/movieCardImages/';
  moviePath: string= this.basePath+'dw.jpg';

  show(){
    this.$toast.success("Bilet aldın");
  }
}