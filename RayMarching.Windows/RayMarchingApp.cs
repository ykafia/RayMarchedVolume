using Stride.Engine;

namespace RayMarching
{
    class RayMarchingApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
