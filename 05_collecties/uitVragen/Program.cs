namespace uitVragen;

class Program
{
    static void Main(string[] args)
    {
        double[] numbers = { 1.5, 2.5, 3.5, 4.5, 5.5 };
        double temp = numbers[2];
        Console.WriteLine("Derde nummer voor de wijziging: " + temp);
        temp = numbers[4];
        Console.WriteLine("Derde nummer na de wijziging: " + temp);
    }
}
