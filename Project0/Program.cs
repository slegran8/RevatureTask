using System;
using System.Collections.Generic;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();    

            bool login_correct = false;
            bool continuing = true; 
            int choice; 

          
            Hotels chosenHotel = new Hotels();
            login firstLogin = new login();
            System.Random Random = new System.Random();
            
            while (login_correct == false){
            System.Console.WriteLine("Enter Username");
            string userName = Console.ReadLine();
            System.Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            login loginCheck = new login();
            loginCheck.userName = userName;
            loginCheck.password = password;

            login_correct = firstLogin.LoginStart(loginCheck);
            if (login_correct == true){
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                System.Console.WriteLine("LOGIN IN SUCCESSFUL \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;


            }if (login_correct == false){
                Console.BackgroundColor = ConsoleColor.Red;
                System.Console.WriteLine("LOGIN FAILED - INVALID CREDENTIALS \n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            }
            
            if (login_correct == true){
                while (continuing){
                
                //Console.BackgroundColor = ConsoleColor.Blue;

                Console.WriteLine(" Booking Manager "); 
                Console.WriteLine("-----------------");       

                Console.ResetColor();

                System.Console.WriteLine("1. Make Booking ");  
                System.Console.WriteLine("2. View Bookings");
                System.Console.WriteLine("3. Update: ");
                System.Console.WriteLine("4. Delete: ");
                System.Console.WriteLine("5. View Booking By Price Ascending: ");
                System.Console.WriteLine("6. View Booking By Price Descending: ");
                System.Console.WriteLine("7. View Cities");
                System.Console.WriteLine("8. Log-Out: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    #region Case 1
                    case 1:
                        System.Console.WriteLine("Enter Name: ");
                        string bookingName = Console.ReadLine();
                        System.Console.WriteLine("Enter Location: ");
                        string bookingLocation = Console.ReadLine();
                        System.Console.WriteLine("Enter Property Type");
                        string bookingProperty = Console.ReadLine();
                        System.Console.WriteLine("Enter Stay Length");
                        int bookingNights = Convert.ToInt32(Console.ReadLine());
                        
                        int bookingPrice; 
                        if (bookingProperty == "Hotel"){
                            //System.Console.WriteLine("Hotel");
                            bookingPrice = Random.Next(99, 300);
                        }if (bookingProperty == "Hostel"){
                            bookingPrice = Random.Next(10, 100);
                        }if (bookingProperty == "Resort"){
                            bookingPrice = Random.Next(150, 501);
                        }if (bookingProperty == "Villa"){
                            bookingPrice = Random.Next(75, 346);
                        }else{
                            bookingPrice = Random.Next(40, 300);
                        }

                        int totalBookingPrice = bookingNights * bookingPrice;

                        Hotels newHotel = new Hotels();
                        newHotel.name = bookingName;
                        newHotel.locationName = bookingLocation;
                        newHotel.propertyType = bookingProperty;
                        newHotel.nightsStayed = bookingNights;
                        newHotel.costPerNight = bookingPrice;
                        newHotel.totalCost = totalBookingPrice;
                        newHotel.isBooked = true;
                        System.Console.WriteLine(chosenHotel.AddNewBooking(newHotel));
                        break;
                    #endregion
                    case 2:
                        //List<Hotels> Booking_list = chosenHotel.GetBookingList();
                        List<Hotels> list = chosenHotel.GetBookingList();
                        foreach (var entry in list)
                        {
                        System.Console.WriteLine("___________________________________________");
                        System.Console.WriteLine("Booking Id: "            + entry.bookingId);
                        System.Console.WriteLine("Booking Name: "          + entry.name);
                        System.Console.WriteLine("Booking Location: "      + entry.locationName);
                        System.Console.WriteLine("Booking Property: "           + entry.propertyType);
                        System.Console.WriteLine("Booking Nights Stayed: "         + entry.nightsStayed);
                        System.Console.WriteLine("Booking Cost Per Night: $ "         + entry.costPerNight);
                        System.Console.WriteLine("Booking Toal Cost $"         + entry.totalCost);
                        System.Console.WriteLine("Is Booked ?: " + entry.isBooked);
                        System.Console.WriteLine(" ");
                        }

                        break;
                    case 3:
                        System.Console.WriteLine("Enter Booking ID");
                        int id = Convert.ToInt32(Console.ReadLine());
                        
                       
                        bool id_check = chosenHotel.CheckIfIdExists(id);
                        
                        if (id_check == true){
                           System.Console.WriteLine("Enter Name: ");
                            string new_bookingName = Console.ReadLine();
                            System.Console.WriteLine("Enter Location: ");
                            string new_bookingLocation = Console.ReadLine();
                            System.Console.WriteLine("Enter Property Type");
                            string new_bookingProperty = Console.ReadLine();
                            System.Console.WriteLine("Enter Stay Length");
                            int new_bookingNights = Convert.ToInt32(Console.ReadLine());
                            
                            int new_bookingPrice; 
                            if (new_bookingProperty == "Hotel"){
                                //System.Console.WriteLine("Hotel");
                                new_bookingPrice = Random.Next(70, 300);
                            }if (new_bookingProperty == "Hostel"){
                                new_bookingPrice = Random.Next(10, 100);
                            }if (new_bookingProperty == "Resort"){
                                new_bookingPrice = Random.Next(150, 501);
                            }if (new_bookingProperty == "Villa"){
                                new_bookingPrice = Random.Next(75, 346);
                            }else{
                                new_bookingPrice = Random.Next(40, 300);
                            }

                            Hotels bookingEdit = new Hotels();  
                            bookingEdit.bookingId = id;
                            bookingEdit.name = new_bookingName;
                            bookingEdit.locationName = new_bookingLocation;
                            bookingEdit.propertyType = new_bookingProperty;
                            bookingEdit.nightsStayed = new_bookingNights;
                            bookingEdit.costPerNight = new_bookingPrice;
                            bookingEdit.totalCost = new_bookingPrice * new_bookingNights;

                            System.Console.WriteLine(chosenHotel.EditBooking(bookingEdit));
                            break; 
                        }else{

                            Console.BackgroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("INVALID BOOKING ID");
                            Console.BackgroundColor = ConsoleColor.Black;
                            System.Console.WriteLine("\n");
                            break;
                        }

                    case 4:
                        System.Console.WriteLine("Enter Booking ID to Delete Booking");
                        int booking_ID = Convert.ToInt32(Console.ReadLine());
                       
                       
                        bool id_check_delete = chosenHotel.CheckIfIdExists(booking_ID);
                        
                        if (id_check_delete == true){
                            System.Console.WriteLine(chosenHotel.DeleteBooking(booking_ID));

                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.Black;
                            System.Console.WriteLine("Booking Deleted!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            System.Console.WriteLine("\n");
                            break;
                        }else{
                            Console.BackgroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("INVALID BOOKING ID");
                            Console.BackgroundColor = ConsoleColor.Black;
                            System.Console.WriteLine("\n");
                            break;
                        }

                       

                    case 5:
                        List<Hotels> orderedList = chosenHotel.GetOderedList();
                        foreach (var entry in orderedList)
                        {
                        System.Console.WriteLine("___________________________________________");
                        System.Console.WriteLine("Booking Id: "            + entry.bookingId);
                        System.Console.WriteLine("Booking Name: "          + entry.name);
                        System.Console.WriteLine("Booking Location: "      + entry.locationName);
                        System.Console.WriteLine("Booking Property: "           + entry.propertyType);
                        System.Console.WriteLine("Booking Nights Stayed: "         + entry.nightsStayed);
                        System.Console.WriteLine("Booking Cost Per Night: $ "         + entry.costPerNight);
                        System.Console.WriteLine("Booking Toal Cost $"         + entry.totalCost);
                        System.Console.WriteLine("Is Booked ?: " + entry.isBooked);
                        }
                        
                        break;
                    case 6:
                        List<Hotels> orderedListDesc = chosenHotel.GetOderedListDesc();
                        foreach (var entry in orderedListDesc)
                        {
                        System.Console.WriteLine("___________________________________________");
                        System.Console.WriteLine("Booking Id: "            + entry.bookingId);
                        System.Console.WriteLine("Booking Name: "          + entry.name);
                        System.Console.WriteLine("Booking Location: "      + entry.locationName);
                        System.Console.WriteLine("Booking Property: "           + entry.propertyType);
                        System.Console.WriteLine("Booking Nights Stayed: "         + entry.nightsStayed);
                        System.Console.WriteLine("Booking Cost Per Night: $ "         + entry.costPerNight);
                        System.Console.WriteLine("Booking Toal Cost $"         + entry.totalCost);
                        System.Console.WriteLine("Is Booked ?: " + entry.isBooked);
                        }

                        break;
                    case 7:
                        City cityHold = new City();
                        cityHold.Cities();
                        
                        break;
                    case 8:
                        System.Console.WriteLine("Goodbye!");
                        login_correct = false;
                        continuing = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid Option Please Try Again");
                        break;

                }
            }
            }else{
                //Not needed anymore
                System.Console.WriteLine("LOGIN FAILED GOODBYE");
            }

            
            
            
        }
    }
}
