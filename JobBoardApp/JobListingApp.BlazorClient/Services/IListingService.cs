﻿using JobListingApp.SharedKernel.Dto;

namespace JobListingApp.BlazorClient.Services
{
    public interface IListingService
    {
        Task<IEnumerable<ListingDto>> GetAll();
        Task<ListingDto> GetListingById(int id);
    }
}