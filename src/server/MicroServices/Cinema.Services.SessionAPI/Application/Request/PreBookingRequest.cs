using SharedLibrary.Enums;

namespace Cinema.Services.SessionAPI.Application.Request
{
    public struct PreBookingRequest
    {
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public ReservedStatusEnum? ReservedStatus { get; set; }
    }
}
