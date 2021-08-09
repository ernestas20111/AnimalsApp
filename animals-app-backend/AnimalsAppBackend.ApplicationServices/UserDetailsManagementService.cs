using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.ApplicationServices.Mappers;
using AnimalsAppBackend.DataAccess;
using AnimalsAppBackend.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices
{
    public class UserDetailsManagementService : IUserDetailsManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDetailsManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UserDetailsDto>> GetUserDetails(Guid id)
        {
            var userDetails = await _unitOfWork.UserDetails.Find(userDetails=> userDetails.UserId==id).ToListAsync();
            if (userDetails is null)
            {
                return Result<UserDetailsDto>.CreateErrorResult($"User details with id {id} was not found.");
            }

            return Result<UserDetailsDto>.Create(userDetails.Select(userDetails => UserDetailsMapper.MapUserDetailsDtoFromUserDetails(userDetails)).FirstOrDefault());
        }

        public async Task<Result<string>> RemoveUserDetails(Guid id)
        {
            var userDetails = await _unitOfWork.UserDetails.GetById(id);
            if (userDetails is null)
            {
                return Result<string>.CreateErrorResult($"User details with id {id} was not found.");
            }

            try
            {
                _unitOfWork.UserDetails.Remove(userDetails);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(id.ToString());
        }

        public async Task<Result<UserDetailsDto>> AddUserDetails(UserDetailsDto userDetailDto)
        {
            UserDetails newUserDetail;
            try
            {
                newUserDetail = _unitOfWork.UserDetails.Add(UserDetailsMapper.MapUserDetailsFromUserDetailsDto(userDetailDto));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<UserDetailsDto>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<UserDetailsDto>.Create(UserDetailsMapper.MapUserDetailsDtoFromUserDetails(newUserDetail));
        }

        public async Task<Result<string>> UpdateUserDetails(UserDetailsDto userDetailsDto)
        {
            var userDetails = await _unitOfWork.UserDetails.GetById(userDetailsDto.Id);
            if (userDetails is null)
            {
                return Result<string>.CreateErrorResult($"User details with id {userDetailsDto.Id} was not found.");
            }

            try
            {
                UserDetailsMapper.MapUserDetailsFromUserDetailsDto(userDetails, userDetailsDto);
                _unitOfWork.UserDetails.Update(userDetails);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(userDetailsDto.Id.ToString());
        }
    }
}
