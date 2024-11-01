import { Component, Prop, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";

@Component
export default class Modal extends Base {
    @Prop({default:false}) isOpen!: boolean;

    created(): void {

    }

    destroyed(): void {
    }

    mounted(): void {

    }
}