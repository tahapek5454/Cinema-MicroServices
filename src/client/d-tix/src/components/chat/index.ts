import {Component} from 'vue-property-decorator';
import ChatMessage from './chatMessage/index.vue';
import Base from "@/utils/Base";
import {ChatEnum} from "@/models/enums/ChatEnum";
import { Repositories, RepositoryFactory } from '@/services/RepositoryFactory';
import { AssistantRepository } from '@/Repositories/AssistantRepository';
import { VoieceService } from '@/services/VoiceService';
import Modal from "@/components/modal/index.vue";
import MovieSelection from "@/components/movieSelection/index.vue";


const _assistantRepository  = RepositoryFactory(Repositories.AssistantRepository) as AssistantRepository;
const _voiceService = new VoieceService();
interface IConversation {
    msg:string | null;
    msgId:number | null;
    isReservation:boolean | null;
    type: ChatEnum | string | null;
}

@Component({
    components:{
        ChatMessage,
        Modal,
        MovieSelection
    }
})
export default class Chat extends Base {
    render = false;
    conversation: IConversation[] = [];
    isWriting: boolean = false;
    message:string|null = null;
    threadId:string|null = null;

    isOpenModal:boolean = false;


    created(): void {
        const self = this;
        this.threadId = null;

        if(_voiceService.Recognition){
            _voiceService.Recognition.onresult = (event: any) => {
                if(event && event.results[0][0] &&  event.results[0][0].transcript)
                    self.message = event.results[0][0].transcript;
            };
    
            _voiceService.Recognition.onerror  = (event: any) => {
                console.error("Tanıma hatası:", event.error);
            };
        }
  

        // this.conversation.push({
        //     msg: "Selamlar bugün nasılsın",
        //     msgId: 1,
        //     type: ChatEnum.User,

        // })
    }
    mounted() {
        this.$root.$on('chatOpen', ()=>{
            this.render = true;
        });   
    }

    destroyed() {
        this.$root.$off('chatOpen');
    }


    close(){
        this.render = false;
        this.message = null;
        this.threadId = null;
        this.conversation = [];
        this.$root.$emit('mascotOpen');
    }

    minimize(){
        this.render = false;
        this.$root.$emit('mascotOpen');
    }

    sendMessage(){
        this.isWriting = true;
        if(this.message == null){
            this.$toast.warning("Lütfen mesaj giriniz.");
            this.isWriting = false;
            return;
        }
        this.addUserMessage(false);
        const tempMessage = this.message;
        this.message = null;
        _assistantRepository.MovieAssistant({
            content: tempMessage as string,
            threadId: this.threadId
        })
        .then((response)=>{
            this.addAssistantMessage(response.message ? response.message : '', response.isReservation);
            this.threadId = response.threadId;
        })
        .catch((err)=>{
            console.log(err);
            this.$toast.error("Şu anda hizmet verememekteyiz.");
        })
        .finally(()=>this.isWriting=false);
    }

    addUserMessage(isReservation:boolean){
        this.conversation.push({
            msg: this.message as string,
            msgId: this.conversation.length + 1,
            type: ChatEnum.User,
            isReservation: isReservation
        });
    }

    addAssistantMessage(message:string, isReservation:boolean){
        this.conversation.push({
            msg: message,
            msgId: this.conversation.length + 1,
            type: ChatEnum.Assistant,
            isReservation: isReservation
        });
    }

    startListening(){
        if(_voiceService.Recognition){
            _voiceService.Recognition.start();
        }

    }
    stopListening(){
        if(_voiceService.Recognition){
            _voiceService.Recognition.stop();
        }
    }

}