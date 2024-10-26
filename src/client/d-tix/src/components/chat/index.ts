import { Component, Vue } from 'vue-property-decorator';
import ChatMessage from './chatMessage/index.vue';


@Component({
    components:{
        ChatMessage
    }
})
export default class Chat extends Vue {
    render = false;

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