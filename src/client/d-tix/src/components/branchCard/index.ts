import {Component, Prop, Vue} from 'vue-property-decorator';
import Base from "@/utils/Base";
import BranchDto from "@/models/branch/BranchDto";


@Component
export default class BranchCard extends Base {
    @Prop() private branche: BranchDto;


    created(): void {
    }

    destroyed(): void {
    }

    mounted(): void {
    }


}