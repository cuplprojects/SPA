namespace SPA.Services
{
    public class Randomizer
    {
        public static int Randomize(int n) 
        {
            Random random = new Random();
            return random.Next(1, n + 1);
        }
    }
}
