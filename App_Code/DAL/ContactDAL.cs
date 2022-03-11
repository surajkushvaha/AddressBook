using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactDAL : DatabaseConfig
    {
        #region Constructor

        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region LocalVariables
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion LocalVariables

        #region Insert Operation
        public Boolean Insert(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_Insert";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = entContact.ContactNo;
                        objCmd.Parameters.Add("@WhatsappNo", SqlDbType.VarChar).Value = entContact.WhatsappNo;
                        objCmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = entContact.BirthDate;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Age", SqlDbType.Int).Value = entContact.Age;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        objCmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar).Value = entContact.BloodGroup;
                        objCmd.Parameters.Add("@FacebookID", SqlDbType.VarChar).Value = entContact.FacebookID;
                        objCmd.Parameters.Add("@LinkedINID", SqlDbType.VarChar).Value = entContact.LinkedINID;

                        #endregion Prepare Command


                        objCmd.ExecuteNonQuery();
                        entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_UpdateByPK";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = entContact.ContactID;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = entContact.ContactNo;
                        objCmd.Parameters.Add("@WhatsappNo", SqlDbType.VarChar).Value = entContact.WhatsappNo;
                        objCmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = entContact.BirthDate;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Age", SqlDbType.Int).Value = entContact.Age;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        objCmd.Parameters.Add("@BloodGroup", SqlDbType.VarChar).Value = entContact.BloodGroup;
                        objCmd.Parameters.Add("@FacebookID", SqlDbType.VarChar).Value = entContact.FacebookID;
                        objCmd.Parameters.Add("@LinkedINID", SqlDbType.VarChar).Value = entContact.LinkedINID;

                        #endregion Prepare Command


                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);

                        #endregion Prepare Command


                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Delete Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectAll";
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data & Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion SelectAll

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        ContactENT entContact = new ContactENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["ContactID"].Equals(DBNull.Value))
                                        entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);

                                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                                        entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                    if (!objSDR["StateID"].Equals(DBNull.Value))
                                        entContact.StateID = Convert.ToInt32(objSDR["StateID"]);

                                    if (!objSDR["CityID"].Equals(DBNull.Value))
                                        entContact.CityID = Convert.ToInt32(objSDR["CityID"]);

                                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                        entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);

                                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                                        entContact.ContactName = Convert.ToString(objSDR["ContactName"]);

                                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                        entContact.ContactNo = Convert.ToString(objSDR["ContactNo"]);

                                    if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                                        entContact.WhatsappNo = Convert.ToString(objSDR["WhatsappNo"]);

                                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                        entContact.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);

                                    if (!objSDR["Email"].Equals(DBNull.Value))
                                        entContact.Email = Convert.ToString(objSDR["Email"]);

                                    if (!objSDR["Age"].Equals(DBNull.Value))
                                        entContact.Age = Convert.ToInt32(objSDR["Age"]);

                                    if (!objSDR["Address"].Equals(DBNull.Value))
                                        entContact.Address = Convert.ToString(objSDR["Address"]);

                                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                                        entContact.BloodGroup = Convert.ToString(objSDR["BloodGroup"]);

                                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                                        entContact.FacebookID = Convert.ToString(objSDR["FacebookID"]);

                                    if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                                        entContact.LinkedINID = Convert.ToString(objSDR["LinkedINID"]);

                                    if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                        entContact.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);

                                    break;
                                }
                            }
                        }
                        return entContact;

                        #endregion Read Data & Set Controls


                    }
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }

        #endregion SelectByPK

       
    }
}