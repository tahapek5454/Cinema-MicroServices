import {Component, Prop, Vue} from 'vue-property-decorator';
import {BaseImagePath} from "@/constDatas";
import MovieDto from "@/models/movies/MovieDto";
import Base from "@/utils/Base";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {MovieRepository} from "@/Repositories/MovieRepository";

const _movieRepository = RepositoryFactory(Repositories.MovieRepository) as MovieRepository;

@Component({
    components:{

    }
})
export default class TicketSummary extends Base {

     movie: MovieDto  = new MovieDto();
     created() {
         this.showLoading();
         _movieRepository.GetMovieById("7")
             .then(r => {
                 this.movie = r;
             })
             .finally(()=>this.hideLoading());

     }
     mounted(){

     }
     destroyed()  {

     }

    get ImageValue(): string{
        if(!(this.movie.movieImages && this.movie.movieImages.length))
            return ``;

        return `${BaseImagePath}/${this.movie.movieImages[0].fileName}`;
    }

    get TimeValue(): string {
        const result = this.splitDouble(this.movie?.time as number);
        return `${result.integerPart} saat ${result.decimalPart} dakika.`;
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
}