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
            },

             new Clinker()
            {
                Id = 2,
                Name = "Con",
                Interests = {"frisbee", "gaming", "guitar"},
                Services =
                {
                    new LineItem
                    {
                        Service = "plumber",
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

        public void addServiceToClinker(Clinker selectedClinker, string skill)
        {
            selectedClinker.Services.Add(new LineItem 
            {
                Service = skill,
                IsRequested = false
            });
        }


        public List<Clinker> showAllClinkersByService(string service)
        {
            // Service.service should reference that the string inside the LineItem matches the inputted string

            //var filteredListofServiceClinkers = serviceClinker.Services.Where(c => c.Service == service);
            var filteredListofServiceClinkers = _clinkers.Where(clinker => clinker.Services.Any(s => s.Service == service));
            return filteredListofServiceClinkers.ToList();

            //var luckyClinker = filteredListofServiceClinkers.First(); // business logic
            //var luckyClinkersService = luckyClinker.Services.Single(s => s.Service == service);

            //Below code should access the matching service from the selected service, and change it's 
            //isRequested value to true
            //luckyClinkersService.IsRequested = true;
            //now create a method that calls this in the controller
        }

        //public Clinker Update(Clinker clinker)
        //{
        //    var clinkerToUpdate = GetById(clinker.Id);

        //    clinkerToUpdate.NumberInStock += pickle.NumberInStock;

        //    return clinkerToUpdate;
        //}

        //var clinkerId = _clinkers.FirstOrDefault(c => c.Id == id);

        public Clinker GetById(int id)
        {
            return _clinkers.FirstOrDefault(c => c.Id == id);
        }

        public List<LineItem> getSingleClinkersServices(int id)
        {
            var selectedClinker = _clinkers.FirstOrDefault(c => c.Id == id);
            return selectedClinker.Services;
        }

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }

        private static List<Clinker> sameInterestClinkers = new List<Clinker>();
        public List<Clinker> clinkersByInterest(string interest)
        {
            //var matchingClinkers = _clinkers.GroupBy(clinker =>
            //clinker.Interests).FirstOrDefault(interest);

            var matchingClinkers = _clinkers.Where(c => c.Interests.Contains(interest)).ToList();

            foreach (var matchingClinker in matchingClinkers)
            {
                sameInterestClinkers.Add(matchingClinker);
            }
            return sameInterestClinkers;
        }

    }
}
