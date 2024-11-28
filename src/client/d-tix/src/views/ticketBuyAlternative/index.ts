import { Component, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";
import MovieSelection from "@/components/movieSelection/index.vue";
import TheaterHall from "@/components/theaterhall/index.vue";
import BranchSelection from "@/components/branchSelection/index.vue";
import ReservationModel from "@/models/reservation/reservationModel";
import TicketSummary from "@/components/ticketSummary/index.vue";
import { PaymentRepository } from '@/Repositories/PaymentRepository';
import { Repositories, RepositoryFactory } from '@/services/RepositoryFactory';

const _paymentRepository = RepositoryFactory(Repositories.PaymentRepository) as PaymentRepository;


@Component({
    components: {
        MovieSelection,
        TheaterHall,
        BranchSelection,
        TicketSummary
    },
})
export default class TicketBuyAlternative extends Base {

    reservationModel = new ReservationModel();
    sectionStep:number = 0;
    checkoutFormContent:string =  '';
    loading:boolean =  false; 
    error:string =  '' 


    created(): void {
    }

    destroyed(): void {
    }

    mounted(): void {
    }


    async next(step:number){
        if(this.sectionStep+step == 3){
            this.loading = true;
            _paymentRepository.PayProduct("abc")
            .then(response => {
                if (typeof response === 'string' && response.trim().startsWith('<script')) {                
                    const scriptContent = response.replace(/<\/?script[^>]*>/g, ''); 
                    const script = document.createElement('script');
                    script.type = 'text/javascript';
                    script.text = scriptContent; 
                    document.head.appendChild(script);
    
                } else {
                    console.error('Beklenmeyen yanıt:', response);
                }
            })
            .catch(error => {
                this.error = "Ödeme formunu alırken hata oluştu: " + error.message; 
            })
            .finally(() => {
                this.loading = false; 
            });   
            return;
        }

        if(this.sectionStep + step > 2 || this.sectionStep + step < 0){
            this.$toast.warning("Adım sayısının dışına çıkamazsınız 😊");
            return;
        }
        this.sectionStep = this.sectionStep + step;
    }

    selectBranchForReservation(branchId: number){
        this.reservationModel.branchId = branchId;
        console.log(this.reservationModel);
    }

    selectMovieForReservation(movieId: number){
        this.reservationModel.movieId = movieId;
        console.log(this.reservationModel);

    }
}