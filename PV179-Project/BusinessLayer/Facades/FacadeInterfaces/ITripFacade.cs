﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces
{
    public interface ITripFacade : IDisposable
    {
        Task AddTripLocationToTrip(TripLocationDto tripLocationDto, TripDto tripDto);

        List<TripDto> GetAllTripsSorted();

        List<TripDto> GetAllUserTrips(int userId);

        Task Create(TripDto tripDto);

        Task<TripDto> GetTripByIdAsync(int id);

        Task Update(TripDto tripDto);

        Task Delete(int tripId);

        void CheckIfTripExists(int id);
    }
}
