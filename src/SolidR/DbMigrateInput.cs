namespace SolidR
{
    public class DbMigrateInput
    {
        public string Command { get; set; } = "up";
        public bool Update => Command.ToLower().Equals("up");
        public bool Downgrade => Command.ToLower().Equals("down");
    }
}