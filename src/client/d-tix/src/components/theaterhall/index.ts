import {Component, Prop} from 'vue-property-decorator';
import TheaterSeat from '../theaterSeat/index.vue';
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {SessionRepository} from "@/Repositories/SessionRepository";
import Base from "@/utils/Base";
import SignalRService from "@/services/SignalRService";
import SeatSessionStatusDto from "@/models/session/SeatSessionStatusDto";
import ReservationModel from "@/models/reservation/reservationModel";
import {ReservedStatusEnum} from "@/models/enums/ReservedStatusEnum";
import {GetAuthInfo} from "@/services/AuthService";

const _sessionRepository = RepositoryFactory(Repositories.SessionRepository) as SessionRepository;
@Component({
    components:{
        TheaterSeat
    }
})
export default class TheaterHall extends Base {
    @Prop() reservationModel: ReservationModel;

    loginInfo = GetAuthInfo();
    seatSessionStatus: SeatSessionStatusDto[] = [];
    seatStatusHubService: SignalRService;
    sessionId = 0;

    get filteredSeatsForA(): SeatSessionStatusDto[] {
        return this.seatSessionStatus.filter(seat => seat.seatNumber.includes('A'));
    }
    get filteredSeatsForB(): SeatSessionStatusDto[] {
        return this.seatSessionStatus.filter(seat => seat.seatNumber.includes('B'));
    }
    get filteredSeatsForC(): SeatSessionStatusDto[] {
        return this.seatSessionStatus.filter(seat => seat.seatNumber.includes('C'));
    }
    get filteredSeatsForD(): SeatSessionStatusDto[] {
        return this.seatSessionStatus.filter(seat => seat.seatNumber.includes('D'));
    }


     created() {

        if(this.reservationModel){
            this.sessionId = this.reservationModel.sessionId as number;
            this.reservationModel.seatIds = [];
            this.seatStatusHubService = new SignalRService("session-svc:8080", "seatStatus", `sessionId=${this.sessionId}`);
        }

        const self = this;
        self.showLoading();
         _sessionRepository.GetSeatWithStatusBySessionId(self.sessionId)
             .then(r => {
                    self.seatSessionStatus = r;
                    r.forEach(x => {
                        if(''+x.userId==''+this.loginInfo?.userId && x.reservedStatus == ReservedStatusEnum.Pending)
                            this.reservationModel.seatIds.push(x.seatId);
                    })
             })
             .finally(()=>self.hideLoading());

        this.seatStatusHubService.HubConection.start().then(()=>{
            self.seatStatusHubService.HubConection.on("receiveStatus", (message: SeatSessionStatusDto) => {
                let val = self.seatSessionStatus.find(x => x.seatId == message.seatId);
                if(val){
                    val.createdDate = message.createdDate;
                    val.updatedDate = message.updatedDate;
                    val.reservedStatus = message.reservedStatus;
                    val.userId = message.userId;
                }

            });
        });
    }

    destroyed(): void {
        this.seatStatusHubService.HubConection.stop();
    }

    mounted(): void {
    }


    clickSeat(val:SeatSessionStatusDto){
        const self = this;
        _sessionRepository.PreBookingOrCancel({
            seatId:val.seatId,
            reservedStatus: val.reservedStatus,
            sessionId: val.sessionId,
            userId: val.userId
        })
        .then(()=>{
            if(val.reservedStatus == ReservedStatusEnum.Pending)
                this.reservationModel.seatIds.push(val.seatId);
            else if(val.reservedStatus == ReservedStatusEnum.NotReserved)
                this.reservationModel.seatIds = this.reservationModel.seatIds.filter(x => x!=val.seatId);
        })
        .catch((e)=>{
            console.log(e);
        })
    }


}
