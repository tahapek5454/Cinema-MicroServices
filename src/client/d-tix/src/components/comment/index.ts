import { Component, Prop, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";
import MovieCommentDto from "@/models/comments/MovieCommentDto";

@Component({
    computed: {

    }
})
export default class MovieComment extends Base {
    @Prop()  comments!: MovieCommentDto[];


    created(): void {
    }

    destroyed(): void {
    }

    mounted(): void {
    }

    private textDate(date: Date){

        if(date == null)
            return new Date().toDateString();

        const d = new Date(date);

        return d.toDateString();
    }
}