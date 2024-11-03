import { Component, Vue } from 'vue-property-decorator';
import C from '@/components/comment/index.vue';
import { VoieceService } from '@/services/VoiceService';


@Component({
    components: {
        C
    }
})
export default class PlayGroundView extends Vue {

}