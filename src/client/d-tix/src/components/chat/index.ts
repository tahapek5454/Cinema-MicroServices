import { Component, Vue } from 'vue-property-decorator';
import ChatMessage from './chatMessage/index.vue';


@Component({
    components:{
        ChatMessage
    }
})
export default class Chat extends Vue {

    
}