import {Component, Prop, Vue} from 'vue-property-decorator';
import SeatSessionStatusDto from "@/models/session/SeatSessionStatusDto";
import {ReservedStatusEnum} from "@/models/enums/ReservedStatusEnum";


@Component
export default class TheaterSeat extends Vue {
  @Prop() seatSessionStatus!: SeatSessionStatusDto;


  get GetSeatColor(){
    if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Reserved)
      return "tw-bg-red tw-text-white";
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Pending)
      return "tw-bg-orange tw-text-white";
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.NotReserved)
      return "tw-bg-white tw-text-black";
    else
      return  "";
  }
  choose(){
    if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Reserved)
      return;
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.NotReserved)
        this.seatSessionStatus.reservedStatus = ReservedStatusEnum.Pending;
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Pending)
        this.seatSessionStatus.reservedStatus = ReservedStatusEnum.NotReserved;

    this.$emit("clickseat", this.seatSessionStatus);
  }


}