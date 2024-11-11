export default class ReservationModel{

    sessionId?: number | null = null;
    userId?: number | null = null;
    branchId?: number | null = null;  // client side için gerekli
    movieId?: number | null = null;    // client side için gerekli
    seatIds?: number[] = [];
}