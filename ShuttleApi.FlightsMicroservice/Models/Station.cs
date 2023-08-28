namespace ShuttleApi.FlightsMicroservice.Models
{
    public class Station // их должно быть минимум две
                        //чтобы планета была пригодная для полетов, такие правила
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreatedAt { get; set; }
        public string Title { get; set; } 
        public int RefuelingSpeed { get; set; } // per min
        public int NumberOfShipsNow { get; set; }
        public int MaxNumberOfShips { get; set; }
        public string PlanetId { get; set; } = string.Empty;
     }
}
