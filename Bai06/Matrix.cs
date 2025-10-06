
namespace Bai06;

public class Matrix(List<List<int?>> matrix)
{
    
    // In ra ma trận
    public void Print()
    {
        foreach (var row in matrix)
        {
            foreach (var val in row)
                Console.Write($"{val,4}");
            Console.WriteLine();
        }
    }

    public int MaxElement() // su dung linq
    { 
        return matrix.
            SelectMany(row => row).
            Where(x => x != null).
            Max(x=>x!.Value);
    }

    public int MinElement()
    {
        return matrix.
            SelectMany(row => row).
            Where(x => x != null).
            Min(x=>x!.Value);
    }

    public List<int?> MaxRow()
    {
        int? maxSum = int.MinValue;
        var indexMax = -1;

        for (var i = 0; i < matrix.Count; i++)
        {
                
            var rowSum = matrix[i].Sum();
            if (rowSum <= maxSum) continue;  
            maxSum = rowSum;
            indexMax = i;
        }

        return matrix[indexMax];
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

    public int SumNotPrimeNums()
    {
        return matrix.SelectMany(row => row).Where(x => x != null && !PrimeNum(x.Value)).Sum(x=>(x!.Value));
    }

    public void DeleteRows(int rows)
    {
        if (rows < 0 || rows >= matrix.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(rows),"chi so hang khong hop le");
        }
        matrix.RemoveAt(rows);
  
    }

    private void DeleteColumns(int col)
    {
        if (matrix.Count == 0) return;
        if (col < 0 || col >= matrix[0].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(col),"chi so hang khong hop le");
        }

        foreach (var rows in matrix)
        {
            rows.RemoveAt(col);
        }
    }

    public void DeleteColumContainMax( int maxValue)
    {
        if (matrix.Count == 0) return ;
        var maxCols = Enumerable
            .Range(0, matrix[0].Count)              
            .Where(col => matrix.Any(row => row[col] == maxValue))  
            .OrderByDescending(col => col)
            .ToList();
        foreach (var i in maxCols)
        {
            DeleteColumns(i);
        }
        
    }

}