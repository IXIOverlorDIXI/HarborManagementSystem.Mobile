namespace IoC.Constants
{
    public static class ApiRoutes
    {
        private const string Prefix = "api";

        private const string Base = $"/{Prefix}";
        
        public static class Account
        {
            public const string Controller = $"{Base}/Account";
            
            public const string Login = $"{Controller}/login";

            public const string Register = $"{Controller}/register";

            public const string ChangePassword = $"{Controller}/changepassword";
        }

        public static class Berth
        {
            public const string Controller = $"{Base}/Berth";
            
            public const string ById = $"{Controller}/byId";
            
            public const string Photos = $"{Controller}/photos";
            
            public const string SuitableBerth = $"{Controller}/suitableBerths";
            
            public const string TurnOffOnTheBerth = $"{Controller}/turnOffOnTheBerth";
        }

        public static class Booking
        {
            public const string Controller = $"{Base}/booking";
            
            public const string ById = $"{Controller}/byId";

            public const string GetReservedDates = $"{Controller}/getReservedDates";
            
            public const string OwnBookings = $"{Controller}/OwnBookings";
            
            public const string OwnBookingsForShip = $"{Controller}/ownBookingsForShip";
            
            public const string BookingsForHarbor = $"{Controller}/BookingsForHarbor";
            
            public const string BookingsForBerth = $"{Controller}/BookingsForBerth";
            
            public const string BookingDataForCheck = $"{Controller}/bookingDataForCheck";
        }

        public static class BookingCheck
        {
            public const string Controller = $"{Base}/BookingCheck";
        }
        
        public static class EnvironmentalCondition
        {
            public const string Controller = $"{Base}/EnvironmentalCondition";
        }
        
        public static class Harbor
        {
            public const string Controller = $"{Base}/Harbor";
            
            public const string ById = $"{Controller}/byId";
            
            public const string OwnHarbors = $"{Controller}/ownHarbors";
            
            public const string SuitableHarbors = $"{Controller}/suitableHarbors";
            
            public const string Photos = $"{Controller}/photos";
            
            public const string Documents = $"{Controller}/documents";
        }
        
        public static class Profile
        {
            public const string Controller = $"{Base}/Profile";
            
            public const string Photo = $"{Controller}/photo";
            
            public const string Settings = $"{Controller}/settings";
        }

        public static class RelativePositionMetering
        {
            public const string Controller = $"{Base}/RelativePositionMetering";
        }
        
        public static class Review
        {
            public const string Controller = $"{Base}/Review";
            
            public const string ByBerth = $"{Controller}/byBerth";
            
            public const string ByHarbor = $"{Controller}/byHarbor";
        }
        
        public static class Service
        {
            public const string Controller = $"{Base}/Service";
        }
        
        public static class Ship
        {
            public const string Controller = $"{Base}/Ship";
            
            public const string ById = $"{Controller}/byId";
            
            public const string Photo = $"{Controller}/photo";
        }
        
        public static class ShipType
        {
            public const string Controller = $"{Base}/ShipType";
        }
        
        public static class StorageEnvironmentalCondition
        {
            public const string Controller = $"{Base}/StorageEnvironmentalCondition";
        }
        
        public static class Subscription
        {
            public const string Controller = $"{Base}/Subscription";
            
            public const string CurrentSubscription = $"{Controller}/currentSubscription";
            
            public const string AllSubscriptions = $"{Controller}/allSubscriptions";
            
            public const string ChangeSubscription = $"{Controller}/changeSubscription";
        }
        
        public static class SubscriptionCheck
        {
            public const string Controller = $"{Base}/SubscriptionCheck";
        }
    }
}