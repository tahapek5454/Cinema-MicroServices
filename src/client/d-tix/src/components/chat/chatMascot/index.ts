import { Component, Vue } from 'vue-property-decorator';



@Component({})
export default class ChatMascot extends Vue {
    isVisible = true;

    
    mounted() {
        this.$root.$on('mascotOpen', ()=>{
                this.isVisible = true;
        }); 
    }

    destroyed() {
        this.$root.$off("mascotOpen");  
    }

    openChatPanel(){
        this.isVisible = false;
        this.$root.$emit('chatOpen', true);
    }
    
}