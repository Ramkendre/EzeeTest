using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;



public class UserRegistrationDAL
{

    DataSet ds = new DataSet();
    int status;
    private SqlCommand sqlCommand = new SqlCommand();
    private string connectionString = "server=www.come2mycity.com;User Id=come2mycity; Password=myct2013;Min Pool Size=20; Max Pool Size=200;";
    //private string connectionString = "server=118.67.249.128;User Id=ezeesoftschooluser; Password=ezeeschool!@12;Min Pool Size=20; Max Pool Size=200;";
    private SqlConnection sqlConnection;
    public UserRegistrationDAL()
    {
        sqlConnection = new SqlConnection(connectionString);
    }


    public int DALInsertUserRegistrationInitial(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                string sqlQuery=" insert into [Come2myCityDB].[dbo].UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrLastName,usrCityId,usrGender,usrFriRelGroup,usrPIN,usrDOB,FaxNo,usrPhoneNo,OfficeNo,usrEmailId,usrAltMobileNo,StrDevId) " +
                                              " values(@UserId,@MobileNo,@Address,@Password,@FirstName,@LastName,@CityId,@Gender,@FriendGroup,@PIN,@DOB,@faxNo,@PhoneNumber,@officeNo,@EmailId,@AltMobileNo,@DevId) ";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);

              



                //ur.usrAltMobileNo="123456980";
                cmd.Parameters.AddWithValue("@UserId", ur.usrUserId);
                cmd.Parameters.AddWithValue("@MobileNo", ur.usrMobileNo);
                cmd.Parameters.AddWithValue("@AltMobileNo", ur.usrAltMobileNo ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@Address", ur.usrAddress ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", ur.usrPassword ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FirstName", ur.usrFirstName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", ur.usrLastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", ur.usrGender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CityId", ur.usrCityId );
                cmd.Parameters.AddWithValue("@FriendGroup", ur.frnrelGroup ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PIN", ur.usrPIN ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DOB", ur.usrDOB ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@faxNo", ur.FaxNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", ur.usrPhoneNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@officeNo", ur.OfficeNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EmailId", ur.usrEmailId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DevId", ur.StrDevId ?? (object)DBNull.Value);



                
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                status = cmd.ExecuteNonQuery();






                // SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationIntialInsert", par);
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        return status;
    }
    public int DALIsExistUser(UserRegistrationBLL ur)
    {


        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
            par[1] = new SqlParameter("@status", 11);
            par[1].Direction = ParameterDirection.Output;

            sqlCommand.CommandText = "[Come2myCityDB].[dbo].[spUserRegistrationIsExist]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddRange(par);
            sqlCommand.Connection = sqlConnection;
            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();



            // Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
            status = (int)par[1].Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }

        return status;

    }


}
