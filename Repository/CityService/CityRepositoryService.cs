using Context;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.CityService
{
    public class CityRepositoryService : BaseRepository<Entity.City.City>,ICityRepositoryService
    {
        private readonly ApplicationDbContext _context;
        public CityRepositoryService(ApplicationDbContext context) : base(context) 
        {

        }
    }
}
