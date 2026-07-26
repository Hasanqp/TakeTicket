using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using TakeTicket.Domain;
using TakeTicket.Domain.Enums;
using TakeTicket.Domain.Repositories;
using TakeTicket.Data;
using TakeTicket.Shared.Localization;
using TakeTicket.Shared.Paths;

namespace TakeTicket.Application.Services
{
    public class TicketService
    {
        private readonly IDataHelper<Ticket> ticketHelper;
        private readonly ITicketRepository ticketRepository;

        public TicketService(IDataHelper<Ticket> ticketHelper, ITicketRepository ticketRepository)
        {
            this.ticketHelper = ticketHelper;
            this.ticketRepository = ticketRepository;
        }

        private Bitmap GenerateQrCode(int ticketId)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {

                var qrData = qrGenerator.CreateQrCode($"TICKET-{ticketId}", QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrData);
                return qrCode.GetGraphic(5);
            }
        }

        private Bitmap GenerateTicketImage(Ticket ticket, Customers customer, Bitmap qrImage)
        {
            int W = 700, H = 240;
            Bitmap bmp = new Bitmap(W, H);

            using Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Colors
            bool isMain = ticket.TicketType == "Main";
            Color accentColor = isMain ? Color.FromArgb(26, 86, 160)   // deep blue
                                       : Color.FromArgb(200, 118, 10); // amber
            Color gold = Color.FromArgb(200, 150, 10);
            string reservationTypeText = 
                isMain 
                ? _localizer.Get("MainType")
                : _localizer.Get("ReserveType");

            string tripTypeDisplay = customer.TripType switch
            {
                "OneWay" => _localizer.Get("OneWay"),
                "RoundTrip" => _localizer.Get("RoundTrip"),
                _ => customer.TripType ?? "—"
            };
            string reservationDisplay =
                customer.ReservationType ==
                ReservationType.Main
                ? _localizer.Get("MainType")
                : _localizer.Get("ReserveType");

            // Card background
            using var cardBrush = new SolidBrush(Color.White);
            FillRoundedRect(g, cardBrush, new Rectangle(0, 0, W, H), 16);
            using var cardPen = new Pen(Color.FromArgb(60, 0, 0, 0), 1);
            DrawRoundedRect(g, cardPen, new Rectangle(0, 0, W - 1, H - 1), 16);

            // Header bar
            int headerH = 42;
            using var headerBrush = new SolidBrush(accentColor);
            FillRoundedRectTop(g, headerBrush, new Rectangle(0, 0, W, headerH), 16);

            using var titleFont = new Font("Tahoma", 12f, FontStyle.Bold);
            g.DrawString(_localizer.Get("BoardingPass"), titleFont, Brushes.White,
                16f,
                11f);

            // Badge (top-right)
            using var badgeFont = new Font("Tahoma", 9f, FontStyle.Bold);
            SizeF bSz = g.MeasureString(reservationTypeText, badgeFont);
            float bX = W - bSz.Width - 18, bY = 10f;
            using var badgeFill = new SolidBrush(Color.FromArgb(50, 255, 255, 255));
            g.FillRectangle(badgeFill, bX - 6, bY - 2, bSz.Width + 12, bSz.Height + 4);
            g.DrawString(reservationTypeText, badgeFont, Brushes.White, bX, bY + 1);

            // Left panel content
            int divX = W - 195;
            float lx = 18f, ly = headerH + 10f;
            using var labelFont = new Font("Tahoma", 7.5f, FontStyle.Regular);
            using var valFont = new Font("Tahoma", 12f, FontStyle.Bold);
            using var valFontLg = new Font("Tahoma", 17f, FontStyle.Bold);
            using var darkBrush = new SolidBrush(Color.FromArgb(20, 20, 30));
            using var grayBrush = new SolidBrush(Color.FromArgb(130, 130, 145));

            // Row helper
            void DrawField(string label, string value, float x, float y, bool large = false)
            {
                g.DrawString(label.ToUpper(), labelFont, grayBrush, x, y);
                g.DrawString(value, large ? valFontLg : valFont, darkBrush, x, y + 12f);
            }

            // Name (full width)
            DrawField(_localizer.Get("PassengerLabel"),
                customer.Name ?? "—", lx, ly, large: true);
            ly += 40f;

            // Passport | Nationality | Phone
            DrawField(_localizer.Get("PassportLabel"), customer.Passport ?? "—", lx, ly);
            DrawField(_localizer.Get("NationalityLabel"), customer.Nationality ?? "—", lx + 130f, ly);
            DrawField(_localizer.Get("PhoneLabel"), customer.PhoneNumber ?? "—", lx + 280f, ly);
            ly += 38f;

            // Start Date | End Date | Trip Type
            DrawField(_localizer.Get("StartLabel"), customer.StartDate.ToString("dd-MM-yyyy"), lx, ly);
            DrawField(_localizer.Get("EndLabel"), customer.FinishDate.ToString("dd-MM-yyyy"), lx + 130f, ly);
            DrawField(_localizer.Get("TripLabel"), tripTypeDisplay, lx + 280f, ly);
            ly += 38f;

            // Seat | Reservation Type
            DrawField(_localizer.Get("TicketNoLabel"), customer.SeatLabel, lx, ly);
            DrawField(_localizer.Get("TypeLabel"), reservationDisplay, lx + 130f, ly);

            // Bottom decorative stripe
            int stripeH = 7;
            var stripeRect1 = new Rectangle(0, H - stripeH, (int)(divX * 0.62f), stripeH);
            var stripeRect2 = new Rectangle(stripeRect1.Width, H - stripeH, divX - stripeRect1.Width, stripeH);
            using var stripeBrush1 = new SolidBrush(accentColor);
            using var stripeBrush2 = new SolidBrush(gold);
            FillRoundedRectBottomLeft(g, stripeBrush1, stripeRect1, 4);
            g.FillRectangle(stripeBrush2, stripeRect2);

            // Footer note
            using var noteFont = new Font("Tahoma", 7f, FontStyle.Italic);
            g.DrawString(_localizer.Get("FooterNote"),
                         noteFont, grayBrush, lx, H - stripeH - 14f);

            // Dashed divider
            using var dashPen = new Pen(Color.FromArgb(160, 160, 175), 1.2f)
            { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
            g.DrawLine(dashPen, divX, headerH + 4, divX, H - stripeH - 2);

            // Notch circles
            using var notchBrush = new SolidBrush(Color.FromArgb(230, 235, 240));
            g.FillEllipse(notchBrush, divX - 9, headerH - 2, 18, 18);
            g.FillEllipse(notchBrush, divX - 9, H - stripeH - 12, 18, 18);

            // Right panel
            float rx = divX + 14f, ry = headerH + 10f;
            using var accentBrush = new SolidBrush(accentColor);

            // Seat number (big)
            g.DrawString(_localizer.Get("SeatLabel"), labelFont, grayBrush, rx, ry);
            using var seatFont = new Font("Tahoma", 34f, FontStyle.Bold);
            g.DrawString(ticket.SeatNumber ?? customer.SeatLabel, seatFont, accentBrush, rx, ry + 12f);

            // Ticket ID
            ry += 70f;
            g.DrawString(_localizer.Get("TicketIdLabel"), labelFont, grayBrush, rx, ry);
            using var monoFont = new Font("Courier New", 9f, FontStyle.Regular);
            g.DrawString(ticket.Id.ToString().PadLeft(11, '0'), monoFont, darkBrush, rx, ry + 12f);

            // QR code
            if (qrImage != null)
            {
                int qrSize = 72, qrX = divX + (195 - qrSize) / 2;
                int qrY = H - stripeH - qrSize - 10;
                g.DrawImage(qrImage, qrX, qrY, qrSize, qrSize);
            }

            return bmp;
        }

        // Drawing helpers
        private void FillRoundedRect(Graphics g, Brush brush, Rectangle r, int radius)
        {
            using var path = BuildRoundedPath(r, radius);
            g.FillPath(brush, path);
        }

        private void DrawRoundedRect(Graphics g, Pen pen, Rectangle r, int radius)
        {
            using var path = BuildRoundedPath(r, radius);
            g.DrawPath(pen, path);
        }

        private void FillRoundedRectTop(Graphics g, Brush brush, Rectangle r, int radius)
        {
            using var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.Left, r.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Top, radius * 2, radius * 2, 270, 90);
            path.AddLine(r.Right, r.Bottom, r.Left, r.Bottom);
            path.CloseFigure();
            g.FillPath(brush, path);
        }

