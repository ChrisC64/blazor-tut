﻿namespace BlazorTut.Models
{
    public class PipeModel
    {
        public int DistanceFromLeft { get; set; } = 500;
        public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
        public int Speed { get; private set; } = 2;

        public int Gap { get; private set; } = 130;
        public void Move()
        {
            DistanceFromLeft -= Speed;
        }

        public bool IsOffScreen()
        {
            return DistanceFromLeft <= -60;
        }
    }
}
