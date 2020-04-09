using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    public class ClinkerRepository
    {
        private static List<Clinker> _clinkers = new List<Clinker>()
        {
            new Clinker()
            {
                Id = 1,
                Name = "Gab",
                Interests = {"frisbee", "gaming", "guitar"},
                Services =
                {
                    new LineItem
                    {
                        Service = "handyman",
                        IsRequested = false
                    }
                },
            }
        };

        public void Add(Clinker clinker)
        {
            clinker.Id = _clinkers.Max(x => x.Id) + 1;
            _clinkers.Add(clinker);
        }

        //public Clinker Update(Clinker clinker)
        //{
        //    var clinkerToUpdate = GetById(clinker.Id);

        //    clinkerToUpdate.NumberInStock += pickle.NumberInStock;

        //    return clinkerToUpdate;
        //}

        public Clinker GetById(int id)
        {
            return _clinkers.FirstOrDefault(c => c.Id == id);
        }
    }
}
