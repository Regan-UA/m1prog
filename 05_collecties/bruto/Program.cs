using System;

namespace bruto;

class Program
{
 static double[] brutoSalarisen = { 5404.24, 10252.7, 6531.05 };
    static double[] nettoSalarisen;

    static void Main(string[] args)
    {
        nettoSalarisen = new double[brutoSalarisen.Length];
        for (int i = 0; i < brutoSalarisen.Length; i++)
        {
            double bruto = brutoSalarisen[i];

            if (bruto < 38441)
            {
                nettoSalarisen[i] = bruto * (1 - 0.3582);
            }
            else if (bruto >= 38441 && bruto < 76817)
            {
                nettoSalarisen[i] = bruto * (1 - 0.3748);
            }
            else
            {
                nettoSalarisen[i] = bruto * (1 - 0.495);
            }

            Console.WriteLine($"Netto salaris van persoon {i + 1} is: {nettoSalarisen[i]:0.00}");
        }
    }
}
