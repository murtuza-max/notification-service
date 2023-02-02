namespace DeleteUser.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
