namespace ToDo.App.Dto.User
{
    public sealed class CreateUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
