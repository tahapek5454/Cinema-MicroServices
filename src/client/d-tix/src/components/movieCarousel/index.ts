import { Component, Vue } from 'vue-property-decorator';

@Component
export default class MovieCarousel extends Vue {
    selectedIndex : number = 0
    basePath: string = '/movieImages/';
    slides: string[] = [
        this.basePath+'batman.jpg',
        this.basePath+'cars.jpg',
        this.basePath+'kraven.jpg',
        this.basePath+'morbius.jpg',
        this.basePath+'spiderman.jpg',
    ]

    mounted() {
        setInterval(()=>{
            this.next();
        }, 5000)   
    }

    next(){
        if(this.selectedIndex === this.slides.length - 1)
            this.selectedIndex = 0;
        else
            this.selectedIndex++;
    }

    previous(){
        if(this.selectedIndex === 0)
            this.selectedIndex = this.slides.length - 1;
        else
            this.selectedIndex--;
    }

}