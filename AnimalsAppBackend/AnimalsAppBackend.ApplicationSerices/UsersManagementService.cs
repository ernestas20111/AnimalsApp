using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationSerices.Dtos;
using AnimalsAppBackend.ApplicationSerices.Mappers;
using AnimalsAppBackend.ApplicationSerices.Responses;
using AnimalsAppBackend.DataAccess;
using AnimalsAppBackend.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices
{
    public class UsersManagementService : IUsersManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<UserDto>>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAll().ToListAsync();
            if (users is null || users.Count == 0)
            {
                return Result<List<UserDto>>.CreateErrorResult($"No users were found.");
            }

            return Result<List<UserDto>>.Create(users.Select(user => UserMapper.MapUserDtoFromUser(user)).ToList());
        }

        public async Task<Result<UserDto>> GetUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user is null)
            {
                return Result<UserDto>.CreateErrorResult($"User with id {id} was not found.");
            }

            return Result<UserDto>.Create(UserMapper.MapUserDtoFromUser(user));
        }

        public async Task<Result<string>> RemoveUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user is null)
            {
                return Result<string>.CreateErrorResult($"User with id {id} was not found.");
            }

            try
            {
                _unitOfWork.Users.Remove(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(id.ToString());
        }

        public async Task<Result<UserDto>> AddUser(UserDto userDto)
        {
            User newUser;
            try
            {
                newUser = _unitOfWork.Users.Add(UserMapper.MapUserFromUserDto(userDto));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<UserDto>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<UserDto>.Create(UserMapper.MapUserDtoFromUser(newUser));
        }

        public async Task<Result<string>> UpdateUser(UserDto userDto)
        {
            var user = await _unitOfWork.Users.GetById(userDto.Id);
            if (user is null)
            {
                return Result<string>.CreateErrorResult($"User with id {userDto.Id} was not found.");
            }

            try
            {
                UserMapper.MapUserFromUserDto(user, userDto);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(userDto.Id.ToString());
        }
    }
}
