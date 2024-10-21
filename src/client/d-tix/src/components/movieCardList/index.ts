import { Component, Prop, Vue } from 'vue-property-decorator';
import MovieCard from '@/components/movieCard/index.vue'; // @, /src'ye karşılık gelir

@Component({
    components: {
      MovieCard
    },
})
export default class MovieCardList extends Vue {
    @Prop({ default: false }) hasAnimation!: boolean;

    basePath: string = '/movieCardImages/';
    movieList: string[] = [
        this.basePath+'alien.png',
        this.basePath+'bayi.webp',
        this.basePath+'dw.jpg',
        this.basePath+'garfield.jpg',
        this.basePath+'tersyuz.png',
        this.basePath+'thor.jpg',
        this.basePath+'transformers.webp',
        this.basePath+'damat.webp',
        this.basePath+'bergen.jpg',
        this.basePath+'rafa.webp'
    ]
    animation_status: Animation_Status = Animation_Status.Running;

    mounted() {
      this.animationSettings();   
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