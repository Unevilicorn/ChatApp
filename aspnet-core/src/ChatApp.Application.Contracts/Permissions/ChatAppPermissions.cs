namespace ChatApp.Permissions
{
    public static class ChatAppPermissions
    {
        public const string GroupName = "ChatApp";

        public static class Messages
        {
            public const string Default = GroupName + ".Messages";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}