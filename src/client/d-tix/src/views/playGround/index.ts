import { Component, Vue } from 'vue-property-decorator';
import C from '@/components/ticketSummary/index.vue';


@Component({
    components: {
        C
    }
})
export default class PlayGroundView extends Vue {}