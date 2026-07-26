using System;

namespace TakeTicket.Domain
{
    public class TicketScanLog
    {
        public int TicketId { get; set; }
        public DateTime ScanTime { get; set; }
        public string DeviceName { get; set; }
    }
}
