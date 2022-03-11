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
using AddressBook.BAL;

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

        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll();

        if (dtState != null && dtState.Rows.Count > 0)
        {

            gvState.DataSource = dtState;
            gvState.DataBind();
        }
        else
        {
            gvState.DataSource = dtState;
            gvState.DataBind();

            lblErrMsg.Text = "No data";
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
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
                StateBAL balState = new StateBAL();

                if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    fillGridView();
                }
                else
                {

                    lblErrMsg.Text = balState.Message;
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;
                }
            }
        } 
       
    }
    #endregion gvState : RowCommand

}