namespace Bai06
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
            // nhap cot hang
            Console.WriteLine("Nhap so hang:");
            var rows = ReadNullable<int>();
            Console.WriteLine("Nhap so cot:");
            var cols = ReadNullable<int>();
            
            // kiem tra null
            if (rows == null || cols == null) return;
            
            // nhap phan tu
            var data = new List<List<int?>>();
            for (var i = 0; i < rows; i++)
            {
                var row = new List<int?>();
                for (var j = 0; j < cols; j++)
                {
                    Console.Write($"Nhap phan tu [{i},{j}]: ");
                    row.Add(ReadNullable<int>());
                }
                data.Add(row);
            }
            
            
            var mat = new Matrix(data);

            // yeu cau 1
            Console.WriteLine("Ma tran vua nhap:");
            mat.Print();
            
            // yeu cau 2
            Console.WriteLine("Phan tu lon nhat = " + mat.MaxElement());
            
            // yeu cau 3
            Console.WriteLine("Phan tu nho nhat = " + mat.MinElement());
            
            // yeu cau 4
            Console.WriteLine("Hang lon nhat = " + mat.MaxRow());
            
            // yeu cau 5
            Console.WriteLine("Tong phan tu khong phai so nguyen to = " + mat.SumNotPrimeNums());

            // yeu cau 6
            Console.WriteLine("Nhap chi so hang can xoa:");
            var rowDel = ReadNullable<int>();
            if (rowDel != null) mat.DeleteRows(rowDel.Value);
            Console.WriteLine("Ma tran sau khi xoa hang:");
            mat.Print();
            
            var maxValue = mat.MaxElement();
            mat.DeleteColumContainMax(maxValue);
            Console.WriteLine("Ma tran sau khi xoa cot:");
            mat.Print();
            
        }

    }
}