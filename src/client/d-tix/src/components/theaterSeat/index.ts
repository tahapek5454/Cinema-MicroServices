import {Component, Prop, Vue} from 'vue-property-decorator';
import SeatSessionStatusDto from "@/models/session/SeatSessionStatusDto";
import {ReservedStatusEnum} from "@/models/enums/ReservedStatusEnum";
import Base from "@/utils/Base";
import LoginResponse from "@/models/auth/LoginResponse";
import {GetAuthInfo} from "@/services/AuthService";


@Component
export default class TheaterSeat extends Base {
  @Prop() seatSessionStatus!: SeatSessionStatusDto;

  loginInfo: LoginResponse  | null= null;

  created(): void {
    this.loginInfo = GetAuthInfo();
  }

  destroyed(): void {
  }

  mounted(): void {
  }

  get GetSeatColor(){
    if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Reserved)
      return "tw-bg-red tw-text-white";
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Pending && this.loginInfo != null && this.loginInfo.userId == this.seatSessionStatus.userId)
      return  "tw-bg-lime-500 tw-text-white";
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Pending)
      return "tw-bg-orange tw-text-white";
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.NotReserved)
      return "tw-bg-white tw-text-black";
    else
      return  "";
  }
  choose(){

    if(this.loginInfo == null){
      this.$toast.info("Koltuk seçimi için lütfen giriş yapınız.");
      return;
    }

    if(this.seatSessionStatus.userId && this.loginInfo.userId != this.seatSessionStatus.userId){
      this.$toast.error("Başkalarının seçimleriyle ilgili işlem yapamazsınız.");
      return;
    }

    if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Reserved)
      return;
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.NotReserved)
        this.seatSessionStatus.reservedStatus = ReservedStatusEnum.Pending;
    else if(this.seatSessionStatus.reservedStatus == ReservedStatusEnum.Pending)
        this.seatSessionStatus.reservedStatus = ReservedStatusEnum.NotReserved;

    if(!this.seatSessionStatus.userId)
      this.seatSessionStatus.userId = this.loginInfo.userId;

    this.$emit("clickseat", this.seatSessionStatus);
  }




}