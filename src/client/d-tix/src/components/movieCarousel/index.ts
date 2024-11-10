import { Component, Vue, Watch } from 'vue-property-decorator';
import Base from "@/utils/Base";

@Component
export default class MovieCarousel extends Base {
    selectedIndex : number = 0
    selectedIndex2 : number = 0
    available = true;
    isSmooth: boolean = true;
    timeoutId: number | null = null;
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
        this.basePath2+'alien.png',
        this.basePath2+'dw.jpg',
    ]

    get translateX(){
        return `-${this.selectedIndex * 100}%`
    }

    get translateX2(){
        return `-${this.selectedIndex2 * 125}%`
    }

    startTimeout() {
        const self = this;
        this.timeoutId = window.setTimeout(() => {
            self.next();
        }, 5000);
    }

    resetTimeout() {
        if (this.timeoutId !== null) {
            clearTimeout(this.timeoutId);
        }
        this.startTimeout();
    }

    mounted() {

        this.startTimeout();
    }

    next(){
        if(!this.available)
            return;

        this.resetTimeout();
        this.available = false;
        if(this.selectedIndex === this.slides.length - 1)
            this.selectedIndex = 0;
        else
            this.selectedIndex++;

        this.isSmooth = true;
        this.selectedIndex2++;
    }

    async handleTransitionEnd(){

        if(this.selectedIndex2 == this.slides.length){
            this.isSmooth = false;
            this.selectedIndex2 = 0;
            await new Promise(resolve => setTimeout(resolve, 200));
        }

        this.available = true;
    }

    previous(){
        if(!this.available)
            return;

        this.resetTimeout();
        this.available = false;
        if(this.selectedIndex === 0){
            this.selectedIndex = this.slides.length - 1;
            this.selectedIndex2 = this.slides.length - 1;
        }

        else{
            this.selectedIndex--;
            this.selectedIndex2--;
        }

    }

    created(): void {
    }

    destroyed(): void {
        if (this.timeoutId != null || this.timeoutId != 0) {
            clearTimeout(this.timeoutId as number);
        }
    }

}