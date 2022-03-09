using DavetiyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavetiyeBusiness.Abstract
{
    public interface IDavetiyeService
    {
        List<Davetiye> GetList();
        Davetiye GetByID(int id);
        Davetiye Add(Davetiye entites);
        Davetiye Update(Davetiye entites);
        void Delete(int id);
        List<Davetiye> Durum(bool status);

    }
}
