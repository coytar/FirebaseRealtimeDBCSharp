using Firebase.Database;
using Google.Apis.Auth.OAuth2;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebaseRealtimeDBCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] scopes = { "https://www.googleapis.com/auth/firebase.database", "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };
            var firebase = new FirebaseClient(
                "[URL]",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => GoogleAuthProvider.GetAccessTokenFromJSONKeyAsync("service-account.json", scopes),
                    AsAccessToken = true
                });

            // Read example
            Task[] t = new Task[2];
            t[0] = ReadFromFirebase(firebase);

            // Write example
            t[1] = WriteToFirebase(firebase);

            Task.WaitAll(t);
        }

        static async Task ReadFromFirebase(FirebaseClient firebase)
        {
            var val = await firebase.Child("users/temp").OnceSingleAsync<String>();
            Console.WriteLine("Read: " + val);
        }

        static async Task WriteToFirebase(FirebaseClient firebase)
        {
            DateTime dt = DateTime.Now;

            // Replace "users" node
            //await firebase.Child("users").PutAsync("{ \"temp\": \"" + dt.ToShortDateString() + " " + dt.ToLongTimeString() + "\" }");

            // Update "users" node
            await firebase.Child("users").PatchAsync("{ \"temp\": \"" + dt.ToShortDateString() + " " + dt.ToLongTimeString() + "\" }");
        }
    }

    public class GoogleAuthProvider
    {
        public static async Task<string> GetAccessTokenFromJSONKeyAsync(string jsonKeyFilePath, params string[] scopes)
        {
            using (var stream = new FileStream(jsonKeyFilePath, FileMode.Open, FileAccess.Read))
            {
                return await GoogleCredential
                    .FromStream(stream) // Loads key file  
                    .CreateScoped(scopes) // Gathers scopes requested  
                    .UnderlyingCredential // Gets the credentials  
                    .GetAccessTokenForRequestAsync()
                    .ConfigureAwait(false); // Gets the Access Token  
            }
        }

        public static string GetAccessTokenFromJSONKey(string jsonKeyFilePath, params string[] scopes)
        {
            return GetAccessTokenFromJSONKeyAsync(jsonKeyFilePath, scopes).Result;
        }
    }
}
