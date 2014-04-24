namespace InfinitiCars.Events
{
    /// <summary>
    /// A manufacturer releases a new model
    /// </summary>
    public class NewModelAppeared
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string ModelYear { get; set; }
    }
}
