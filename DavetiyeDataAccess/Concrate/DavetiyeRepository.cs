using DavetiyeDataAccess.Abstract;
using DavetiyeDataAccess.Data;
using DavetiyeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavetiyeDataAccess.Concrate
{
    
    public class DavetiyeRepository : IDavetiyeRepository
    {
      
        public Davetiye Add(Davetiye entites)
        {
            using (var db=new DavetiyeContext())
            {
                db.Davetiyes.Add(entites);
                db.SaveChanges();
                return entites;
            }
          
        }
        public void Delete(int id)
        {
            using (var db = new DavetiyeContext())
            {
                var x = GetByID(id);
                db.Davetiyes.Remove(x);
                db.SaveChanges();
            }
             
        }

        public List<Davetiye> Durum(bool status)
        {
            using (var db = new DavetiyeContext())
            {
                return db.Davetiyes.Where(x => x.gelmeDurumu == status).ToList();
            }
        }

        public Davetiye GetByID(int id)
        {
            using (var db = new DavetiyeContext())
            {
                return db.Davetiyes.FirstOrDefault(x => x.id == id);
            }
        }

        public List<Davetiye> GetList()
        {
            using (var db = new DavetiyeContext())
            {
                return db.Davetiyes.ToList();
            }

        }

        public Davetiye Update(Davetiye entites)
        {
            using (var db = new DavetiyeContext())
            {
                db.Davetiyes.Update(entites);
                db.SaveChanges();
                return entites;
            }
          
        }
    }
}
