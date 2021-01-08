using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Enums;
using Infrastructure.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations
{
    public class ChallengeFacade : FacadeBase, IChallengeFacade
    {
        private readonly IChallengeService _challengeService;
        private readonly IUserService _userService;
        
        public ChallengeFacade(IUnitOfWorkProvider provider, IChallengeService challengeService, IUserService userService) : base(provider)
        {
            _challengeService = challengeService;
            _userService = userService;
        }

        public async Task Create(int count, int userId, ChallengeType type)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var user = await _userService.GetAsync(userId);
                var startDate = DateTime.Today;
                var endDate = type switch
                {
                    ChallengeType.Daily => startDate.AddDays(1),
                    ChallengeType.Monthly => startDate.AddMonths(1),
                    ChallengeType.Weekly => startDate.AddDays(7),
                    ChallengeType.Yearly => startDate.AddYears(1),
                    _ => throw new ArgumentException("Unknown challenge type")
                };
                var challengeDto = new ChallengeDto()
                {
                    User = user,
                    Finished = false,
                    StartDate = startDate,
                    EndDate = endDate,
                    TripCount = count,
                    Type = type
                };
                await _challengeService.Create(challengeDto);
                await uow.CommitAsync();
            }
        }

        public async Task<ChallengeDto> GetAsync(int id)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                return await _challengeService.GetAsync(id);
            }
        }

        public async Task Update(ChallengeDto challengeDto)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                _challengeService.Update(challengeDto);
                await uow.CommitAsync();
            }
        }

        public async Task Delete(int challengeId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                await _challengeService.Delete(challengeId);
            }
        }

        public async Task FinishChallenge(int challengeId)
        {
            using (var uow = unitOfWorkProvider.Create())
            {
                var challenge = await _challengeService.GetAsync(challengeId);
                challenge.Finished = true;
                _challengeService.Update(challenge);
                await uow.CommitAsync();
            }
        }

        public List<ChallengeDto> ListAllUsersChallenges(int userId)
        {
            return _challengeService.ListAll(userId);
        }

        public List<ChallengeDto> ListSortedByType(int userId, ChallengeType type)
        {
            return _challengeService.ListSortedByType(userId, type);
        }

        public List<ChallengeDto> ListFinishedChallenges(int userId)
        {
            return _challengeService.ListFinished(userId, true);
        }
    }
}