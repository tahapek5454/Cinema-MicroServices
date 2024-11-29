import { Component, Vue, Watch } from 'vue-property-decorator';
import MovieCard  from '@/components/movieCard/index.vue';
import DateFilter from '@/components/dateFilter/index.vue';
import LocationFilter from '@/components/locationFilter/index.vue';
import TicketSummary from '@/components/ticketSummary/index.vue';
import Theaterhall from '@/components/theaterhall/index.vue';
import axios from "axios";
import { PaymentRepository } from '@/Repositories/PaymentRepository';
import { Repositories, RepositoryFactory } from '@/services/RepositoryFactory';


const _paymentRepository = RepositoryFactory(Repositories.PaymentRepository) as PaymentRepository;


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
    checkoutFormContent:string =  '';
    loading:boolean =  false; 
    error:string =  '' 

    mounted() {
      document.addEventListener('click', this.handleClick);
    }

    beforeDestroy() {
        document.removeEventListener('click', this.handleClick);
    }

    handleClick(event:any) {
        const target = event.target.closest('.css-48y2rb-Close-Close');
        if (target) {
            this.reloadPage();
        }
    }

    reloadPage() {
        location.reload(); 
    }    
}