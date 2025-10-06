namespace Bai05
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

        
        private static string GetThuVietNam(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Sunday => "CN",
                DayOfWeek.Monday => "2",
                DayOfWeek.Tuesday => "3",
                DayOfWeek.Wednesday => "4",
                DayOfWeek.Thursday => "5",
                DayOfWeek.Friday => "6",
                DayOfWeek.Saturday => "7",
                _ => ""
            };
        }
        
      
        public static void Main()
        {
            
            int? year;
            do
            {
                Console.Write("Nhap nam: ");
                year = ReadNullable<int>();
                if  (year is null) Console.WriteLine("vui long nhap nam!!!");
                else if (year <= 0) Console.WriteLine("vui long nhap nam hop le!!!");
            } while (year is null or <= 0);
            
            int? month;
            do
            {
                Console.Write("Nhap thang (1-12): ");
                month = ReadNullable<int>();
                if (month == null)  Console.WriteLine("Vui long nhap thang (1-12)!!! ");
                if (month is < 1 or > 12) Console.WriteLine("vui long nhap thang hop le!!!");
            } while (month is null or < 1 or > 12);
            
            
            var daysInMonth = DateTime.DaysInMonth(year.Value, month.Value);

            int? day;
            do
            {
                Console.Write($"Nhap ngay (1-{daysInMonth}): ");
                day = ReadNullable<int>();
                if (day is null or < 1 || day > daysInMonth) 
                    Console.WriteLine("vui long nhap ngay hop le!!!");
            } while (day is null or < 1 || day > daysInMonth);
            
            var date = new DateTime(year.Value, month.Value, day.Value);
            Console.WriteLine($"Thang {month.Value} nam {year.Value} ngay {day.Value} la thu {GetThuVietNam(date.DayOfWeek)}");
        }

    }
}