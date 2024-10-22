﻿namespace RedSecure.Domain.Utils.Constants
{
    public static class Constants
    {

        public static class ErrorMessages
        {
            public const string UserExistsPreregister = "Already pre-registered user";
            public const string UserExists = "User already exists in the platform.";
            public const string PreregisterNotPossible = "Pre-Register was not possible.";
            public const string ErrorGeneralMessage = "the user or password provided is not valid.";
            public const string FakeDeckriptedData = "...........";

            public const string ErrorGeneral = "Problem encountered.";
            public const string UserNotFound = "User was not found.";
        }


        public static class TokenParameters
        {
            public const string TokenType = "Bearer";
            public const string Scope = "CmargokSystems";
        }


        public static class Issuers
        {
            public const string Internal = "login-sesion";
            public const string BlockingJob = "job-blocker";
        }

        public static class OkMessages
        {
            public const string AccessGranted = "Access granted";
            public const string AccessGranteNotLog = "Access was granted but the log was not saved.";
            public const string LogOutSuccesfully = "the Logout action was successfully made.";
            public const string UserRegisterd = "User was succesfully registered.";
        }




        public static class Reasons
        {
            public const string NoActiveRefresh = "The refresh token provided is not active";
            public const string RefreshLogout = "The refresh token was blocked due a logout";
            public const string Logout = "The token was blocked due a logout";
            public const string TokenDoesNotExists = "The token provided was not found or is not active";

            public const string NewTokenWasCreated_MustBlockActiveTokens = "A new token was generated by the given refresh token";
            public const string TokenLoockedToPrevent = "The given token was blocked to prevent security risks.";


            public const string ErrorBlockingRefreshToken = "There was an issue while locking the refresh token and could not be locked.";
            public const string ErrorBlockingToken = "There was an issue while locking the token and could not be locked.";

            public const string BlockingTokenByJob = "The token has been blocked due to expiration.";
        }
    }
}
