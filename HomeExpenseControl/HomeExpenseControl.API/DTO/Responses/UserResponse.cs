namespace HomeExpenseControl.Api.DTO.Responses
{
    public class UserResponse
    {
        public Guid IdUser { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }

        public UserResponse(Guid idUser, string userName, int userAge)
        {
            IdUser = idUser;
            UserName = userName;
            UserAge = userAge;
        }
    }
}
