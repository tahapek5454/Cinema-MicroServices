import { Component, Vue } from 'vue-property-decorator';
import C from '@/components/dateFilter/index.vue';
import { VoieceService } from '@/services/VoiceService';


@Component({
    components: {
        C
    }
})
export default class PlayGroundView extends Vue {
    voice(){
        const service = new VoieceService();

        service.textToSepach("Selamlar nasılsın iyi misin ?");
    }

}