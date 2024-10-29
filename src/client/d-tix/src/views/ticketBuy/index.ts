import { Component, Vue, Watch } from 'vue-property-decorator';
import MovieCard  from '@/components/movieCard/index.vue';
import DateFilter from '@/components/dateFilter/index.vue';
import LocationFilter from '@/components/locationFilter/index.vue';
import TicketSummary from '@/components/ticketSummary/index.vue';
import Theaterhall from '@/components/theaterhall/index.vue';
import axios from "axios";


const baseURL = 'http://localhost:5010';


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
    async fetchCheckoutForm() {
        this.loading = true;
        await axios.post(baseURL + '/api/Payments/PayProduct')
        .then(response => {
            if (typeof response.data === 'string' && response.data.trim().startsWith('<script')) {                
                const scriptContent = response.data.replace(/<\/?script[^>]*>/g, ''); 
                const script = document.createElement('script');
                script.type = 'text/javascript';
                script.text = scriptContent; 
                document.head.appendChild(script);

            } else {
                console.error('Beklenmeyen yanıt:', response.data);
            }
        })
        .catch(error => {
            this.error = "Ödeme formunu alırken hata oluştu: " + error.message; 
        })
        .finally(() => {
            this.loading = false; 
        });         
    }

    
}