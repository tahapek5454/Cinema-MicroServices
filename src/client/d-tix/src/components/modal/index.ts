import { Component, Prop, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";

@Component
export default class Modal extends Base {
    @Prop({default:false}) isOpen!: boolean;
    @Prop({default:'tw-w-auto'}) witdh!: string;
    @Prop({default: 'tw-h-auto'}) height!: string;
    @Prop() center!: boolean;


    get WitdhMeasure(){
        return this.witdh;
    }

    get HeightMeasure(){
        return this.height;
    }

    created(): void {

    }

    destroyed(): void {
    }

    mounted(): void {

    }
}