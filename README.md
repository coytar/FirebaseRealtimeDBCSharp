# FirebaseRealtimeDBCSharp
A C# example of communicating with the Firebase Realtime database.

## Usage
1. Clone this repo
2. Install the packages listed in the heading "NuGet packages required"
3. Follow this https://firebase.google.com/docs/database/rest/start to create Firebase account, a project and then the realtime database
4. Generate the private key for the service account

    1. Go to the project settings of your Firebase project in https://console.firebase.google.com/
    2. Click on the Service Accounts tab
    3. Click on "Firebase Admin SDK" and click "Generate private key"
    4. Save this file and replace it with the "service-account.json" file in this C# project
  
5. Edit Program.cs
    1. Replace line 16 with the URL to your project, it should look like: "https://blahblah-0000f.firebaseio.com/"
    
6. Build and run it.

## NuGet packages required
Run these commands in the Package Manager Console in Visual Studio:
```
Install-Package Google.Apis.Auth
Install-Package FirebaseDatabase.net
```

###  Package listing and versions

Id                                  |Versions
--                                  |--------
FirebaseDatabase.net                |{4.0.4}
Google.Apis                         |{1.45.0}
Google.Apis.Auth                    |{1.45.0}
Google.Apis.Core                    |{1.45.0}
LiteDB                              |{4.1.4} 
Newtonsoft.Json                     |12.0.3}
System.Reactive                     |4.0.0}


## Tested On
Windows 10 1909
Visual Studio 2019 Community 16.5.1
.NET Framework 4.7.2


## Many Thanks
https://www.c-sharpcorner.com/article/retrieve-access-token-for-google-service-account-form-json-or-p12-key-in-c-sharp/


## License
No license :)
