import {Component, Prop} from 'vue-property-decorator';
import Base from "@/utils/Base";
import MovieDto from "@/models/movies/MovieDto";
import {BaseImagePath} from "@/constDatas";


@Component
export default class MovieSelectionCard extends Base {
    @Prop({default: null})  movie!: MovieDto;
    @Prop({default: false})  isSelected!: boolean;



    get ImageValue(): string{
        if(!(this.movie.movieImages && this.movie.movieImages.length))
            return ``;

        return `${BaseImagePath}/${this.movie.movieImages[0].fileName}`;
    }

    get TimeValue(): string {
        const result = this.splitDouble(this.movie?.time as number);
        return `${result.integerPart} saat ${result.decimalPart} dakika.`;
    }
    created(): void {

    }

    destroyed(): void {
    }

    mounted(): void {
    }

    selecteMovie(){
        this.$emit('selectMovie', this.movie.id)
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