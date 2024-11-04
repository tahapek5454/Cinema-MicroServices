import {ReservedStatusEnum} from "@/models/enums/ReservedStatusEnum";

export default class  PreBookingRequest{
    sessionId: number;
    seatId: number;
    reservedStatus: ReservedStatusEnum;
    userId: number;
}