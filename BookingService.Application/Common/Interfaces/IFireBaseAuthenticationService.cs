using BookingService.Application.Account.Commands.RegisterUser.Models;

namespace BookingService.Application.Common.Interfaces
{
    public interface IFireBaseAuthenticationService
    {
        Task CreateUserWithEmailAndPasswordAsync(string email, string password, UserDataModel displayName);
        Task<string> SignInWithEmailAndPasswordAsync(string email, string password);
    }
}
