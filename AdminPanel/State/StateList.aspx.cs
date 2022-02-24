using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillGridView();
        }
        
    }
    #endregion Load Event

    #region FillGridView
    private void fillGridView()
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectAll";
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvState.DataSource = objSDR;
                gvState.DataBind();
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Read the value and set the controls
        }
        catch (Exception exc)
        {
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
            lblErrMsg.Text = exc.Message;

        }
        finally
        {
            if(objConn.State== ConnectionState.Open)
                objConn.Close(); 

        }

    }
    #endregion FillGridView

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecrord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        } 
       
    }
    #endregion gvState : RowCommand

    #region Delete Record
    protected void DeleteRecrord(SqlInt32 StateID)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        try
        {
            #region Set the connection & Command object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_DeleteByPK";
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
            objCmd.ExecuteNonQuery();
            #endregion Set the connection & Command Object
            if (objConn.State == ConnectionState.Open)
                objConn.Close(); 

        }
        catch (Exception exc)
        {
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
            lblErrMsg.Text = exc.Message;

        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close(); 

        }

        fillGridView();
    }
    #endregion Delete Record
}