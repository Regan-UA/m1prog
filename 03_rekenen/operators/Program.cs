namespace operators;

class Program
{
    static void Main(string[] args)
    {
        int voordbeeld3 = 20;
        int result2 = voordbeeld3 += 3;
        Console.WriteLine($"voorbeeld is nu 30, zie: {voordbeeld3}  result2 ook {result2}");
        result2 -= 1;
        Console.WriteLine($"niewe resultaat: {result2}");
        result2 *= 2;
        Console.WriteLine($"niewe resultaat: {result2}");
        result2 /= 3;
        Console.WriteLine($"niewe resultaat: {result2}");
    }
}
