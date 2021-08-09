using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.Domain;
using System;
using System.Linq;

namespace AnimalsAppBackend.ApplicationServices.Mappers
{
    public static class UserDetailsMapper
    {
        public static UserDetailsDto MapUserDetailsDtoFromUserDetails(UserDetails userDetails)
        {
            return new UserDetailsDto
            {
                Id = userDetails.Id,
                UserId = userDetails.UserId,
                PasswordHash = userDetails.PasswordHash,
                PasswordSalt = userDetails.PasswordSalt,
                Role = userDetails.Role,
                Verified = userDetails.Verified
            };
        }

        public static UserDetails MapUserDetailsFromUserDetailsDto(UserDetailsDto userDetailsDto)
        {
            return new UserDetails
            {
                Id = userDetailsDto.Id,
                UserId = userDetailsDto.UserId,
                PasswordHash = userDetailsDto.PasswordHash,
                PasswordSalt = userDetailsDto.PasswordSalt,
                Role = userDetailsDto.Role,
                Verified = userDetailsDto.Verified
            };
        }

        public static void MapUserDetailsFromUserDetailsDto(UserDetails userDetails, UserDetailsDto userDetailsDto)
        {
            userDetails.UserId = userDetailsDto.UserId;
            userDetails.PasswordHash = userDetailsDto.PasswordHash;
            userDetails.PasswordSalt = userDetailsDto.PasswordSalt;
            userDetails.Role = userDetailsDto.Role;
            userDetails.Verified = userDetailsDto.Verified;
        }
    }
}
