using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;

namespace Test
{
    public class FastAndDirtyConfig : ManualConfig
    {
        public FastAndDirtyConfig()
        {
            Add(DefaultConfig.Instance);
            Add(Job.ShortRun.WithIterationCount(10));
        }
    }

    
    public class Program
    {
        public static Settings Config { get; set; }
        public static void Main(string[] args)
        {
            
            //BenchmarkRunner.Run<MobileApiWithOAuth>();
            BenchmarkRunner.Run<MobileApi>();
            BenchmarkRunner.Run<IdentityServer>();

            Console.ReadLine();
        }

        public static void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            var config = builder.Build();

            Config = config.GetSection("Settings").Get<Settings>();
        }

        public static void GetUserProfile()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");

            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetUserProfile
            }).GetAwaiter().GetResult();
            var response = result.Data;

            Console.WriteLine("Responce: " + response);
        }
    }



    [MemoryDiagnoser]
    //[Config(typeof(FastAndDirtyConfig))]
    //[RPlotExporter]
    //[DryJob(RuntimeMoniker.NetCoreApp21)]

    public class MobileApi
    {
        public static Settings Config { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            var config = builder.Build();

            Config = config.GetSection("Settings").Get<Settings>();
        }

        [Benchmark]
        public void GetTutorials()
        {
            var _client = new GraphQLClient(Config.Host + Queries.Tutorials.Schema);
           
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Tutorials.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetTripTypes()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.TripTypes.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.TripTypes.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetContacts()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Contacts.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Contacts.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetTransports()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Transports.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Transports.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetGuides()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Guides.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Guides.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetCountries()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Countries.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Countries.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetItinenaries()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Itineraries.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Itineraries.Query
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetAllEvents()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Events.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Events.GetAll
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetEventById()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Events.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Events.GetById.Replace("$id$", Config.EventId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetAllPoi()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Pois.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Pois.GetAll
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetPoiById()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Pois.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Pois.GetById.Replace("$id$", Config.PoiId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetPoiOpeningHours()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Pois.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Pois.GetOpeningHours.Replace("{0}", Config.PoiId) 
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetMarkets()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Pois.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Pois.GetMarkets
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void GetTags()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Pois.Schema);
            var result = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Pois.GetTags
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + result);
        }

        [Benchmark]
        public void DownloadPdf()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, Config.Host + Config.DownloadPdf);
            var response = client.SendAsync(request).GetAwaiter().GetResult();
            var code = response.StatusCode;
            Console.WriteLine("Status code: " + code);
        }

        [Benchmark]
        public void GetTripById()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.GetTripById.Replace("{0}", Config.UserId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }
    }

    [MemoryDiagnoser]
    //[Config(typeof(FastAndDirtyConfig))]
    //[DryJob(RuntimeMoniker.NetCoreApp21)]
    public class MobileApiWithOAuth
    {
        public static Settings Config { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            
            var config = builder.Build();
            Config = config.GetSection("Settings").Get<Settings>();
        }

        [Benchmark]
        public void GetUserProfile()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");

            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetUserProfile
            }).GetAwaiter().GetResult().Data;

            Console.WriteLine("Responce: "+response);
        }

        [Benchmark]
        public void UpdateUserProfile()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(Queries.User.UpdateUserProfile).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserInfo()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetUserInfo
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void AddUserTopPicks()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.AddTopPicks
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void RemoveUserTopPicks()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.RemoveTopPicks
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void AddUserFavoriteEvent()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.AddFavoriteEvent.Replace("{0}", Config.EventId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void RemoveUserFavoriteEvent()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.RemoveFavoriteEvent.Replace("{0}", Config.EventId) 
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void AddUserFavoritePoi()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.AddFavoritePoi.Replace("{0}", Config.PoiId) 
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserFavoritePoi()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetFavoritePoi
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void RemoveUserFavoritePoi()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.RemoveFavoritePoi.Replace("{0}", Config.PoiId) 
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void UpdateUserTripTypes()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.UpdateTripTypes.Replace("{0}", Config.TripTypeId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void UpdateUserInterests()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.UpdateInterests.Replace("{0}", Config.InterestId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void RegisterDevice()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.RegisterDevice
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void RemoveDevice()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.RemoveDevice
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserTrips()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.GetUserTrips.Replace("{0}", Config.UserId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void UpdateUSerInterestEventss()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.UpdateInterestEvents.Replace("{0}", Config.EventId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserInterestEventss()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetInterestEvents
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserFavoriteEvents()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetFavoriteEvents
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserInterests()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetInterests
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetUserTripTypes()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.User.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.User.GetTripTypes
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }


        [Benchmark]
        public void CreateUserTrip()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.CreateTrip
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void UpdateUserTrip()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.UpdateTrip.Replace("{0}", Config.TripId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void AddDayToTrip()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.AddDayToTrip.Replace("{0}", Config.TripId).Replace("{1}", Config.PoiId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void AddMultipleDaysToTrip()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.AddMultipleDaysToTrip.Replace("{0}", Config.TripId).Replace("{1}", Config.PoiId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void MovePoiToAnotherDay()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.MovePoiToAnotherDay.Replace("{0}", Config.TripId).Replace("{1}", Config.PoiId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void GetPoiCheckinCount()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.GetPoiCheckinCount.Replace("{0}", Config.PoiId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }

        [Benchmark]
        public void UpdatePoiSortOrder()
        {
            GraphQLClient _client = new GraphQLClient(Config.Host + Queries.Trips.Schema);
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OAuth}");
            var response = _client.PostAsync(new GraphQLRequest
            {
                Query = Queries.Trips.UpdatePoiSortOrder.Replace("{0}", Config.TripId).Replace("{1}", Config.PoiId)
            }).GetAwaiter().GetResult().Data;
            Console.WriteLine("Responce: " + response);
        }
    }

   
}
