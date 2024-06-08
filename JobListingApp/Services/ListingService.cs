using JobListingApp.Models;
using JobListingApp.Dto;
using JobListingApp.Persistance;
using JobListingApp.WebApi.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobListingApp.WebApi.Services
{
    public class ListingService : IListingService
    {
        private readonly IBoardUnitOfWork _uow;

        //injection constructor
        public ListingService(IBoardUnitOfWork context)
        {
            this._uow = context;
        }

        public List<ListingDto> GetAll()
        {
            var listings = _uow.ListingRepository.GetAll();

            List<ListingDto> result = new List<ListingDto>();
            foreach (var l in listings)
            {
                result.Add(new ListingDto()
                {
                    Id = l.Id,
                    Title = l.Title,
                    Location = l.Location,
                    Description = l.Description,
                    Company = l.Company,
                    PostedDate = l.PostedDate
                    //CategoryId = l.Category.Id

                });
            }
            return result;
        }



        public ListingDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is less than zero");
            }
            var l = _uow.ListingRepository.Get(id);
            if (l == null)
            {
                throw new Exception($"Could not find listing with id = {id}");
            }
            var result = new ListingDto()
            {
                Id = l.Id,
                Title = l.Title,
                Location = l.Location,
                Description = l.Description,
                Company = l.Company,
                PostedDate = l.PostedDate


            };
            return result;
        }

        public int Create(CreateListingDto dto)
        {
            if (dto == null)
            {
                throw new Exception("No Lisitng data");
            }
            var id = _uow.ListingRepository.GetMaxId() + 1;

            var listing = new Listing()
            {
                Id = id,
                Title = dto.Title,
                Location = dto.Location,
                Description = dto.Description,
                Company = dto.Company,
                PostedDate = dto.PostedDate
            };

            _uow.ListingRepository.Insert(listing);
            _uow.Commit();
            return id;
        }

        public void Update(UpdateListingDto dto)
        {
            if (dto == null)
            {
                throw new Exception("No Lisitng data");
            }
            var l = _uow.ListingRepository.Get(dto.Id);
            if (l == null)
            {
                throw new Exception($"Could not find");
            }
            l.Title = dto.Title;
            l.Location = dto.Location;
            l.Description = dto.Description;
            l.Company = dto.Company;
            l.PostedDate = dto.PostedDate;
            _uow.Commit();

        }

        public void Delete(int id)
        {
            var listing = _uow.ListingRepository.Get(id);
            if (listing == null)
            {
                throw new Exception($"Could not find listing with id = {id}");

            }

            _uow.ListingRepository.Delete(listing);
            _uow.Commit();

        }
    }
}
