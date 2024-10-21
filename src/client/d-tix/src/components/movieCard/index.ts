import { BaseImagePath } from '@/constDatas';
import MovieDto from '@/models/movies/MovieDto';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class MovieCard extends Vue {
  @Prop() movie!: MovieDto;
  @Prop({ default: false }) isDetail!: boolean;


  get TimeValue(): string {
    const result = this.splitDouble(this.movie.time);
    return `${result.integerPart} saat ${result.decimalPart} dakika.`;
  }

  get ImageValue(): string{
    if(!(this.movie.movieImages && this.movie.movieImages.length))
      return ``;

    return `${BaseImagePath}/${this.movie.movieImages[0].fileName}`;
  }

  goToDetail(){
    this.$router.push({path:'/movieDetail'});
  }

  goToTicketBuy(){
    this.$router.push({path:'/ticketBuy'});
  }

  private splitDouble(value: number): { integerPart: number, decimalPart: number } {
    const integerPart = Math.floor(value);
    const decimalPart = Math.round((value - integerPart) * 100);
    
    return {
        integerPart,
        decimalPart
    };
}
}