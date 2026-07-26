using System;
using System.Collections.Generic;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Domain
{
    public class Buses
    {
        public int Id { get; set; }

        public string BusDriver { get; set; }
        public string BusDriverAssistant { get; set; }

        public int BusNo { get; set; }
        public string BusNumber { get; set; }

        public int Capacity { get; set; }
        public int ExtraCapacity { get; set; } 

        public string BusModel { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }

        public DateTime AddedDate { get; set; }

        public string TripType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public ICollection<Customers> Customers { get; set; }

        public string BusDisplay =>
            $"🚌 {string.Format(localizer.Get("BusDisplayFormat"), BusNo, BusModel, BusNumber)}";
        
        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.BusEnrollmentLocal.AddBusFormLocalization");
    }
}
