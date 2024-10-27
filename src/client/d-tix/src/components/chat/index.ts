import {Component} from 'vue-property-decorator';
import ChatMessage from './chatMessage/index.vue';
import Base from "@/utils/Base";
import {ChatEnum} from "@/models/enums/ChatEnum";


interface IConversation {
    msg:string | null;
    msgId:number | null;
    transactionId: string | null;
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


    created(): void {
        this.conversation.push({
            msg : 'Selamlar nasılsın ?',
            msgId : 1,
            transactionId: 'test',
            type: ChatEnum.User
        });

        this.conversation.push({
            msg : 'Teşekkürler, size nasıl yardımcı olabilirim ?',
            msgId : 2,
            transactionId: 'test',
            type: ChatEnum.Assistant
        });

        this.conversation.push({
            msg : 'Bana en yüksek puana sahip olan film hakkında bilgi verebilir misin ?',
            msgId : 3,
            transactionId: 'test',
            type: ChatEnum.User
        });
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
        this.$root.$emit('mascotOpen');
    }


}