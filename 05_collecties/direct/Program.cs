namespace direct;

class Program
{
    static void Main(string[] args)
    {
        double[] percentages = new double[] {15, 25.2, 1.2, 0.5, 0.251, 0.0001 };
        for(int i = 0; i < percentages.Length; i++)
        {
            Console.WriteLine("item " + i + " in de array heeft de waarde: " + percentages[i]);
        }
    }
}
