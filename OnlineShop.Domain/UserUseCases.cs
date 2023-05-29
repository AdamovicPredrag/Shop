namespace OnlineShop.Domain
{
    public class UserUseCases : Entity
    {
        public int IdUser { get; set; }
        public int IdUseCase { get; set; }
        public virtual User User { get; set; }
    }
}
