using DavetiyeBusiness.Abstract;
using DavetiyeDataAccess.Abstract;
using DavetiyeDataAccess.Data;
using DavetiyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavetiyeBusiness.Concrete
{
   public class DavetiyeService : IDavetiyeService
    {
        private IDavetiyeRepository rep;
        public DavetiyeService(IDavetiyeRepository _rep)
        {
            rep = _rep;
        }
        public Davetiye Add(Davetiye entites)
        {
            return rep.Add(entites);

        }

        public void Delete(int id)
        {
            rep.Delete(id);
            
        }

        public List<Davetiye> Durum(bool status)
        {
            return rep.Durum(status);
        }

        public Davetiye GetByID(int id)
        {
            return rep.GetByID(id);
        }

        public List<Davetiye> GetList()
        {
            return rep.GetList();
        }

        public Davetiye Update(Davetiye entites)
        {
            return rep.Update(entites);
        }
    }
}
