namespace consoleproject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number");
        float var1 = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number");
        float var2 = float.Parse(Console.ReadLine());
        Console.WriteLine(var1 + var2);
    }
}
