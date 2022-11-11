using Microsoft.EntityFrameworkCore;

namespace BethanysPies.Models
{
    public class PieRepository :  IPieRepository
    {
        private readonly BethanysPiesDbContext _bethanysPiesDbContext;

        public PieRepository(BethanysPiesDbContext bethanysPiesDbContext)
        {   
            _bethanysPiesDbContext = bethanysPiesDbContext;
        }


        public IEnumerable<Pie> AllPies
        {
            get { return _bethanysPiesDbContext.Pies.Include(c => c.Category); }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        { 
            get { return _bethanysPiesDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek); }
        }

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPiesDbContext.Pies.FirstOrDefault(p => p.PieId == pieId); 
        }
    }
}
