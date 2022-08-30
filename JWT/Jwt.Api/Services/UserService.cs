using AutoMapper;
using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories;
using Jwt.Api.Domain.Response;
using Jwt.Api.Domain.Services;
using Jwt.Api.Domain.Uow;

namespace Jwt.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUow _uow;

        public UserService(IUserRepository userRepository, IUow uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public async Task<UserResponse> Add(User user)
        {
            try
            {
                await _userRepository.Add(user);
                await _uow.ComplateAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı eklenirken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                    return new UserResponse($"Kullanıcı bulunamadı");
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı bulunurken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetUserByRefreshToken(string resfreshToken)
        {
            try
            {
                var user = await _userRepository.GetUserByRefreshToken(resfreshToken);
                if (user == null)
                    return new UserResponse($"Kullanıcı bulunamadı");
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı bulunurken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetUseryByEmailAndPassword(string email, string password)
        {

            try
            {
                var user = await _userRepository.GetUseryByEmailAndPassword(email, password);
                if (user == null)
                    return new UserResponse($"Kullanıcı bulunamadı");
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı bulunurken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task RemoveRefreshTokenAsync(User user)
        {
            await _userRepository.RemoveRefreshTokenAsync(user);
            await _uow.ComplateAsync();
        }

        public async Task SaveRefreshToken(int userId, string refreshToken)
        {
            await _userRepository.SaveRefreshToken(userId, refreshToken);
            await _uow.ComplateAsync();
        }
    }
}
