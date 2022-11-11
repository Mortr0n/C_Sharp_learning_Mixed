namespace BethanysPies.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly BethanysPiesDbContext _bethanysPiesDbContext;

        public CategoryRepository(BethanysPiesDbContext bethanysPiesDbContext)
        {
            _bethanysPiesDbContext = bethanysPiesDbContext;
        }

        public IEnumerable<Category> AllCategories =>_bethanysPiesDbContext.Categories.OrderBy(p => p.CategoryName); 
        
        
        
    }
}
