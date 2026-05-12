namespace Practice.Web.Codes
{
    // Repository Pattern Implementation
    // This class is responsible for handling all database operations related to the Product entity.
    // Representaion of Database, save in local memory
    // T is generic type parameter, which allows this repository to work with any type of entity (not just Product).
    public class Repository<T>
    {
        public void AddProduct(T entity)
        {
            // Code to add entity to the database
        }
        public void UpdateProduct(T entity)
        {
            // Code to update entity in the database
        }
        public void DeleteProduct(T entity)
        {
            // Code to delete entity from the database
        }
        public T GetProductById(int id)
        {
            // DB থেকে single entity আনা
            return default(T);
        }
        public List<T> GetAllProducts()
        {
            // Code to get all entities from the database
            return new List<T>();
        }
    }
}
