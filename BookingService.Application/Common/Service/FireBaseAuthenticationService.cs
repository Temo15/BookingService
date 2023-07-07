using BookingService.Application.Account.Commands.RegisterUser.Models;
using BookingService.Application.Common.Interfaces;
using Firebase.Auth;
using Microsoft.Extensions.Configuration;

namespace BookingService.Application.Common.FireBaseAuthentication
{
    public class FireBaseAuthenticationService : IFireBaseAuthenticationService
    {
        private readonly IConfiguration configuration;
        public FireBaseAuthenticationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task CreateUserWithEmailAndPasswordAsync(string email, string password, UserDataModel displayName)
        {
            FirebaseAuthProvider firebaseAuthProvider = GetFirebaseAuthProvider();
            FirebaseAuthLink user = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(email, password);

            var requestBody = new
            {
                idToken = user.FirebaseToken,
                displayName = $"{{\"entityNo\":{displayName.EntityNo},\"firstName\":\"{displayName.FirstName}\",\"lastName\":\"{displayName.LastName}\"}}",
                returnSecureToken = true
            };      
            await Update(requestBody);
        }
        private async Task Update(object requestBody)
        {
            using var httpClient = new HttpClient();

            var url = Constants.BaseUrl + "update?key=" + configuration["FireBaseAuthentication:API_KEY"];
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody));

            using var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }
        public async Task<string> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            FirebaseAuthProvider firebaseAuthProvider = GetFirebaseAuthProvider();

            FirebaseAuthLink user = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);

            return user.FirebaseToken;
        }
        private FirebaseAuthProvider GetFirebaseAuthProvider()
        {
            string? apiKey = configuration["FireBaseAuthentication:API_KEY"];
            return new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        }
        public class Constants
        {
            public const string BaseUrl = "https://identitytoolkit.googleapis.com/v1/accounts:";
        }
    }
}
