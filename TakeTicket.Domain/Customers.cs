using System;
using System.ComponentModel.DataAnnotations.Schema;
using TakeTicket.Domain.Enums;

namespace TakeTicket.Domain
{
    public class Customers
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string TripType { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public DateTime AddedDate { get; set; }
        public bool RegistrationMessageSent { get; set; }
        public bool ConfirmationMessageSent { get; set; }
        public DateTime? ConfirmationAutoSentDate { get; set; }

        public int? BusId { get; set; }
        public Buses? Bus { get; set; }
        public ReservationType ReservationType { get; set; }

        //
        public int CreatedByUserId { get; set; }
        public Users CreatedByUser { get; set; }
        // TODO
        public int? UpdatedByUserId { get; set; }
        public Users? UpdatedByUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public string SeatLabel => SeatNumber ?? "-";
    }
}
