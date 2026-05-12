namespace Practice.Web.Codes
{

    // Unit of Work Pattern Implementation
    // Work with any object type, not just Product, so it can be used for any entity in the application.
    // This class is responsible for managing database transactions and ensuring that all operations are executed as a single unit of work.
    public class UnitOfWorks
    {

        // Repositories for different entities, which will be used to perform database operations related to those entities.
        public Repository<Product> Products { get; set; }
        //public Repository<Order> Orders { get; set; }


        //public void Insert(object entity)
        //{
        //    // Code to insert entity into the database
        //}
        //public void Update(object entity)
        //{
        //    // Code to update entity in the database
        //}
        //public void Delete(object entity)
        //{
        //    // Code to delete entity from the database
        //}
        public void save()
        {
            // Code to commit all changes to the database
        }
    }
}
