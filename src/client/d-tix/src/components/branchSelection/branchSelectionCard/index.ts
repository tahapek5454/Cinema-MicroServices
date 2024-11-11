import {Component, Prop} from 'vue-property-decorator';
import Base from "@/utils/Base";
import MovieDto from "@/models/movies/MovieDto";
import {BaseImagePath} from "@/constDatas";
import BranchDto from '@/models/branch/BranchDto';


@Component
export default class BranchSelectionCard extends Base {
    @Prop({default: null})  branch!: BranchDto;
    @Prop({default: false})  isSelected!: boolean;

    created(): void {

    }

    destroyed(): void {
    }

    mounted(): void {
    }

    selecteBranch(){
        this.$emit('selectBranch', this.branch.id)
    }
}