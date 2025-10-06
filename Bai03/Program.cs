namespace Bai03
{
    class Program
    {
        private static T? ReadNullable<T>() where T : struct // kieu T chi thuoc int,double,...
        {
            var input = Console.ReadLine();
            try
            {
                if (!string.IsNullOrWhiteSpace(input)) return (T)Convert.ChangeType(input, typeof(T));
                Console.WriteLine("Input is empty");
                return null;
            }
            catch
            {
                Console.WriteLine("Input is invalid");
                return null;
            }
        }

        private static bool DateTimeCheck( int Day, int Month, int Year)
        {
            if (Year < 1) return false;
            if (Month is < 1 or > 12) return false;
            return !(Day > DateTime.DaysInMonth(Year, Month) || Day < 1) ;
        }

        
      
        public static void Main()
        {
            int? month;
            do
            {
                Console.Write("Nhap thang: ");
                month = ReadNullable<int>();
                if (month == null)  Console.WriteLine("Vui long nhap thang !!!");
            } while (month is null);

            int? year;
            do
            {
                Console.Write("Nhap nam: ");
                year = ReadNullable<int>();
                if  (year is null) Console.WriteLine("vui long nhap nam !!!");
            } while (year is null );
            
            int? day;
            do
            {
                Console.Write($"Nhap ngay : ");
                day = ReadNullable<int>();
                if (day is null ) Console.WriteLine("vui long nhap ngay !!!");
            } while (day is null);

            
            Console.WriteLine($"{day.Value}/{month.Value}/{year.Value} {(DateTimeCheck(day.Value,month.Value,year.Value) ? "hop le" : "khong hop le")} ");
        }

    }
}