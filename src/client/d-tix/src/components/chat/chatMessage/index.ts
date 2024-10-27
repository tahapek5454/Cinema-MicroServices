import {Component, Prop, Vue} from 'vue-property-decorator';
import {ChatEnum} from "@/models/enums/ChatEnum";


@Component
export default class ChatMessage extends Vue {
    @Prop()  msg!: string;
    @Prop()  msgId!: number;
    @Prop()  type!: ChatEnum;

}