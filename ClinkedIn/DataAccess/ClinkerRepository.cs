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
                Friends =
                {
                    new Clinker()
                    {
                        Id = 3,
                        Name = "Jakub",
                        Interests = {"tattoos", "dad-ing"},
                        Services =
                        {
                            new LineItem
                            {
                                Service = "painting",
                                IsRequested = false
                            }
                        },
                    },
                    new Clinker()
                    {
                        Id = 4,
                        Name = "Zoeee",
                        Interests = {"pies", "sarcasm"},
                        Services =
                        {
                            new LineItem
                            {
                                Service = "teaching",
                                IsRequested = false
                            },
                            new LineItem
                            {
                                Service = "coding",
                                IsRequested = false
                            }
                        },
                    },
                },
                Enemies =
                {
                    new Clinker()
                    {
                        Id = 5,
                        Name = "Guy Fieri",
                        Interests = {"excess", "hair-dye"},
                        Services =
                        {
                            new LineItem
                            {
                                Service = "cooking",
                                IsRequested = false
                            }
                        }
                    }
                }
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
            var filteredListofServiceClinkers = _clinkers.Where(clinker => clinker.Services.Any(s => s.Service == service));
            return filteredListofServiceClinkers.ToList();
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

        public List<Clinker> getFriendsOfClinker(int id)
        {
            var userClinker = _clinkers.FirstOrDefault(c => c.Id == id);
            return userClinker.Friends;
        }

        public List<Clinker> AddFriend(Clinker friendToAdd, int userId)
        {
            var currentUser = _clinkers.FirstOrDefault(c => c.Id == userId);
            currentUser.Friends.Add(friendToAdd);
            return currentUser.Friends;
        }

        public List<Clinker> DeleteFriend(Clinker clinkerToDelete, int userId)
        {
            var currentUser = _clinkers.FirstOrDefault(c => c.Id == userId);
            var friendToDelete = currentUser.Friends.FirstOrDefault(f => f.Id == clinkerToDelete.Id);
            currentUser.Friends.Remove(friendToDelete);
            currentUser.Enemies.Add(friendToDelete);
            var remainingFriends = currentUser.Friends;
            return remainingFriends;
        }
    }
}
