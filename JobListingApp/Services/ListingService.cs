using JobListingApp.Models;
using JobListingApp.Dto;
using JobListingApp.Persistance;
using JobListingApp.WebApi.Persistance;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using JobListingApp.WebApi.Exceptions;
using AutoMapper;


namespace JobListingApp.WebApi.Services
{
    public class ListingService : IListingService
    {
        private readonly IBoardUnitOfWork _uow;
        private readonly IMapper _mapper;
        //injection constructor
        public ListingService(IBoardUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }
        public ListingService(IBoardUnitOfWork context, IMapper mapper)
        {
            this._uow = context;
            this._mapper = mapper;
        }


        public List<ListingDto> GetAll()
        {
            var listings = _uow.ListingRepository.GetAll();
            List<ListingDto> result = _mapper.Map<List<ListingDto>>(listings);
            return result;
        }


        public ListingDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }
            var l = _uow.ListingRepository.Get(id);
            if (l == null)
            {
                throw new NotFoundException("Could not find listing ");
            }
            //var result = new ListingDto()
            //{
            //    Id = l.Id,
            //    Title = l.Title,
            //    Location = l.Location,
            //    Description = l.Description,
            //    Company = l.Company,
            //    PostedDate = l.PostedDate

            //};
            var result = _mapper.Map<ListingDto>(l);
            return result;
        }

        public int Create(CreateListingDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No Lisitng data");
            }
            var id = _uow.ListingRepository.GetMaxId() + 1;
            var listing = _mapper.Map<Listing>(dto);
            listing.Id = id;
            _uow.ListingRepository.Insert(listing);
            _uow.Commit();
            return id;
        }

        public void Update(UpdateListingDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No Lisitng data");
            }
            var l = _uow.ListingRepository.Get(dto.Id);
            if (l == null)
            {
                throw new NotFoundException("Could not find");
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
                throw new NotFoundException("Could not find this listing ");

            }

            _uow.ListingRepository.Delete(listing);
            _uow.Commit();

        }
    }
}
