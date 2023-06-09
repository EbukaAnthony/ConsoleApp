namespace TrainStationManagementApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public int RouteId { get; set; }
        public string ReferenceNumber { get; set; }
        public int SeatNumber { get; set; }


        public Booking(int id, string customerEmail, int routeId, string referenceNumber, int seatNumber)
        {
            Id = id;
            CustomerEmail = customerEmail;
            RouteId = routeId;
            ReferenceNumber = referenceNumber;
            SeatNumber = seatNumber;
        }
    }
}