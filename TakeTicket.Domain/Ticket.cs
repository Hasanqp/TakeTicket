using System;

namespace TakeTicket.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string SeatNumber { get; set; }
        public string TicketType { get; set; }

        public string ValidationCode { get; set; }

        public bool IsUsed { get; set; } = false;
        public DateTime? UsedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public Customers Customer { get; set; }
    }
}
