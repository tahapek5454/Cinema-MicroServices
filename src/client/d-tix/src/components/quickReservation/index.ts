import { Component, Prop, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";
import Modal from "@/components/modal/index.vue";
import MovieSelection from "@/components/movieSelection/index.vue";
import TheaterHall from "@/components/theaterhall/index.vue";
import BranchSelection from '../branchSelection/index.vue';
import ReservationModel from '@/models/reservation/reservationModel';
import TicketSummary from "@/components/ticketSummary/index.vue";

@Component({
    components: {
        Modal,
        MovieSelection,
        TheaterHall,
        BranchSelection,
        TicketSummary,
    }
})
export default class QuickReservation extends Base {
    @Prop({default:false}) isOpenModal!: boolean;

    reservationModel = new ReservationModel();

    sectionStep:number = 0;
    created(): void {
        console.log(this.isOpenModal);
    }

    destroyed(): void {

    }

    mounted(): void {
    }

    next(step:number){
        if(this.sectionStep+step == 3){
            this.$toast.success("Rezervasyonun tamamlandı 😊");
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