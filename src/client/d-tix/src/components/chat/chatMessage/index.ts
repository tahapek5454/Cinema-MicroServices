import {Component, Prop, Vue} from 'vue-property-decorator';
import {ChatEnum} from "@/models/enums/ChatEnum";
import { VoieceService } from '@/services/VoiceService';
import Base from '@/utils/Base';


const _voiceService = new VoieceService();

@Component
export default class ChatMessage extends Base {
    @Prop()  msg!: string;
    @Prop()  msgId!: number;
    @Prop({default: false})  isReservation!: boolean;
    @Prop({default: ChatEnum.User})  type!: ChatEnum;

    isPlay: boolean = false;

    created(): void {
        const self = this;
        _voiceService.Speech.onend =  (ev: SpeechSynthesisEvent)=>{
            self.isPlay = false;
        };
    }
    mounted(): void {

    }
    destroyed(): void {

    }

    speech(){
        this.isPlay = true;
        _voiceService.textToSpeech(this.msg);
    }

    cancelSpeech(){
        this.isPlay = false;
        _voiceService.cancelTextToSpeech();
    }

    prepareReservation(){
        console.log("Rezervasyon hazirligi basladi.");
        this.$toast.success("İyi ilerilyorsun böyle devam et 🙃.");
    }


}