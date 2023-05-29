using OnlineShop.Application.Requests.Categories;


namespace OnlineShop.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public UpdateCategoryRequest request;
        public Type type;

        public EntityNotFoundException(int id, Type type)
            : base($"Entity of type {type.Name} who has id {id} not found")
        {
        }

        public EntityNotFoundException(UpdateCategoryRequest request, Type type)
        {
            this.request = request;
            this.type = type;
        }
    }
}
