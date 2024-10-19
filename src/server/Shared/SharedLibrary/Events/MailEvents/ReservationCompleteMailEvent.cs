namespace SharedLibrary.Events.MailEvents
{
    public class ReservationCompleteMailEvent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MovieName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string BranchName { get; set; }
        public int MovieTheaterNumber { get; set; }
        public string SeatNumbers { get; set; }
        public DateTime ReservationTime { get; set; }
        public string TotalPrice { get; set; }
        public int MyProperty { get; set; }
    }
}
