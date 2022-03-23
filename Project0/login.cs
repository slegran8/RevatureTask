using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Project0{


    class login{

        public String userName { get; set; }
        public String password { get; set; }   

        SqlConnection con = new SqlConnection(@"server=DESKTOP-NVMDB78\SHANEINSTANCE;database=HotelDatabase;integrated security=true");

        public bool LoginStart(login newLogin)
        {

            //bool ifExists = false;

            SqlCommand cmd_Login = new SqlCommand("select count(*) from loginTable where username = @userName AND password = @password",con);
            //SqlDataReader readLogin = null;

            cmd_Login.Parameters.AddWithValue("@userName", newLogin.userName);
            cmd_Login.Parameters.AddWithValue("@password", newLogin.password);

            try
                {
                con.Open();
                int credential_count = Convert.ToInt32(cmd_Login.ExecuteScalar());
                if (credential_count > 0){
                    return true;
                }else{
                    return false;
                }
                
            
                }
                catch(SqlException es)
                {
                    //System.Console.WriteLine("Failed?");
                    throw new Exception(es.Message);
                    
                }
                finally
                {
                   
                    con.Close();

                }
             

            
        }

    }
}
