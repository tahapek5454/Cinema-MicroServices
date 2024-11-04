import {ReservedStatusEnum} from "@/models/enums/ReservedStatusEnum";

export default class SeatSessionStatusDto{
     sessionId: number;
     seatId: number;
     seatNumber: string;
     reservedStatus: ReservedStatusEnum;
     createdDate: Date;
     updatedDate?: Date;
     userId?: number;
}