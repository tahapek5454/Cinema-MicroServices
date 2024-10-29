import { Component, Prop, Vue } from 'vue-property-decorator';
import MovieCard from '@/components/movieCard/index.vue';
import MovieEntries from '@/components/movieEntries/index.vue';
import { Repositories, RepositoryFactory } from '@/services/RepositoryFactory';
import { MovieRepository } from '@/Repositories/MovieRepository';
import MovieDto from '@/models/movies/MovieDto';
import Base from "@/utils/Base";

const _movieRepository = RepositoryFactory(Repositories.MovieRepository) as MovieRepository;
@Component({
    components:{
        MovieCard,
        MovieEntries
    }
})
export default class MovieDetailView extends Base {
  @Prop() private msg!: string;
  
  movie : MovieDto | null = null;

  get DateValue():string{
    return this.textDate(this.movie?.createdDate as Date)
  }

  get TimeValue(): string {
    const result = this.splitDouble(this.movie?.time as number);
    return `${result.integerPart} saat ${result.decimalPart} dakika.`;
  }


  created() {
    const id = this.$route.query.id as string;
    this.showLoading();
    _movieRepository.GetMovieById(id)
    .then(r => {
      this.movie = r;
    })
    .finally(()=>this.hideLoading());
  }

  destroyed(): void {
  }

  mounted(): void {
  }
  goToTicketBuy(){
    this.$router.push({path:'/ticketBuy'});
  }


  private splitDouble(value: number): { integerPart: number, decimalPart: number } {

    if(value == null)
      return {
        integerPart:0,decimalPart:0
    }

    const integerPart = Math.floor(value);
    const decimalPart = Math.round((value - integerPart) * 100);
    
    return {
        integerPart,
        decimalPart
    };
  }

  private textDate(date: Date){

    if(date == null)
      return new Date().toDateString();

    const d = new Date(date);

    return d.toDateString();
  }


}