import { Component, Vue } from 'vue-property-decorator';

@Component
export default class MovieCarousel extends Vue {
    selectedIndex : number = 0
    basePath: string = '/movieImages/';
    basePath2: string = '/movieCardImages/';
    slides: string[] = [
        this.basePath+'dp.jpg',
        this.basePath+'avengers.jpg',
        this.basePath+'kraven.jpg',
        this.basePath+'aslan.jpg',
        this.basePath+'venom.jpg',
    ]

    slides2: string[] = [
        this.basePath2+'alien.png',
        this.basePath2+'dw.jpg',
        this.basePath2+'dw2.jpg',
        this.basePath2+'garfield.jpg',
        this.basePath2+'thor.jpg',
    ]

    get translateX(){
        return `-${this.selectedIndex * 100}%`
    }

    get translateX2(){
        return `-${this.selectedIndex * 125}%`
    }

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