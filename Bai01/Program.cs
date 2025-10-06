
namespace Program
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

        private static bool PrimeNum(int? n)
        {
            if (n is null) return false; 
            switch (n.Value)
            {
                case < 2:
                case var x when x % 2 == 0 && x != 2:
                    return false;
                case 2:
                    return true;
                default:
                    for (var i = 3; i * i <= n; i += 2)
                        if (n % i == 0) return false;
                    return true;
            }
        }
        
        private static bool IsPerfectSquare(int? n)
        {
            if (n is null or < 0) return false;
            var root = (int)Math.Sqrt(n.Value);
            return root * root == n.Value;
        }

        private static int? MinPerfectSquare(ICollection<int?> list)
        {
            return list.Where(IsPerfectSquare).DefaultIfEmpty(-1).Min();
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Nhap n: ");
            var listSize = ReadNullable<int>();

            List<int?> list = [];
            for (var i = 0; i < listSize; i++)
            {
                var value = ReadNullable<int>();
                list.Add(value);
            }
            
            var sum = list.Sum();
            Console.WriteLine("Tong cua mang la: " + sum);

            var count = list.Count(PrimeNum);
            Console.WriteLine("Tong so nguyen to cua mang :" + count);

            Console.WriteLine("So chinh phuong nho nhat la :" + MinPerfectSquare(list));


        }
    }
}