using AutoMapper;
//using JobListingApp.Application.Dto;
using JobListingApp.Domain.Contracts;
using JobListingApp.Domain.Exceptions;
using JobListingApp.Domain.Models;
using JobListingApp.SharedKernel.Dto;
using System.Reflection;


namespace JobListingApp.Application.Services
{
    public class ListingService : IListingService
    {
        private readonly IBoardUnitOfWork _uow;
        private readonly IMapper _mapper;
        //injection constructor
       
        public ListingService(IBoardUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }


        public List<ListingDto> GetAll()
        {
            var listings = _uow.ListingRepository.GetAll();//.ToList();
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
            listing.ImageUrl = String.IsNullOrEmpty(dto.ImageUrl)
             ? "/images/no-image-icon.png"
             : dto.ImageUrl;
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
            l.ImageUrl = String.IsNullOrEmpty(dto.ImageUrl)
             ? "/images/no-image-icon.png"
             : dto.ImageUrl;
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
