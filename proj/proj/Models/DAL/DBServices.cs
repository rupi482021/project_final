using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kaatsu.Models;
using System.Collections;
using Content_Upload_Model.Models;
using FinalProj.Models;
using proj.Models;

namespace Kaatsu.Models.DAL
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public SqlConnection connect(String conString)
        {
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }


        public customer checkUser(customer customer)
        {
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("checkUserLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        var result = returnParameter.Value;
                        if (result.Equals(1))
                        {
                            while (dr.Read())
                            {
                                if (dr["firstName"] != DBNull.Value)
                                {
                                    customer.Id = Convert.ToInt32(dr["userId"]);
                                    customer.FirstName = (string)dr["firstName"];
                                    customer.SurName = (string)dr["lastName"];
                                    customer.Gender = (string)dr["gender"];
                                    customer.Birthdate = Convert.ToDateTime(dr["dateOfBirth"]).ToShortDateString().ToString();
                                    customer.Email = (string)dr["mail"];
                                    customer.Password = (string)dr["password"];
                                    customer.CategoryType = Convert.ToInt32(dr["CategorycategoryCode"]);
                                    customer.Weight = Convert.ToDouble(dr["weight"]);
                                    customer.Height = Convert.ToInt32(dr["height"]);
                                    customer.Role = (string)dr["role"];
                                }
                                else
                                {
                                    customer.Id = Convert.ToInt32(dr["userId"]);
                                    customer.Email = (string)dr["mail"];
                                    customer.Password = (string)dr["password"];
                                    customer.Role = (string)dr["role"];
                                }
                            }
                        }
                        if (result.Equals(2))
                        {
                            while (dr.Read())
                            {
                                customer.Email = (string)dr["mail"];
                                customer.Password = (string)dr["password"];
                            }
                        }

                        if (result.Equals(3))
                        {

                            customer.Email = "null";
                            customer.Password = "null";
                            customer.FirstName = "not exist";
                        }


                    }

                    return customer;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public customer addNewCustomer(customer newCustomer)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("addCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", newCustomer.Email);
                    cmd.Parameters.AddWithValue("@firstName", newCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", newCustomer.SurName);
                    cmd.Parameters.AddWithValue("@gender", newCustomer.Gender);
                    cmd.Parameters.AddWithValue("@password", newCustomer.Password);
                    cmd.Parameters.AddWithValue("@birthdate", newCustomer.Birthdate);
                    cmd.Parameters.AddWithValue("@weight", newCustomer.Weight);
                    cmd.Parameters.AddWithValue("@height", newCustomer.Height);
                    cmd.Parameters.AddWithValue("@activeLastYear", newCustomer.ActiveLastYear);
                    cmd.Parameters.AddWithValue("@trainKaatsu", newCustomer.TrainKaatsu);
                    cmd.Parameters.AddWithValue("@sportInj", newCustomer.SportInj);
                    cmd.Parameters.AddWithValue("@accident", newCustomer.Accident);
                    cmd.Parameters.AddWithValue("@metadises", newCustomer.Metadises);
                    cmd.Parameters.AddWithValue("@sportType", newCustomer.SportType);

                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;

                    if (result.Equals(1))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("categoryTypeCustomer", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@email", newCustomer.Email);
                            cmd1.Parameters.AddWithValue("@categoryType", newCustomer.CategoryType);
                            cmd1.ExecuteNonQuery();
                        }
                    }


                }

                return newCustomer;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public void updateCustomerDet(customer updateCustomerDet)
        {

            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("updateCust", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", updateCustomerDet.Email);
                    cmd.Parameters.AddWithValue("@firstName", updateCustomerDet.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", updateCustomerDet.SurName);
                    cmd.Parameters.AddWithValue("@gender", updateCustomerDet.Gender);
                    cmd.Parameters.AddWithValue("@password", updateCustomerDet.Password);
                    cmd.Parameters.AddWithValue("@birthdate", updateCustomerDet.Birthdate);
                    cmd.Parameters.AddWithValue("@weight", updateCustomerDet.Weight);
                    cmd.Parameters.AddWithValue("@height", updateCustomerDet.Height);
                    cmd.Parameters.AddWithValue("@activeLastYear", updateCustomerDet.ActiveLastYear);
                    cmd.Parameters.AddWithValue("@trainKaatsu", updateCustomerDet.TrainKaatsu);
                    cmd.Parameters.AddWithValue("@sportInj", updateCustomerDet.SportInj);
                    cmd.Parameters.AddWithValue("@accident", updateCustomerDet.Accident);
                    cmd.Parameters.AddWithValue("@metadises", updateCustomerDet.Metadises);
                    cmd.Parameters.AddWithValue("@sportType", updateCustomerDet.SportType);

                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;

                    if (result.Equals(1))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("categoryTypeCustomer", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@email", updateCustomerDet.Email);
                            cmd1.Parameters.AddWithValue("@categoryType", updateCustomerDet.CategoryType);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<recommendedTrainingProgram> getRTP(int id)
        {
            SqlConnection con = null;
            List<recommendedTrainingProgram> recommendedTrainingProgramList = new List<recommendedTrainingProgram>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("matchTraningProgramForUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            recommendedTrainingProgram rt = new recommendedTrainingProgram();

                            rt.Tcode = Convert.ToInt32(dr["Tcode"]);
                            rt.Tname = (string)dr["Tname"];
                            rt.Instuction = (string)dr["instructions"];
                            rt.LevelType = (string)dr["levelType"];
                            rt.IsForStrengthening = (bool)dr["isForStrengthening"];
                            rt.IsForRehabilitation = (bool)dr["isForRehabilitation"];
                            rt.IsForImproveSport = (bool)dr["isForImproveSport"];
                            rt.Pic = (string)dr["pic"];

                            recommendedTrainingProgramList.Add(rt);
                        }

                        //customerRTP.RecommendedTrainingPrograms = recommendedTrainingProgramList;

                    }
                }

                return recommendedTrainingProgramList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<recommendedTrainingProgram> getNewRecommendedTrainingProgramAR(int customerId, int userAnswer)
        {
            SqlConnection con = null;
            List<recommendedTrainingProgram> recommendedTrainingProgramList = new List<recommendedTrainingProgram>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("updateCustomerDiffucalyyLvl", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userNo", customerId);
                    cmd.Parameters.AddWithValue("@val", userAnswer);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            recommendedTrainingProgram rt = new recommendedTrainingProgram();

                            rt.Tcode = Convert.ToInt32(dr["Tcode"]);
                            rt.Tname = (string)dr["Tname"];
                            rt.Instuction = (string)dr["instructions"];
                            rt.LevelType = (string)dr["levelType"];
                            rt.IsForStrengthening = (bool)dr["isForStrengthening"];
                            rt.IsForRehabilitation = (bool)dr["isForRehabilitation"];
                            rt.IsForImproveSport = (bool)dr["isForImproveSport"];
                            rt.Pic = (string)dr["pic"];

                            recommendedTrainingProgramList.Add(rt);
                        }

                    }
                }

                return recommendedTrainingProgramList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        //public void sentMail()
        //{
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = connect("DBConnectionString");

        //        using (SqlCommand cmd = new SqlCommand("UsersNologgedIn", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {

        //                while (dr.Read())
        //                {

        //                    customer customer = new customer();
        //                    customer.Id = Convert.ToInt32(dr["userId"]);
        //                    customer.Email = (string)dr["mail"];
        //                    customer.FirstName = (string)dr["firstName"];
        //                    customer.SurName = (string)dr["firstName"];
        //                    customer.FirstName = (string)dr["lastName"];
        //                    customer.LastLogIn = Convert.ToDateTime(dr["lastLogIn"]).ToShortDateString().ToString();

        //                    customer.SendMailToUser();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }

        //    }
        //}

        public List<video> postTPC(recommendedTrainingProgram tPC, int id)
        {
            SqlConnection con = null;
            List<video> videoList = new List<video>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("PostTP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", tPC.CustomerId);
                    cmd.Parameters.AddWithValue("@TPC", tPC.Tcode);
                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    //var result = returnParameter.Value;


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            video v = new video();
                            v.VideoId = Convert.ToInt32(dr["VideoCode"]);
                            v.Description = (string)dr["description"];
                            v.Caption = (string)dr["caption"];
                            v.Subtitlepath = (string)dr["subtitlepath"];
                            videoList.Add(v);
                        }
                    }

                }

                return videoList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<video> getvideoList(int id)
        {
            SqlConnection con = null;
            List<video> videoList = new List<video>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("getVideos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            video v = new video();
                            v.VideoId = Convert.ToInt32(dr["VideoCode"]);
                            v.Description = (string)dr["description"];
                            v.Caption = (string)dr["caption"];
                            v.Subtitlepath = (string)dr["subtitlepath"];
                            videoList.Add(v);
                        }
                    }

                }

                return videoList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }
        public int checkRank(int userId)
        {
            int resultU = 0;
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("checkVideoRank", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userNo", userId);
                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        var result = returnParameter.Value;
                        if (result.Equals(1))
                            resultU = 1;
                        if (result.Equals(2))
                            resultU = 2;
                        //else resultU = 0;
                    }
                }
                return resultU;
            }

            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<ManagerReport> getVideoRepList()
        {
            SqlConnection con = null;
            List <ManagerReport> videoRepList = new List<ManagerReport>();

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("checkVideoRating", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ManagerReport videoRep = new ManagerReport();
                            videoRep.VideoCode = Convert.ToInt32(dr["VideoCode"]);
                            videoRep.Description = (string)dr["description"];
                            videoRep.Caption = (string)dr["caption"];
                            videoRep.Sub = (string)dr["subtitlepath"];
                            videoRep.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                            videoRep.LevelType = (string)dr["levelType"];
                            videoRep.NumOfRate = Convert.ToInt32(dr["NoOfRatings"]);
                            videoRep.NumOfDislikes = Convert.ToInt32(dr["NoOfDislike"]);
                            videoRep.NumOfLikes = Convert.ToInt32(dr["NoOfLike"]);
                            videoRep.PrecOfDislikes = Convert.ToInt32(dr["%ofDislike"]);
                            videoRep.PrecOfLikes = Convert.ToInt32(dr["%NoOfLike"]);

                            videoRepList.Add(videoRep);
                        }
                    }

                }

                return videoRepList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }


        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

        // למטה ליאור
        public List<WatchedVideos> getVideoByid(int userId)
        {
            SqlConnection con = null;
            List<WatchedVideos> WatchedVideoList = new List<WatchedVideos>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Video v inner join History h on v.VideoCode = h.videoCode where h.CustomerUseruserId =" + userId;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                while (dr.Read())
                {   // Read till the end of the data into a row
                    WatchedVideos w = new WatchedVideos();
                    w.VideoId = Convert.ToInt32(dr["VideoCode"]);
                    w.Description = (string)dr["description"];
                    w.Caption = (string)dr["caption"];
                    w.Subtitlepath = (string)dr["subtitlepath"];
                    //////w.WatchDate = DateTime.Parse(dr["WatchDate"].ToString());
                    //DateTime WatchDate = (DateTime)dr["WatchDate"];
                    w.WatchDate = (DateTime)dr["WatchDate"];
                    //w.WatchDate = (DateTime)dr["dare"].ToString("dd/MM/yyyy");

                    //Convert(w.WatchDate);

                    WatchedVideoList.Add(w);

                }

                //DateTime myDateTime = DateTime.Now;
                //rank.RankDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                return WatchedVideoList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public List<int> getHistoryByid(int userId)
        {
            SqlConnection con = null;
            List<int> WatchedVideoList = new List<int>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from History h where h.CustomerUseruserId =" + userId;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                int VideoId = 0;
                while (dr.Read())
                {   // Read till the end of the data into a row
                    VideoId = Convert.ToInt32(dr["VideoCode"]);
                    WatchedVideoList.Add(VideoId);
                }


                return WatchedVideoList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public List<int> getRankByid(int userId)
        {
            SqlConnection con = null;
            List<int> RankList = new List<int>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select VideoVideoCode from [Rank] where CustomerUseruserId=" + userId;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                while (dr.Read())
                {   // Read till the end of the data into a row
                    int VideoCode = Convert.ToInt32(dr["VideoVideoCode"]);
                    RankList.Add(VideoCode);

                }
                return RankList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        public DBServices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public List<customer> getcustomer()
        {
            SqlConnection con = null;
            List<customer> customerList = new List<customer>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from [User]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    customer c = new customer();
                    c.Id = Convert.ToInt32(dr["userId"]);
                    c.Email = String.IsNullOrEmpty(dr["mail"].ToString())?"": dr["mail"].ToString();
                    c.Password = String.IsNullOrEmpty(dr["password"].ToString())?"": dr["password"].ToString();
                    c.FirstName = Convert.ToString(dr["firstName"]);
                    c.SurName = Convert.ToString(dr["lastName"]);
                    c.ActiveLastYear = Convert.ToBoolean(dr["activeLastYear"]);
                    c.Role = Convert.ToString(dr["role"]) == "" ? "C" : dr["role"].ToString();
                    customerList.Add(c);
                }
                return customerList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public List<customer> GetUserReport()
        {
            SqlConnection con = null;
            List<customer> customerList = new List<customer>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select ul.[userId], u.[role], u.activeLastYear, u.registraionDate, u.mail, u.[password], u.firstName, u.lastName, max([date]) as lastLogIn from [dbo].[userLogIn] ul inner join [dbo].[User] u on ul.userId=u.userId group by ul.[userId], u.[role], u.activeLastYear, u.registraionDate, u.mail, u.[password], u.firstName, u.lastName";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {
                    if (dr["firstName"] != DBNull.Value)
                    {
                        customer c = new customer();
                        c.Id = Convert.ToInt32(dr["userId"]);
                        c.Email = (string)dr["mail"];
                        c.Password = (string)dr["password"];
                        c.FirstName = Convert.ToString(dr["firstName"]);
                        c.SurName = Convert.ToString(dr["lastName"]);
                        c.ActiveLastYear = Convert.ToBoolean(dr["activeLastYear"]);
                        c.RegistrationDate = (DateTime)dr["registraionDate"];
                        c.Role = Convert.ToString(dr["role"]) == "" ? "C" : dr["role"].ToString();
                        c.LastLogIn = Convert.ToString(dr["lastLogIn"]);
                        //c.LastLogIn = Convert.ToDateTime(dr["lastLogIn"]).ToShortDateString().ToString();

                        customerList.Add(c);
                    }
                }
                return customerList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public List<int> GetUsersNotActice()
        {
            SqlConnection con = null;
            List<int> customerList = new List<int>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select t.userId, t.firstName from (select ul.[userId], u.firstName, max([date]) as lastLogIn from [dbo].[userLogIn] ul inner join [dbo].[User] u on ul.userId=u.userId group by ul.userId, u.firstName) t  where datediff(day, t.lastLogIn, getdate())>=7 and t.firstName is not null";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read()) {

                        int Id = Convert.ToInt32(dr["userId"]);

                        customerList.Add(Id);
                }
                return customerList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public List<DateTime> GetUsersDateActice()
        {
            SqlConnection con = null;
            List<DateTime> customerList = new List<DateTime>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select ul.[userId], u.firstName, max([date]) as lastLogIn from [dbo].[userLogIn] ul inner join [dbo].[User] u on ul.userId=u.userId group by ul.userId, u.firstName";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {

                    DateTime d = (DateTime)dr["lastLogIn"];

                    customerList.Add(d);
                }
                return customerList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public List<Tag> gettagsByvideo(int videocode)
        {
            SqlConnection con = null;
            List<Tag> tagList = new List<Tag>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select t.* from Tags_of_Video tv inner join Tags t on tv.tagcode = t.tagcode where tv.VideoCode =" + videocode;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Tag t = new Tag();
                    t.Tagcode = Convert.ToInt32(dr["tagcode"]);
                    t.Tagname = (string)dr["tagname"];

                    tagList.Add(t);

                }

                return tagList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public List<Tag> gettags()
        {
            SqlConnection con = null;
            List<Tag> tagList = new List<Tag>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Tags";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Tag t = new Tag();
                    t.Tagcode = Convert.ToInt32(dr["tagcode"]);
                    t.Tagname = (string)dr["tagname"];

                    tagList.Add(t);

                }

                return tagList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public List<category> getcategories()
        {
            SqlConnection con = null;
            List<category> categoryList = new List<category>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Category";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    category c = new category();
                    c.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                    c.CategoryName = (string)dr["categoryName"];
                    c.Description = (string)dr["description"];
                    c.PhotoPath = (string)dr["PhotoPath"];

                    categoryList.Add(c);

                }

                return categoryList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        public int getHistoriesID()
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");

                String selectSTR = "select * from History";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); 
                int videoCode = 0;

                while (dr.Read())
                {
                    videoCode = Convert.ToInt32(dr["videoCode"]);
                }

                return videoCode;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public List<category> GetAllCategories()
        {
            SqlConnection con = null;
            List<category> categoryList = new List<category>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Category";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    category c = new category();
                    c.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                    c.CategoryName = (string)dr["categoryName"];
                    c.Description = (string)dr["description"];
                    c.PhotoPath = (string)dr["PhotoPath"];

                    categoryList.Add(c);

                }

                return categoryList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //data reader category name
        public int getCategoryCode(Content content)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Category";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                int categoryCode = 0;

                while (dr.Read())
                {   // Read till the end of the data into a row
                    categoryCode = Convert.ToInt32(dr["categoryCode"]);

                }

                return categoryCode;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        //post content
        public string InsertContent(Content content)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }


            String cStr = BuildInsertContentCommand(content);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                var exeCmd = cmd.ExecuteScalar(); // execute the command
                int videoCode = Convert.ToInt32(exeCmd);

                if (exeCmd != null)
                {
                    foreach (var item in content.TagsArray)
                    {
                        InsertTagsOfVideo(videoCode, item.Tagcode, con);
                    }
                }
                else
                    throw new Exception("no content was inserted");

                return content.Caption;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }



            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //post category
        public void InsertTagsOfVideo(int videoCode, int tagCode, SqlConnection con)
        {
            SqlCommand cmd;

            String cStr = BuildInsertTagsOfVideoCommand(videoCode, tagCode);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no combination was inserted");

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

        }


        private String BuildInsertTagsOfVideoCommand(int videoCode, int tagCode)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat(" Values({0}, {1})", tagCode, videoCode);
            String prefix = "insert into Tags_of_Video " + "(tagcode, VideoCode) ";
            command = prefix + sb.ToString();

            return command;
        }




        //post category
        public string InsertCategory(category category)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertCategoryCommand(category);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no category was inserted");
                return category.CategoryName;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        private String BuildInsertContentCommand(Content content)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat(" Values('{0}', '{1}', '{2}', {3})", content.Description, content.Caption, content.Subtitlepath, content.CategoryCode);
            String prefix = "insert into Video " + "([description],caption, subtitlepath, categoryCode) output inserted.VideoCode ";
            command = prefix + sb.ToString();

            return command;
        }

        //post  User
        public string InsertProfile(Profile profile)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertProfileCommand(profile);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no user was inserted");
                return profile.Mail;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        private String BuildInsertProfileCommand(Profile profile)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", profile.Mail, profile.Password, profile.Role);
            String prefix = "insert into [User]" + "(mail, [password], role)";
            command = prefix + sb.ToString();

            return command;
        }

        //post  RankUser
        public int InsertRank(Rank rank)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertRankCommand(rank);      // helper method to build the insert string
            int result = checkRank(rank.UseruserId); // ליטל 
            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no user was inserted");
                return result;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        private String BuildInsertRankCommand(Rank rank)
        {
            String command;

            StringBuilder sb = new StringBuilder();

            DateTime myDateTime = DateTime.Now;
            rank.RankDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            sb.AppendFormat("Values({0}, {1}, '{2}', '{3}', '{4}')", rank.UseruserId, rank.VideoCode, rank.RankDate, rank.RankValue, rank.RankLike);
            String prefix = "insert into [Rank]" + "(CustomerUseruserId, VideoVideoCode, rankDate, RankValue, RankLike)";
            command = prefix + sb.ToString();

            return command;
        }

        private String BuildInsertCategoryCommand(category category)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", category.CategoryName, category.Description, category.PhotoPath);
            String prefix = "insert into Category" + "(categoryName, [description], PhotoPath)";
            command = prefix + sb.ToString();

            return command;
        }



        public List<Content> getContents()
        {
            SqlConnection con = null;
            List<Content> contentsList = new List<Content>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            }
            catch (Exception ex)
            {
                throw new Exception("failed to connect to the server", ex);
            }

            String selectSTR = "Select * from Video ";

            SqlCommand cmd = new SqlCommand(selectSTR, con);
            List<Tag> tagsList = new List<Tag>();
            try
            {
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr.Read())
                {   // Read till the end of the data into a row
                    int VideoCode = Convert.ToInt32(dr["VideoCode"]);
                    tagsList = getTagsByVideoId(VideoCode);
                    Content c = new Content();
                    c.VideoCode = Convert.ToInt32(dr["VideoCode"]);
                    c.Description = (string)dr["description"];
                    c.Caption = (string)dr["caption"];
                    c.Subtitlepath = (string)dr["subtitlepath"];
                    c.CategoryCode = Convert.ToInt32(dr["categoryCode"]);
                    c.TagsArray = tagsList;
                    //List<string>
                    //string listStrLineElements = (string)dr["highlights"];
                    //c.ListHighlights = listStrLineElements.Split(',').ToList();
                    contentsList.Add(c);
                }
                return contentsList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public List<Tag> getTagsByVideoId(int videoId)
        {
            SqlConnection con = null;


            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            }
            catch (Exception ex)
            {
                throw new Exception("failed to connect to the server", ex);
            }

            String selectSTR = "select b.* from Tags_of_Video a inner join Tags b on a.tagcode = b.tagcode where VideoCode = " + videoId;


            SqlCommand cmd = new SqlCommand(selectSTR, con);

            try
            {
                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Tag> tagsList = new List<Tag>();
                while (dr.Read())
                {   // Read till the end of the data into a row

                    Tag g = new Tag();
                    g.Tagcode = Convert.ToInt32(dr["tagcode"]);
                    g.Tagname = (string)dr["tagname"];
                    tagsList.Add(g);

                }
                return tagsList;

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //update content
        public void updateContent(Content content)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }


            String cStr;

            if (content.Subtitlepath != "")

                cStr = "update Video set description = '" + content.Description + "' , caption = '" + content.Caption + "' , subtitlepath = '" + content.Subtitlepath + "' , categoryCode = " + content.CategoryCode + " where videoCode = " + content.VideoCode;

            else

                cStr = "update Video set description = '" + content.Description + "' , caption = '" + content.Caption + "' , categoryCode = " + content.CategoryCode + " where videoCode = " + content.VideoCode;

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no content was updated");

                deleteTagsOfVideo(content.VideoCode, con);

                foreach (var item in content.TagsArray)
                {
                    InsertTagsOfVideo(content.VideoCode, item.Tagcode, con);
                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //delete tags
        public void deleteTagsOfVideo(int VideoCode, SqlConnection con)
        {

            SqlCommand cmd;


            String cStr = "delete from Tags_of_Video where VideoCode = " + VideoCode;

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command


            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }


        }

        //delete 
        public void DeleteContent(int VideoCode)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = "delete from trainingProgram_Video where VideoVideoCode = " + VideoCode;
            cStr += " delete from Category_Video where VideoVideoCode = " + VideoCode;
            cStr += " delete from favoritesList where TrainingVideoVideoCode = " + VideoCode;
            cStr += " delete from Question_Video where VideoVideoCode = " + VideoCode;
            cStr += " delete from [Rank] where VideoVideoCode = " + VideoCode;
            cStr += " delete from Tags_of_Video where VideoCode = " + VideoCode;
            cStr += " delete from trainingSchedule where VideoVideoCode = " + VideoCode;
            cStr += " delete from Video where VideoCode = " + VideoCode;

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command                          
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //VIDEOS
        public List<video> getAllVideos()
        {
            SqlConnection con = null;
            List<video> videos = new List<video>();


            try
            {
                con = connect("DBConnectionString");

                string query = "select * from video";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            video v = new video();
                            v.VideoId = Convert.ToInt32(dr["VideoCode"]);
                            v.Description = (string)dr["description"];
                            v.Caption = (string)dr["caption"];
                            v.Subtitlepath = (string)(dr["subtitlepath"]);

                            videos.Add(v);
                        }
                    }
                    return videos;
                }

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public int addToFavourits(string userId, string videoId)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format("insert into favoritesList (CustomerUseruserId,TrainingVideoVideoCode) values({0},{1})", userId, videoId);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }

        public List<video> getUserFavouritsVideos(string userId)
        {
            SqlConnection con = connect("DBConnectionString");
            List<video> videos = new List<video>();
            string query = @"select video.* from video
                              inner join favoritesList
                              on favoritesList.TrainingVideoVideoCode = video.VideoCode
                              where favoritesList.CustomerUseruserId =" + userId;

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        video v = new video();
                        v.VideoId = Convert.ToInt32(dr["VideoCode"]);
                        v.Description = (string)dr["description"];
                        v.Caption = (string)dr["caption"];
                        v.Subtitlepath = (string)(dr["subtitlepath"]);
                        videos.Add(v);
                    }
                }
                return videos;
            }
        }

        public int RemoveFromFavourits(string userId, string videoId)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format("delete from favoritesList where CustomerUseruserId ={0} and TrainingVideoVideoCode ={1}", userId, videoId);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }

        //TRAININGS מחזירה רשימה של אימונים
        public List<Training> getAllTrainings(int customerId)
        {
            SqlConnection con = connect("DBConnectionString");
            List<Training> trainingList = new List<Training>();

            try
            {
                //סידור הרשומות בסדר עולה
                string query = "select * from trainings where CustomerUseruserId=" + customerId + " order by date asc";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        //בניית רשימת האימונים
                        while (dr.Read())
                        {
                            Training t = new Training();
                            t.Id = Convert.ToInt32(dr["id"]);
                            t.Hour = Convert.ToInt32(dr["hour"]);
                            t.VideoId = Convert.ToInt32(dr["videoId"]);
                            t.CustomerId = Convert.ToInt32(dr["CustomerUseruserId"]);
                            t.IsCompleted = Convert.ToBoolean(dr["isCompleted"]);
                            t.Date = (DateTime)dr["date"];

                            trainingList.Add(t);
                        }
                    }
                }

                return trainingList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public int CreateTraining(Training training)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format("insert into trainings (videoId,date,isCompleted,CustomerUseruserId,hour)" +
                " values({0},'{1}','{2}','{3}',{4})", training.VideoId, training.Date.ToString("yyyy-MM-dd"), 0, training.CustomerId, training.Hour);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }

        public int TrainingDone(int trainingId)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format("update trainings set isCompleted=1 where id={0}", trainingId);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }
        public int DeleteTraining(int id)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format("delete from trainings where id={0}", id);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }

        //Questions
        public List<Question> GetAllQuestions()
        {
            SqlConnection con = null;
            List<Question> questions = new List<Question>();


            try
            {
                con = connect("DBConnectionString");

                string query = "select * from user_questions order by created desc";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Question q = new Question();
                            q.Id = Convert.ToInt32(dr["id"]);
                            q.UserId = Convert.ToInt32(dr["userId"]);
                            q.ManagerId = Convert.ToInt32(dr["managerId"]);
                            q.QuestionText = (string)dr["question"];
                            q.Answer = (string)dr["answer"];
                            q.Status = (bool)dr["status"];
                            q.Created = (DateTime)dr["created"];
                            q.AnswerDate = (DateTime)dr["answerDate"];

                            questions.Add(q);
                        }
                    }
                    return questions;
                }

            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        //מתרחשת כאשר המשתמש יוצר שאלה
        public int CreateQuestion(Question q)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format(@"insert into user_questions 
                (userId,managerId,question,answer,status,created,answerDate)" +
                " values({0},{1},'{2}','{3}','{4}','{5}','{6}')",
                q.UserId,
                q.ManagerId,
                q.QuestionText,
                q.Answer,
                0,
                DateTime.Now.ToString("yyyy-MM-dd"),
                DateTime.Now.ToString("yyyy-MM-dd")
                );
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }
        //מתרחשת כאשר המנהל עונה על השאלה
        public int UpdateQuestion(Question question)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format(@"update user_questions 
                                           set status=1, 
                                           answer='{0}',
                                           answerDate='{1}',
                                           managerId={2}
                                           where id={3}",
                                           question.Answer,
                                           DateTime.Now.ToString("yyyy-MM-dd"),
                                           question.ManagerId,
                                           question.Id);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }
        //מתרחשת כאשר המנהל מוחק שאלה
        public int DeleteQuestion(int id)
        {
            SqlConnection con = connect("DBConnectionString");
            string query = string.Format(@"delete from user_questions where id={0}",
                                           id);
            SqlCommand cmd = new SqlCommand(query, con);
            int effected = cmd.ExecuteNonQuery();
            return effected;
        }


        //lior
        public int InsertWatchVideo(History history)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw new Exception("failed to connect to the server", ex);
            }

            String cStr = BuildInsertHistoryCommand(history);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command 

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                if (numEffected == 0)
                    throw new Exception("no category was inserted");
                return history.VideoCode;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        private String BuildInsertHistoryCommand(History history)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values({0}, {1})", history.VideoCode, history.CustomerUseruserId);
            String prefix = "insert into History" + "(videoCode, CustomerUseruserId)";
            command = prefix + sb.ToString();

            return command;
        }
    }

}