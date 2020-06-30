using GraphQL.Common.Request;

namespace Test
{
    public static class Queries
    {
        public static class Tutorials
        {
            public static string Schema = "/graphql/tutorial";
            public static string Query = @"query tutorials {
                                          tutorials(lang: ""en"") {
                                                    id
                                                        key
                                                    lang
                                                        name
                                                    tutorialItems {
                                                        id
                                                            lang
                                                        title
                                                            description
                                                        image1X
                                                    }
                                                }
                                            } ";
        }

        public static class TripTypes
        {
            public static string Schema = "/graphql/trip";
            public static string Query = @"query tripTypes {
                                          tripTypes(lang: ""en"") {
                                                    id
                                                        lang
                                                    icon
                                                        name
                                                    ranking
                                                        recommendedImages
                                                    {
                                                        id
                                                        modified
                                                        url
                                                    }
                                                }
                                            }";
        }

        public static class Contacts
        {
            public static string Schema = "/graphql/contact";
            public static string Query = @"query getContacts{
                                              consulateContacts(lang:""en""){
                                                id,
                                                lang,
                                                address,
                                                timing,
                                                contactNumber,
                                                countryCode,
                                                countryName,
                                                flagImage,
                                                geolocation
                                              },
                                              embassyContacts(lang: ""en""){
                                                id,
                                                lang,
                                                address,
                                                timing,
                                                contactNumber,
                                                countryCode,
                                                countryName,
                                                flagImage,
                                                geolocation
                                              },
                                              emergencyContacts(lang: ""en""){
                                                id,
                                                lang,
                                                contactIcon,
                                                contactNumber,
                                                contactTitle,
    
                                              }
                                            }";
        }

        public static class Transports
        {
            public static string Schema = "/graphql/transport";
            public static string Query = @"query getTransport{
                                          transports(lang:""en""){
                                            id,
                                            lang,
                                            bannerImage,
                                            bookNowLink,
                                            bookNowtitle,
                                            callFoundtitle,
                                            contactNumber,
                                            geolocation,
                                            getThereTitle,
                                            title,
                                            introduction,
                                            categories{
                                              id,
                                              lang,
                                              text,
                                              mappings{
                                                id,
                                                featureId,
                                                checkbox,
                                                preferenceCheckbox,
                                                lang,
                                                value
                                              }
                                            },
                                            features{
                                              id,
                                              enable,
                                              lang,
                                              text,
                                              mappings{
                                                id,
                                                featureId,
                                                checkbox,
                                                preferenceCheckbox,
                                                lang,
                                                value
                                              }
                                            }
                                          }
                                        }";
        }

        public static class Guides
        {
            public static string Schema = "/graphql/guide";
            public static string Query = @"query Guides{
                                              guides(lang: ""en""){
                                                id,
                                                lang,
                                                downloadLink,
                                                guideHeading,
                                                title,
                                                image,
                                                tripTypes{
                                                  id,
                                                  icon,
                                                  lang,
                                                  name,
                                                  ranking,
                                                  recommendedImages{
                                                    id
                                                  }
                                                },
                                                interests{
                                                    id,
                                                    lang,
                                                    title,
                                                    icon,
                                                    rank,
                                                }
                                              }
                                            }";
        }

        public static class Countries
        {
            public static string Schema = "/graphql/country";
            public static string Query = @"query GetCountries{
                                              countries(lang:""en""){
                                                code,
                                                lang,
                                                name
                                              }
                                            }";
        }

        public static class Itineraries
        {
            public static string Schema = "/graphql/itinerary";
            public static string Query = @"query getItineraries{
                                              itineraries(lang:""en""){
                                                id,
                                                lang,
                                                title,
                                                description,
                                                image,
                                                days{
                                                  id,
                                                  lang,
                                                  dayNumber,
                                                  title,
                                                  poiIds,
                                                  pois{
                                                    id,
                                                    title
                                                  }
                                                }
                                              }
                                            }";
        }

        public static class Events
        {
            public static string Schema = "/graphql/event";
            public static string GetAll = @"query getEvents{
                                              events(lang: ""en"") {
                                                title, 
                                                ticketPrice,
                                                address,
                                                body,
                                                buyLinkMobile,
                                                buyLinkWebsite,
                                                free,
                                                id,
                                                introText,
                                                isTicketing,
                                                latitude,
                                                longitude,
                                                maxPrice,
                                                minPrice,
                                                phone,
                                                venue,
                                                website,
                                                lang
                                              }
                                            }";
            public static string GetById = @"query getEvent{
                                              event(id: ""$id$"", lang: ""en""){
                                                title, 
                                                ticketPrice,
                                                address,
                                                body,
                                                buyLinkMobile,
                                                buyLinkWebsite,
                                                free,
                                                id,
                                                introText,
                                                isTicketing,
                                                latitude,
                                                longitude,
                                                maxPrice,
                                                minPrice,
                                                phone,
                                                venue,
                                                website,
                                              }
                                            }
                                            ";
        }

        public static class Pois
        {
            public static string Schema = "/graphql/poi";
            public static string GetAll = @"query getPois{
                                              pois (lang: ""en"") {
                                                id,
                                                address,
                                                body,
                                                contentId,
                                                introText,
                                                lang,
                                                longitude,
                                                latitude,
                                                phone,
                                                title,
                                                tripAdvisorId,
                                                website,
                                              }
                                            }";
            public static string GetById = @"query getPoi{
                                              poi(id: ""$id$"", lang: ""en""){ 
                                                id,
                                                address,
                                                body,
                                                contentId,
                                                introText,
                                                lang,
                                                longitude,
                                                latitude,
                                                phone,
                                                title,
                                                tripAdvisorId,
                                                website
                                              }
                                            }";
            public static string GetMarkets = @"query getMarket{
                                                  market(code: ""us"", lang: ""en""){ 
                                                    id,
                                                    title,
                                                    ranking,
                                                    icon,
                                                    countryCode,
                                                    lang
                                                    pois{
                                                            id,
                                                            lang,
                                                            title
                                                        }
                                                  }
                                                }";

            public static string GetTags = @"query getMarket{
                                              tags(lang: ""en""){ 
                                                id,
                                                title,
                                                ranking,
                                                icon,
                                                lang
                                              }
                                            }";

            public static string GetOpeningHours = @"query openingHours{
              poi(id: ""{0}""){
                        id,
                        title,
                        openingHours{
                            openDay,
                            openTime,
                            closeDay,
                            closeTime
                        }
                    }
                }";
        }

        public static class Trips
        {
            public static string Schema = "/graphql/trip";
            public static string GetTripById = @"{
                                  trip(id: ""{0}"") {
                                            id,
                                            userId,
                                            startDate,
                                            endDate,
                                            name,
                                            numberOfDays,
                                            status,
                                            created,
                                            days {
                                                id,
                                                created,
                                                status,
                                                pois{
                                                    poiId,
                                                    sortOrder,
                                                    created
                                                }
                                            }
                                        }
                                    }";
            public static string GetUserTrips = @"{
                                                  trips(userId: ""{0}"") {
                                                    id,
                                                    userId,
                                                    name,
                                                    startDate,
                                                    endDate,
                                                    modified,
                                                    numberOfDays,
                                                    status,
                                                    created,
                                                    days {
                                                      id,
                                                      created,
                                                      status,
                                                      pois{
                                                          id,
                                                          poiId,
                                                          sortOrder,
                                                          created,
                                                          rating,
                                                          comment,
                                                          modified
                                                      }
                                                    }
                                                  }
                                                }
                                                ";

            public static string CreateTrip = @"mutation addTrip {
                                              create(trip: {status :1,
                                                numberOfDays:2, startDate: ""05/25/2021"", endDate: ""05/27/2021"", name: ""Benchmark""
                                                    }) {
                                                        id,
                                                        userId,
                                                        name,
                                                        startDate,
                                                        endDate,
                                                        numberOfDays,
                                                        status,
                                                        created
                                                    }
                                                }";
            public static string UpdateTrip = @"mutation updateTrip {
                                      update(id: ""{0}"", trip: {status :1,
                                                numberOfDays:4, startDate: ""05/25/2021"", endDate: ""05/28/2021"", name: ""Benchmark""
                                            }) {
                                                id,
                                                userId,
                                                name,
                                                startDate,
                                                endDate,
                                                numberOfDays,
                                                status,
                                                created,
                                                modified
                                            }
                                        }";
            public static string AddDayToTrip = @"mutation addDay{
                                          addDay(tripId: ""{0}"", day: {day:1, tripDayPois: [{poiId: ""{1}""}]}){
                                                    id,
                                                    days{
                                                        id,
                                                        day,
                                                        created,
                                                        status,
                                                        pois{
                                                            id,
                                                            poiId,
                                                            sortOrder,
                                                            created
                                                        }
                                                    }
                                                }
                                            }";
            public static string AddMultipleDaysToTrip = @"mutation addDays{
  addDays(tripId: ""{0}"", days: 
        [{day:2, tripDayPois: [{poiId: ""{1}""}]},
        {day:3, tripDayPois: [{poiId: ""{1}""}]}]
        ){
            id,
            days{
                id,
                day,
                created,
                status,
                pois{
                    id,
                    poiId,
                    sortOrder,
                    created
                }
            }
        }
    }";
            public static string MovePoiToAnotherDay = @"mutation movePoi{
                                      movePoi(tripId: ""{0}"", poiId: ""{1}"", fromDay: 1, toDay:0){
                                                id,
                                                days{
                                                    id,
                                                    day,
                                                    created,
                                                    status,
                                                    pois{
                                                        id,
                                                        poiId,
                                                        sortOrder,
                                                        created
                                                    }
                                                }
                                            }
                                        }";

            public static string UpdatePoiSortOrder = @"mutation updateSortOrder{
                                                      updateSortOrder(tripId: ""{0}"", day: {day:1, tripDayPois: [{poiId: ""{1}""}]}){
                                                                id,
                                                                days{
                                                                    id,
                                                                    day,
                                                                    created,
                                                                    status,
                                                                    pois{
                                                                        id,
                                                                        poiId,
                                                                        sortOrder,
                                                                        created
                                                                    }
                                                                }
                                                            }
                                                        }";

            public static string GetPoiCheckinCount = @"{ getPoiCheckinCount(poiId: ""{0}"") }";
        }

        public static class User
        {
            public static string Schema = "/graphql/user";
            public static string GetUserProfile = @"{
                  userProfile{
                    email,
                    firstName,
                    lastName,
                    country,
                    phone,
                    profileImageId,
                    backgroundImageId,
                    prefferedLanguage,
                    marketingCommunicationCheck
                  }
                }";
            public static GraphQLRequest UpdateUserProfile = new GraphQLRequest
            {
                Query = @"mutation updateProfile{
  updateProfile(profile: {
      country: ""USA1"",
                backgroundImageId:  ""d965ebf3-edae-4864-7f5e-08d7d863328a""
            }){
                firstName,
                lastName,
                country,
                phone,
                profileImageId,
                backgroundImageId
            }
        }"
            };

            public static string GetUserInfo = @"{
              user{
                  favouritePoi{
                      poiId,
                      created
                  },
                  favouriteEvent{
                      eventId,
                      created
                  },
                  tripTypes{
                      tripTypeId,
                      date
                  },
                  interests{
                    interestId,
                    date,
                    title,
                    lang,
                    icon,
                    rank,
                    isActive,
                    tagId
                  },
                  topPicks{
                      itemId,
                      created
                  }
      
              }
            }";
            public static string AddTopPicks = @"mutation addTopPicks{
                                              addTopPick(itemIds: [""{65536406-4D15-4C09-9756-414E3467C5C0}"", ""0E766FD0-FE64-4A0F-AFDA-86724E409F1C""]){
                                                    itemId,
                                                    created
                                                        }
                                                    }";
            public static string RemoveTopPicks = @"mutation removeTopPicks{
                                              removeTopPicks(itemIds: [""{65536406-4D15-4C09-9756-414E3467C5C0}"", ""0E766FD0-FE64-4A0F-AFDA-86724E409F1C""]){
                                                    itemId,
                                                    created
                                                        }
                                                    }";
            public static string AddFavoriteEvent = @"mutation addFavouriteEvent{
                                      addFavourites(eventIds: [""{0}""]){
                                                id
                                            }
                                        }";
            public static string RemoveFavoriteEvent = @"mutation removeFavouriteEvent{
                                      removeFavourites(eventIds: [""{0}""]){
                                                id
                                            }
                                        }";
            public static string AddFavoritePoi = @"mutation addFavouritePoi{
                                      addFavourites(poiIds: [""{0}""]){
                                                id
                                            }
                                        }";
            public static string GetFavoritePoi = @"{
                                      user{
                                        favouritePoi{
                                          created,
                                          poiId
                                        }
                                      }
                                    }";
            public static string RemoveFavoritePoi = @"mutation removeFavouritePoi{
                                      removeFavourites(poiIds: [""{0}""]){
                                                id
                                            }
                                        }";
            public static string UpdateTripTypes = @"mutation updateTripTypes{
                                      updateTripTypes(tripTypeIds: [""{0}""]){
                                                id
                                            }
                                        }";
            public static string UpdateInterests = @"mutation updateInterests{
                                      updateInterests(interestIds: [""{0}""]){
                                                id
                                            }
                                        }";
            public static string RegisterDevice = @"mutation registerDevice{
                              registerDevice(registration: {
                                  registrationId: ""adhfjashf"",
                                        provider: ""Firebase"",
                                        appName: ""tesetApp"",
                                        appVersion: ""appVersion"",
                                        deviceType: ""Android"",
                                        language: ""en"",
                                        disableNotifications: false,
                                        lat: ""53.890786"",
                                        lng: ""27.597401""
                                    })
                                }";
            public static string RemoveDevice = @"mutation unregisterDevice{
  unregisterDevice(registrationId:""adhfjashf"")
        }";


            public static string UpdateInterestEvents = @"mutation updateInterests{
                                      updateInterests(eventIds: [""{0}""]){
                                                id,
                                                created
                                            }
                                        }";

            public static string GetInterestEvents = @"{
                                  user{
                                    interestEvents{
                                      date,
                                      eventId
                                    }
                                  }
                                }";

            public static string GetFavoriteEvents = @"{
                                  user{
                                    favouriteEvent{
                                      created,
                                      eventId
                                    }
                                  }
                                }";
            public static string GetInterests = @"{
                                  user{
                                    interests{
                                        interestId,
                                        date,
                                        title,
                                        lang,
                                        icon,
                                        rank,
                                        isActive,
                                        tagId
                                    }
                                  }
                                }";
            public static string GetTripTypes = @"{
                                  user{
                                    tripTypes{
                                        tripTypeId,
                                        date
                                    }
                                  }
                                }";

        }
    }
}
