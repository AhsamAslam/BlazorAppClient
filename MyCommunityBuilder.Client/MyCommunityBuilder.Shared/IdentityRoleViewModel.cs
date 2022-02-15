namespace MyCommunityBuilder.Shared
{
    public class IdentityRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }

    public class AssignedRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool MyProperty { get; set; }
    }
}
