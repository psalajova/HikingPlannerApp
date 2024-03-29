﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces
{
    public interface ITripFacade : IDisposable
    {
        Task AddTripLocationToTripAsync(int locationId, int tripId);
        List<TripDto> GetAllTripsSorted();
        List<TripDto> GetAllUserTrips(int userId);
        Task CreateAsync(TripDto tripDto);
        Task<TripDto> GetTripByIdAsync(int id);
        Task UpdateAsync(TripDto tripDto);
        Task DeleteAsync(int tripId);
        Task CreateUserTripAsync(UserTripDto userTrip);
    }
}
