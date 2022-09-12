using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Time for Maintenance.";

        public static string ProductAdded = "Product Added.";
        public static string ProductNameInvalid = " Product Name is Invalid.";
        public static string ProductsListed = "Products Listed.";
        public static string ProductDeleted = "Product Deleted.";

        public static string BrandAdded="Brand Added.";
        
        public static string BrandDeleted = "Brand Deleted";

        public static string ColorDeleted= "Color Deleted";
        public static string ColorsListed= "Colors Listed";
        public static string ColorAdded= "Color Added";

        public static string UserAdded= "User Added";
        public static string UserDeleted= "User Deleted";
        public static string UsersListed= "Users Listed";

        public static string RentalAdded= "Rental Added";
        public static string RentalsListed= "Rentals Listed";
        public static string RentalDeleted= "Rental Deleted";
        public static string RentalFailed = "Failed Rental, Car is not Returned!";

        public static string CustomersListed= "Customers Listed";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerAdded = "Customer Added";

        
        public static string CarImageAdded = "Car Image Added";
        public static string CarImageDeleted= "Car Image Deleted";
        public static string CarImagesListed= "Car Images Listed";
        public static string CarImageUpdated = "Car Image Updated";
        public static string ImageLimitProblem= "Adding Failed Because of Image Limit";

        public static string AuthorizationDenied= "Authorization Denied";
        public static string UserRegistered = "UserRegistered";
        public static string UserNotFound = "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string AccessTokenCreated = "AccessTokenCreated";
        public static string SuccessfulLogin = "SuccessfulLogin";

        public static string CarUpdated= "Car Updated Succesfully";
        public static string SuccesfullyGotDetails = "Successfully Got Details";
        public static string CardUpdated= "Card Updated";
        public static string CardDeleted= "Card Deleted";
        public static string CardAdded= "Card Added";
        public static string CardListed= "Card Listed";
    }
}
