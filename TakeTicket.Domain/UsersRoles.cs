namespace TakeTicket.Domain
{
    public class UsersRoles
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public bool Value { get; set; }

        // Navigations
        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