        private void FillRoundedRectBottomLeft(Graphics g, Brush brush, Rectangle r, int radius)
        {
            using var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(r.Left, r.Top, r.Right, r.Top);
            path.AddLine(r.Right, r.Bottom, r.Left + radius, r.Bottom);
            path.AddArc(r.Left, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }

        private System.Drawing.Drawing2D.GraphicsPath BuildRoundedPath(Rectangle r, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.Left, r.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Top, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.Left, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private string SaveTicketImage(int ticketId, Bitmap image)
        {
            Directory.CreateDirectory(AppPaths.TicketsFolder);

            var path = Path.Combine(
                AppPaths.TicketsFolder,
                $"ticket_{ticketId}.png");

            image.Save(path, ImageFormat.Png);

            return path;
        }

        public async Task<string> CreateFullTicketAsync(Customers customer)
        {
            if (string.IsNullOrWhiteSpace(customer.SeatNumber))
                throw new Exception(_localizer.Get("NoSeatNumber"));

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                throw new Exception(
                    _localizer.Get("PhoneMissing"));

            var exists = await ticketRepository
                .GetByCustomerIdAsync(customer.Id);

            if (exists.Any())
                throw new Exception(
                    _localizer.Get("TicketAlreadyCreated"));

            var ticket = new Ticket
            {
                CustomerId = customer.Id,
                SeatNumber = customer.SeatNumber,
                TicketType = customer.ReservationType.ToString(),
                CreatedAt = DateTime.Now,
                ValidationCode = Guid.NewGuid().ToString("N")
            };

            await ticketHelper.AddAsync(ticket);

            using var qr = GenerateQrCode(ticket.Id);
            using var image = GenerateTicketImage(ticket, customer, qr);
            var path = SaveTicketImage(ticket.Id, image);

            return path;
        }

        public async Task<string?> GetTicketPathAsync(Customers customer)
        {
            var ticket =
                (await ticketRepository.GetByCustomerIdAsync(customer.Id))
                .FirstOrDefault();

            if (ticket == null)
                return null;

            return Path.Combine(
                AppPaths.TicketsFolder,
                $"ticket_{ticket.Id}.png");
        }

        private readonly Localizer _localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Services.TicketServiceLocal.TicketServiceLocal");
    }
}
