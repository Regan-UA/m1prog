namespace fruit;

class Program
{
    static void Main(string[] args)
    {
        string[] fruit = { "kers", "appel", "banaan" };
        Console.WriteLine("Eerste fruit: " + fruit[0]);
        Console.WriteLine("Derde fruit: " + fruit[2]);

        bool[] isRood = { true, false, false };
        Console.WriteLine("Is de eerste fruit rood? " + isRood[0]);
        Console.WriteLine("Is de tweede fruit rood? " + isRood[1]);

        float[] randomNumbers = { 4.5f, 3.2f, 7.7f };
        Console.WriteLine("Eerste random nummer: " + randomNumbers[0]);
        Console.WriteLine("Tweede random nummer: " + randomNumbers[1]);
        Console.WriteLine("Derde random nummer: " + randomNumbers[2]);
    }
}
