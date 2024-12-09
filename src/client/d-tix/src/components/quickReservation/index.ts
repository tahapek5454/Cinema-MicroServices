import { Component, Prop, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";
import Modal from "@/components/modal/index.vue";
import MovieSelection from "@/components/movieSelection/index.vue";
import TheaterHall from "@/components/theaterhall/index.vue";
import BranchSelection from '../branchSelection/index.vue';
import ReservationModel from '@/models/reservation/reservationModel';
import TicketSummary from "@/components/ticketSummary/index.vue";
import LoginResponse from "@/models/auth/LoginResponse";
import {GetAuthInfo} from "@/services/AuthService";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {PaymentRepository} from "@/Repositories/PaymentRepository";
import SessionSelection from "@/components/sessionSelection/index.vue";


const _paymentRepository = RepositoryFactory(Repositories.PaymentRepository) as PaymentRepository;

@Component({
    components: {
        Modal,
        MovieSelection,
        SessionSelection,
        TheaterHall,
        BranchSelection,
        TicketSummary
    }
})
export default class QuickReservation extends Base {
    @Prop({default:false}) isOpenModal!: boolean;

    reservationModel = new ReservationModel();

    sectionStep:number = 0;
    loading:boolean =  false;
    error:string =  ''
    loginInfo: LoginResponse  | null = GetAuthInfo();
    created(): void {
        if(!this.loginInfo){
            this.$toast.warning("Rezervasyon işlemleri için lütfen giriş yapınız 😊✅");
            this.isOpenModal = false;
            this.$router.push("/auth");
        }

        this.reservationModel.userId = this.loginInfo?.userId;
    }

    destroyed(): void {

    }

    mounted(): void {
    }

    next(step:number){
        if(this.sectionStep+step == 3){
            this.loading = true;
            _paymentRepository.PayProduct({
                sessionId: this.reservationModel.sessionId as number,
                seatIds: this.reservationModel.seatIds ,
                userId: this.reservationModel.userId ? this.reservationModel.userId as number : this.loginInfo?.userId as number,
            })
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

        if(this.sectionStep+step == 1){
            if(!(this.reservationModel.sessionId && this.reservationModel.branchId && this.reservationModel.movieId)){
                this.$toast.warning("Lütfen size uygun bir şube, film ve seans seçiniz 😊");
                return;
            }
        }

        if(this.sectionStep+step == 2){
            if(!this.reservationModel.seatIds || this.reservationModel.seatIds.length == 0){
                this.$toast.warning("Lütfen size uygun koltuk seçimi yapınız. 😊");
                return;
            }
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

    selectSessionForReservation(sessionId: number){
        this.reservationModel.sessionId = sessionId;
        console.log(this.reservationModel);

    }
}