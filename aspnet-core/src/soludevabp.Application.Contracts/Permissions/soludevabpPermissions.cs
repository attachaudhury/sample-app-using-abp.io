namespace soludevabp.Permissions
{
    public static class soludevabpPermissions
    {
        public const string GroupName = "soludevabp";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static class Companies
        {
            public const string Default = GroupName + ".Companies";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Listings
        {
            public const string Default = GroupName + ".Listings";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}