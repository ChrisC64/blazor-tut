using Microsoft.AspNetCore.Components.Web;

namespace BlazorTut.Models
{
    public class GameManager
    {
        private readonly int _gravity = 2;

        public event EventHandler? OnRender;

        public BirdModel Bird { get; private set; }
        public Queue<PipeModel> Pipes { get; private set; }
        public bool IsRunning { get; private set; } = false;
        public GameManager()
        {
            Bird = new BirdModel();
            Pipes = new Queue<PipeModel>();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {
                UpdateObjects();
                CheckCollisions();
                ManagePipes();

                OnRender?.Invoke(this, EventArgs.Empty);
                await Task.Delay(16);
            }
        }

        public void StartGame()
        {
            if (!IsRunning)
            {
                Bird = new BirdModel();
                MainLoop();
            }
        }

        public void GameOver()
        {
            IsRunning = false;
        }

        void UpdateObjects()
        {
            Bird.Fall(_gravity);
            foreach (var pipe in Pipes)
            {
                pipe.Move();
            }
        }

        void CheckCollisions()
        {
            if (Bird.DistanceFromGround <= 0)
            {
                GameOver();
                return;
            }
        }

        void ManagePipes()
        {
            if(!Pipes.Any() || Pipes.Last().DistanceFromLeft <= 250)
            {
                Pipes.Enqueue(new PipeModel());
            }

            if (Pipes.First().IsOffScreen())
            {
                Pipes.Dequeue();
            }
        }
        public void HandleKeyUp(KeyboardEventArgs e)
        {
            if (!IsRunning)
                return;

            if (e.Key == " ")
            {
                if (Bird.DistanceFromGround + Bird.JumpStrength < 530)
                    Bird?.Jump();
            }
        }
    }
}
