import {Component} from 'vue-property-decorator';
import ChatMessage from './chatMessage/index.vue';
import Base from "@/utils/Base";
import {ChatEnum} from "@/models/enums/ChatEnum";
import { Repositories, RepositoryFactory } from '@/services/RepositoryFactory';
import { AssistantRepository } from '@/Repositories/AssistantRepository';


const _assistantRepository  = RepositoryFactory(Repositories.AssistantRepository) as AssistantRepository;
interface IConversation {
    msg:string | null;
    msgId:number | null;
    type: ChatEnum | string | null;
}

@Component({
    components:{
        ChatMessage
    }
})
export default class Chat extends Base {
    render = false;
    conversation: IConversation[] = [];
    isWriting: boolean = false;
    message:string|null = null;
    threadId:string|null = null;


    created(): void {
        this.threadId = null;

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
        this.addUserMessage();
        const tempMessage = this.message;
        this.message = null;
        _assistantRepository.MovieAssistant({
            content: tempMessage as string,
            threadId: this.threadId
        })
        .then((response)=>{
            this.addAssistantMessage(response.message ? response.message : '');
            this.threadId = response.threadId;
        })
        .catch((err)=>{
            console.log(err);
            this.$toast.error("Şu anda hizmet verememekteyiz.");
        })
        .finally(()=>this.isWriting=false);
    }

    addUserMessage(){
        this.conversation.push({
            msg: this.message as string,
            msgId: this.conversation.length + 1,
            type: ChatEnum.User
        });
    }

    addAssistantMessage(message:string){
        this.conversation.push({
            msg: message,
            msgId: this.conversation.length + 1,
            type: ChatEnum.Assistant
        });
    }

}