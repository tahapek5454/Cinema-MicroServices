namespace SharedLibrary.Helpers
{
    public static class CalculateMethods
    {
        public static (DateTime, DateTime) FindWeekArrange(DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;

            var r1 = dt.AddDays(-1 * diff).Date;
            var r2 = r1.AddDays(6);
            return (r1, r2);
        }
    }
}
