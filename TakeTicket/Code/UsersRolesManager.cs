namespace TakeTicket.Infrastructure.Helper
{
    public static class UsersRolesManager
    {
        private static Dictionary<string, bool> RolesList = new Dictionary<string, bool>();

        public static void Register(string roleKey, bool roleValue)
        {
            RolesList[roleKey] = roleValue;
        }

        public static bool GetRole(string roleKey)
        {
            return RolesList.TryGetValue(roleKey, out bool value) && value;
        }

        public static void ClearRoles()
        {
            RolesList.Clear();
        }
    }
}
