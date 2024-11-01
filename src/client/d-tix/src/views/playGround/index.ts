import { Component, Vue } from 'vue-property-decorator';
import C from '@/components/movieSelection/index.vue';
import { VoieceService } from '@/services/VoiceService';


@Component({
    components: {
        C
    }
})
export default class PlayGroundView extends Vue {

}