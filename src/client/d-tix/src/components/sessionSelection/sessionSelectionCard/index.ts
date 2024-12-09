import { Component, Vue, Watch,Prop } from 'vue-property-decorator';
import Base from "@/utils/Base";
import MovieDto from "@/models/movies/MovieDto";
import {BaseImagePath} from "@/constDatas";
import SessionDto from '@/models/session/SessionDto';


@Component
export default class SessionSelectionCard extends Base {
    @Prop({default: null})  session!: SessionDto;
    @Prop({default: false})  isSelected!: boolean;


    get GetTime(){
        const date = new Date(this.session.date);
        return `${date.getHours()}:${date.getMinutes()}`;
    }
    created(): void {

    }

    destroyed(): void {
    }

    mounted(): void {
    }

    selectSession(){
        this.$emit('selectSession', this.session.id)
    }

}