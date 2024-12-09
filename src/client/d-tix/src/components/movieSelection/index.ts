import {Component, Prop} from 'vue-property-decorator';
import Base from "@/utils/Base";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {MovieRepository} from "@/Repositories/MovieRepository";
import MovieDto from "@/models/movies/MovieDto";
import MovieSelectionCard from "@/components/movieSelection/movieSelectionCard/index.vue";
import BranchDto from "@/models/branch/BranchDto";

const _movieRepository = RepositoryFactory(Repositories.MovieRepository) as MovieRepository;


interface MovieSelectionCardModel{
    movie:MovieDto;
    isSelected:boolean;
}

@Component({
    components:{
        MovieSelectionCard
    }
})
export default class MovieSelection extends Base {
    @Prop({default: null})  movieId!: number;

    movieSelectionCardDatas: MovieSelectionCardModel [] = [];
    itemCount: number = 0;

    created(): void {
        this.showLoading();
        _movieRepository.GetAllMovies()
            .then((r)=>{
                this.itemCount = r.length;
                r.forEach(item => {
                    this.movieSelectionCardDatas.push({
                        movie :item,
                        isSelected : false,
                    });
                });

                if(this.movieId){
                    _movieRepository.GetMovieById(''+this.movieId as string)
                        .then(r => {
                            this.selectMovie(r.id);
                        });
                }
            })
            .finally(()=> this.hideLoading());
    }

    destroyed(): void {
    }

    mounted(): void {
    }

    selectMovie(id:number){
        let oldSelectionMovie = this.movieSelectionCardDatas.find(x=> x.isSelected);
        let newSelectionMovie  = this.movieSelectionCardDatas.find(x => x.movie.id == id);

        if(!oldSelectionMovie && newSelectionMovie){
            newSelectionMovie.isSelected = true;
            this.$emit('selectMovieForReservation', id);
            return;
        }

        if(oldSelectionMovie && newSelectionMovie){
            if(oldSelectionMovie.movie.id == newSelectionMovie.movie.id){
                return;
            }else{
                oldSelectionMovie.isSelected = false;
                newSelectionMovie.isSelected = true;
                this.$emit('selectMovieForReservation', id);
            }
        }
        return;
    }
}