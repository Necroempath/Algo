namespace AlgorithmicLab;

class Program
{
    static void Main(string[] args)
    {
        Program program = new();
        Console.WriteLine(program.IsPolydrome(2112));
    }

    bool IsPolydrome(int num)
    {
        int depth = Depths(num);

        for (int i = 0; i < depth / 2; i++)
        {
            if (GetDigit(num, i + 1) != GetDigit(num, depth - i))
            {
                return false;
            }
        }

        return true;
    }

    int Depths(int num)
    {
        int depths = 1;

        while (num >= 10)
        {
            num /= 10;
            depths++;
        }

        return depths;
    }
    
    // 981267
    int GetDigit(int num, int target)
    {
        int depth = Depths(num);
        
        int result = num;
        
        for (int i = 0; i < depth - target; i++)
        {
            result /= 10;
        }
        
        return result % 10;
    }
}
