import { Component, Vue } from 'vue-property-decorator';
import MovieCard  from '@/components/movieCard/index.vue';
import DateFilter from '@/components/dateFilter/index.vue';
import LocationFilter from '@/components/locationFilter/index.vue';
import TicketSummary from '@/components/ticketSummary/index.vue';
import Theaterhall from '@/components/theaterhall/index.vue';



@Component({
    components: {
        DateFilter,
        MovieCard,
        LocationFilter,
        TicketSummary,
        Theaterhall
    }
})
export default class TicketBuyView extends Vue {
    tempPath :string = '/movieCardImages/alien.png';

    show(){
        this.$toast.success("Bilet aldın");
      }
}