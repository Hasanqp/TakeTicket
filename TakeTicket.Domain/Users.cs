using System;
using System.Collections.Generic;

namespace TakeTicket.Domain
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AddedDate { get; set; }

        // Navigations
        public virtual List<UsersRoles> UsersRoles { get; set; }

        // Rigster & Recovery user account
        public string RecoveryCode { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public DateTime? RecoveryCodeExpiry { get; set; }
        public DateTime? RecoveryCodeSentAt { get; set; }
        public DateTime? NextRecoveryCodeRequestAt { get; set; }
    }
}
