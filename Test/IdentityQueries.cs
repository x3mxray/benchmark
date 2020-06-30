namespace Test
{
    public static class IdentityQueries
    {
        public static string ClientId = "postman";

        public static class Profile
        {
            public static string GetUserProfileUrl = "/api/user/GetUserProfile";
            public static string UpdateUserProfileUrl = "/api/user/UpdateProfile";
            public static string UpdateUserProfileQuery = @"{
	                                                        ""FirstName"" : ""Teset"",
                                                                    ""LastName"" : ""Benchmark"",
                                                                    ""Phone"" : ""12312313"",
                                                                    ""PrefferedLanguage"": ""en"",
                                                                    ""Country"" : ""Russia"",
                                                                    ""ProfileImageId"" : null,
                                                                    ""BackgroundImageId"": null
                                                                }";
        }

        public static class ChangePassword
        {
            public static string ChangePasswordRequestUrl = $@"/api/user/ChangePasswordRequest?clientId={ClientId}";
    }
    }
}
