namespace Pokemons.Program
{
    public class Pokemon
    {
        public string name { get; set; }
        public float price { get; set; }
        public string pic { get; set; }
        public Pokemon(string _name = "", float _price = 0, string _pic = "")
        {
            name = _name;
            price = _price;
            pic = _pic;
        }
    }
}
