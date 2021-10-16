namespace BMX.Models
{
    public record GameState
    {
        public bool Paused { get; set; }
        public long GameTicks { get; set; }
        public GameSpeed GameSpeed { get; set; }
    }
}

