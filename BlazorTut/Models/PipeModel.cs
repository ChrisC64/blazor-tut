namespace BlazorTut.Models
{
    public class PipeModel
    {
        public int DistanceFromLeft { get; set; } = 500;
        public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
        public int Speed { get; private set; } = 2;

        public int Gap { get; private set; } = 130;
        //helper properties
        public int GapBottom => DistanceFromBottom + 300; // 300 is the default value of pipe height
        public int GapTop => GapBottom + Gap;
        public void Move()
        {
            DistanceFromLeft -= Speed;
        }

        public bool IsOffScreen()
        {
            return DistanceFromLeft <= -60;
        }

        public bool IsCentered()
        {
            // Using hard coded values - will change later to be more flexible
            // Game width / 2 + bird width / 2 = center 
            bool hasEnteredCenter = DistanceFromLeft <= (500 / 2) + (60 / 2);
            bool hasExitedCenter = DistanceFromLeft <= (500 / 2) - (60 / 2) - 60;

            return hasEnteredCenter && !hasExitedCenter;
        }
    }
}
