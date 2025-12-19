namespace HomeExpenseControl.Domain.Entities
{
    public class User
    {
        public Guid idUser { get; private set; }
        public string UserName { get; private set; }
        public int UserAge { get; private set; }

        public ICollection<Transaction> Transactions { get; }

        protected User() { }

        public User(string userName, int userAge)
        {
            SetUserName(userName);
            SetUserAge(userAge);
        }

        public void SetUserName(string userName)
        {
            if(string.IsNullOrEmpty(userName))
                throw new ArgumentException("Nome obrigatório");

            UserName = userName;
        }

        public void SetUserAge(int userAge)
        {
            if(userAge <= 0) 
                throw new ArgumentException("A idade deve ser maior que zero");

            UserAge = userAge;
        }
    }
}
