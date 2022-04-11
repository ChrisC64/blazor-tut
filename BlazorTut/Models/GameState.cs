namespace BlazorTut.Models
{
    /// <summary>
    /// Contains information regarding the game's state. This includes things such as
    /// the speed of the game, the width and height of the game area, difficulty, and mnore.
    /// </summary>
    [Serializable]
    public class GameState
    {
        public int Width { get; private set; } = 730;
        public int Height { get; private set; } = 500;
        public int Gravity { get; private set; } = 2;
        public int PipeGap { get; private set; } = 130;
        public int PipeMinRange { get; private set; } = 0;
        public int PipeMaxRange { get; private set; } = 60;
        public float Speed { get; private set; } = 1.0f;

        public GameState()
        {

        }

        public GameState(int width, int height, int gravity = 2, 
            int pipeGape = 130, int minRange = 0, int maxRange = 60)
        {
            Width = width; 
            Height = height;
            Gravity = gravity;
            PipeGap = pipeGape;
            PipeMinRange = minRange;
            PipeMaxRange = maxRange;
        }
    }
}
