using AppEnvironment;
using Entity.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.CityBusinessService
{
    public interface ICityBusinessService
    {
        Result<City> Create(CityVM model);
        Result<City> Edit(int id, CityVM ModelDTO);
        Result Remove(int id);
        Result<List<City>> GetAll();
        Result<City> GetById(int id);
    }
}
