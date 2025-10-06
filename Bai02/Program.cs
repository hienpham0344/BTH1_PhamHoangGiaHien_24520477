namespace Bai02
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

        
      
        public static void Main(string[] args)
        {
            Console.Write("Nhap n de tinh tong cac so nho hon n: ");
            var num = ReadNullable<uint>();
            var sum = num * (num + 1) / 2;
            Console.WriteLine($"Tong = {sum}");
        }
    }
}