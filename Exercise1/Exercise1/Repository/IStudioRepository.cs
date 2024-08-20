using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public interface IStudioRepository
    {
        void AddStudio(Studio studio);
        void DeleteStudio(int id);
        Studio GetStudio(string name);
        IEnumerable<Studio> GetAll();

        void UpdateStudio(Studio studio);

    }
}
