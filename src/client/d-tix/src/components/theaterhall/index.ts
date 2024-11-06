import {Component, Vue} from 'vue-property-decorator';
import TheaterSeat from '../theaterSeat/index.vue';
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {SessionRepository} from "@/Repositories/SessionRepository";
import Base from "@/utils/Base";
import SignalRService from "@/services/SignalRService";
import SeatSessionStatusDto from "@/models/session/SeatSessionStatusDto";

const _sessionRepository = RepositoryFactory(Repositories.SessionRepository) as SessionRepository;
@Component({
    components:{
        TheaterSeat
    }
})
export default class TheaterHall extends Base {
    seatSessionStatus: SeatSessionStatusDto[] = [];
    seatStatusHubService: SignalRService = new SignalRService("localhost:7177", "seatStatus", "sessionId=1");
    sessionId = 1;

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
        const self = this;
        self.showLoading();
         _sessionRepository.GetSeatWithStatusBySessionId(self.sessionId)
             .then(r => {
                    self.seatSessionStatus = r;
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
        .catch((e)=>{
            console.log(e);
        })
    }


}
