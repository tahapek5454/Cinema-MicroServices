import { Component, Vue } from 'vue-property-decorator';
import TheaterHall from '@/components/theaterhall/index.vue';


@Component({
    components: {
        TheaterHall
    }
})
export default class PlayGroundView extends Vue {}