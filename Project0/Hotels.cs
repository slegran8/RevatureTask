using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Project0{


    class Hotels{

        
        public int bookingId { get; set; }
        public String name { get; set; }
        public String locationName { get; set; }   

        public String propertyType { get; set; }

        public int nightsStayed { get; set; }

        public int costPerNight { get; set; }

        public int totalCost { get; set; }
        public bool isBooked { get; set;}

        

            
        SqlConnection con = new SqlConnection(@"server=DESKTOP-NVMDB78\SHANEINSTANCE;database=HotelDatabase;integrated security=true");
        public string AddNewBooking(Hotels newBooking){
            

            SqlCommand cmd_addBooking = new SqlCommand("insert into Booking values(@name, @locationName, @propertyType, @nightsStayed, @costPerNight,@totalCost, @isBooked)",con);

            cmd_addBooking.Parameters.AddWithValue("@name", newBooking.name);
            cmd_addBooking.Parameters.AddWithValue("@locationName", newBooking.locationName);
            cmd_addBooking.Parameters.AddWithValue("@propertyType", newBooking.propertyType);
            cmd_addBooking.Parameters.AddWithValue("@nightsStayed", newBooking.nightsStayed);
            cmd_addBooking.Parameters.AddWithValue("@costPerNight", newBooking.costPerNight);
            cmd_addBooking.Parameters.AddWithValue("@totalCost", newBooking.totalCost);
            cmd_addBooking.Parameters.AddWithValue("@isBooked", newBooking.isBooked);

            try
                {
                    con.Open();
                    cmd_addBooking.ExecuteNonQuery();                    
                }
                catch(SqlException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                    return "Booked Successfully";

        }

        public void Show_Locations(){

            System.Console.WriteLine("1. New York City\n"
            +"2. Los Angeles\n" 
            +"3. Charlotte"   
            );
        }

        public List<Hotels> GetBookingList()
        {
            SqlCommand cmd_allBookings = new SqlCommand("select * from Booking",con);
            SqlDataReader readBookings = null;
            List<Hotels> lst_BookingsFromDB = new List<Hotels>();

            try
                {
                con.Open();
                readBookings = cmd_allBookings.ExecuteReader();
                while (readBookings.Read())
                {
                    
                    lst_BookingsFromDB.Add(new Hotels()
                    {
                        bookingId = Convert.ToInt32(readBookings[0]),
                        name = readBookings[1].ToString(),
                        locationName = readBookings[2].ToString(),
                        propertyType = readBookings[3].ToString(),
                        nightsStayed = Convert.ToInt32(readBookings[4]),
                        costPerNight = Convert.ToInt32(readBookings[5]),
                        totalCost = Convert.ToInt32(readBookings[6]),
                        isBooked = Convert.ToBoolean(readBookings[7])
                    });
                }

                }
                catch(SqlException se)
                {
                    throw new Exception(se.Message);
                }
                finally
                {
                    readBookings.Close();
                    con.Close();

                }
            
            return lst_BookingsFromDB;
        }

        public List<Hotels> GetOderedList() //Ordered List of all booking ascending by order price
        {
            SqlCommand cmd_allBookings = new SqlCommand("select * from Booking ORDER By totalCost ASC" ,con);
            SqlDataReader readBookings = null;
            List<Hotels> lst_OrderedFromDB = new List<Hotels>();

            try
                {
                con.Open();
                readBookings = cmd_allBookings.ExecuteReader();
                while (readBookings.Read())
                {
                    
                    lst_OrderedFromDB.Add(new Hotels()
                    {
                        bookingId = Convert.ToInt32(readBookings[0]),
                        name = readBookings[1].ToString(),
                        locationName = readBookings[2].ToString(),
                        propertyType = readBookings[3].ToString(),
                        nightsStayed = Convert.ToInt32(readBookings[4]),
                        costPerNight = Convert.ToInt32(readBookings[5]),
                        totalCost = Convert.ToInt32(readBookings[6]),
                        isBooked = Convert.ToBoolean(readBookings[7])
                    });
                }

                }
                catch(SqlException se)
                {
                    throw new Exception(se.Message);
                }
                finally
                {
                    readBookings.Close();
                    con.Close();

                }
            
            return lst_OrderedFromDB;
        }

        public List<Hotels> GetOderedListDesc() //Ordered list descending by Booking Price
        {
            SqlCommand cmd_allBookings = new SqlCommand("select * from Booking ORDER By totalCost DESC" ,con);
            SqlDataReader readBookings = null;
            List<Hotels> lst_OrderedFromDB = new List<Hotels>();

            try
                {
                con.Open();
                readBookings = cmd_allBookings.ExecuteReader();
                while (readBookings.Read())
                {
                    
                    lst_OrderedFromDB.Add(new Hotels()
                    {
                        bookingId = Convert.ToInt32(readBookings[0]),
                        name = readBookings[1].ToString(),
                        locationName = readBookings[2].ToString(),
                        propertyType = readBookings[3].ToString(),
                        nightsStayed = Convert.ToInt32(readBookings[4]),
                        costPerNight = Convert.ToInt32(readBookings[5]),
                        totalCost = Convert.ToInt32(readBookings[6]),
                        isBooked = Convert.ToBoolean(readBookings[7])
                    });
                }

                }
                catch(SqlException se)
                {
                    throw new Exception(se.Message);
                }
                finally
                {
                    readBookings.Close();
                    con.Close();

                }
            
            return lst_OrderedFromDB;
        }

        public string EditBooking(Hotels newBooking)
        {

            SqlCommand cmd_update = new SqlCommand("update Booking set name =@newName,locationName =@newLocationName,propertyType =@newPropertyType,nightsStayed =@newNightsStayed, costPerNight =@newCostPerNight, totalCost =@newTotalCost WHERE bookingId =@bookingId",con);
            cmd_update.Parameters.AddWithValue("@newName", newBooking.name);
            cmd_update.Parameters.AddWithValue("@newLocationName", newBooking.locationName);
            cmd_update.Parameters.AddWithValue("@newPropertyType", newBooking.propertyType);
            cmd_update.Parameters.AddWithValue("@newNightsStayed", newBooking.nightsStayed);
            cmd_update.Parameters.AddWithValue("@newCostPerNight", newBooking.costPerNight);
            cmd_update.Parameters.AddWithValue("@newTotalCost", newBooking.totalCost);
            cmd_update.Parameters.AddWithValue("@bookingId",newBooking.bookingId);

            try
                {
                    con.Open();
                    cmd_update.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return "Booking Edited";
                
        }

        public bool CheckIfIdExists(int id){
        
            SqlCommand cmd_check = new SqlCommand("SELECT COUNT(*) FROM Booking WHERE bookingId = @BookingId",con);
            
            cmd_check.Parameters.AddWithValue("@BookingId", id);

             try
                {
                con.Open();
                int id_check = Convert.ToInt32(cmd_check.ExecuteScalar());

                //System.Console.WriteLine("ID VALUE is " + id_check);

                if (id_check > 0){
                    return true;
                }else{
                    return false;
                }
                
            
                }
                catch(SqlException es)
                {
                    
                    throw new Exception(es.Message);
                    
                }
                finally
                {
                   
                    con.Close();

                }

        }
        public string DeleteBooking(int bookingID){
             SqlCommand cmd_deleteProduct = new SqlCommand("Delete from Booking where bookingId=@bookingId",con);
            cmd_deleteProduct.Parameters.AddWithValue("@bookingId",bookingID);

            try
            {
                con.Open();
                cmd_deleteProduct.ExecuteNonQuery();
            }
            catch (System.Exception es)
            {
                
                System.Console.WriteLine(es.Message);
            }
            finally
            {
                con.Close();
            }
            
            return "************";
        }

      


        public String Location_Choice(int loc_choice){
            if (loc_choice == 1){
                System.Console.WriteLine("You chose " + "New York City");
                return "New York City";
            }
            else if (loc_choice == 2){
                System.Console.WriteLine("You chose " + "Los Angeles");
                return "Los Angeles";
            }
            else if (loc_choice == 3){
                System.Console.WriteLine("You chose " + "Charlotte");
                return "Charlotte";
            }else{
                System.Console.WriteLine("INVALID");
                return " ";
            }
        }
    
    }
}