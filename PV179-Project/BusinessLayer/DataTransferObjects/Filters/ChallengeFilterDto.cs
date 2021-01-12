using System;
using BusinessLayer.DataTransferObjects.QueryDTOs;
using DataAccessLayer.Enums;

namespace BusinessLayer.DataTransferObjects.Filters
{
    public class ChallengeFilterDto : FilterDtoBase
    {
        public string UserId    { get; set; }
        public string Type      { get; set; }
        public string Finished  { get; set; }
        public string StartDate { get; set; }
        
    }
}