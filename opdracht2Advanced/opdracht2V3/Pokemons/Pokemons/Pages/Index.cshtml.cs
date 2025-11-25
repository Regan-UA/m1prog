using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemons.Program;
using System.Globalization;

namespace Pokemons.Pages
{
    public class IndexModel : PageModel
    {
       public List<Pokemon> pokemons = new List<Pokemon>();
        List<string> lines = new List<string>();
        List<List<string>> divisions = new List<List<string>>();
        List<string> names = new List<string>();
        List<string> prices = new List<string>();
        List<string> pictures = new List<string>();
        public void OnGet()
        {
            string dataList = System.IO.File.ReadAllText(@"Program/02 collectible_cards.csv");

            lines = dataList.Split('\n').ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                divisions.Add(lines[i].Split(',').ToList());
                
                names.Add(divisions[i -1][0]);
                string priceCheck = divisions[i - 1][1];
                if (float.TryParse(priceCheck, NumberStyles.Float, CultureInfo.InvariantCulture, out float f))
                {
                    prices.Add(f.ToString());
                }
                pictures.Add(divisions[i - 1][2]);
                pokemons.Add(new Pokemon(names[i - 1], float.Parse(prices[i - 1]), pictures[i - 1]));
            }
        }
    }
}
