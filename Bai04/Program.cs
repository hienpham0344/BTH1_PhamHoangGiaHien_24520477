namespace Bai04
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

        
      
        public static void Main()
        {
            int? month;
            do
            {
                Console.Write("Nhap thang (1-12): ");
                month = ReadNullable<int>();
                if (month == null)  Console.WriteLine("Vui long nhap thang (1-12) !!!");
                if (month is < 1 or > 12) Console.WriteLine("vui long nhap thang hop le!!!");
            } while (month is null or < 1 or > 12);

            int? year;
            do
            {
                Console.Write("Nhap nam: ");
                year = ReadNullable<int>();
                if  (year is null) Console.WriteLine("vui long nhap nam!!!");
                else if (year <= 0) Console.WriteLine("vui long nhap nam hop le!!!");
            } while (year is null or <= 0);

            var days = DateTime.DaysInMonth(year.Value, month.Value);
            Console.WriteLine($"Thang {month.Value} nam {year.Value} co {days} ngay");
        }

    }
}