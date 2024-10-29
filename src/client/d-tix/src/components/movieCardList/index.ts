import { Component, Prop, Vue } from 'vue-property-decorator';
import MovieCard from '@/components/movieCard/index.vue'; // @, /src'ye karşılık gelir
import { Repositories, RepositoryFactory } from '@/services/RepositoryFactory';
import { MovieRepository } from '@/Repositories/MovieRepository';
import MovieDto from '@/models/movies/MovieDto';
import Base from "@/utils/Base";

const _movieRepository = RepositoryFactory(Repositories.MovieRepository) as MovieRepository;

@Component({
    components: {
      MovieCard
    },
})
export default class MovieCardList extends Base {
    @Prop({ default: false }) hasAnimation!: boolean;

    movies: MovieDto[] = [];
    animation_status: Animation_Status = Animation_Status.Running;

     created() {
        this.showLoading();
        _movieRepository.GetMoviesWithPagination()
        .then(r => {
            this.movies = r.data;
        })
        .finally(()=>this.hideLoading());
    }

    mounted() {
      this.animationSettings();   
    }

    destroyed(): void {
    }
    animationSettings(){
        const scroller = this.$refs.scroller as any;

        const scrollerInner = scroller.querySelector(".scroller__inner");
        const scrollerContent = Array.from(scrollerInner.children) as any;
    
        scrollerContent.forEach((item:any) => {
            const duplicatedItem = item.cloneNode(true);
            duplicatedItem.setAttribute("aria-hidden", true);
            scrollerInner.appendChild(duplicatedItem);
        });
    }
 
    pauseAnimation(){
        this.animation_status = Animation_Status.Paused;
    }

    resumeAnimation(){
        this.animation_status = Animation_Status.Running;
    }


}



export enum Animation_Status{
    Running = 'running',
    Paused = 'paused',
}