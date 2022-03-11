using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using AddressBook.BAL;
public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
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

    #region Fill GridView
    private void fillGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        if (dtContact != null && dtContact.Rows.Count > 0)
        {
            gvContact.DataSource = dtContact;
            gvContact.DataBind();
        }
        else
        {
            gvContact.DataSource = dtContact;
            gvContact.DataBind();

            lblErrMsg.Text = "No data";
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }
     
    }
    #endregion Fill GridView

    #region gvContact : RowCommand Delete
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                ContactBAL balContact = new ContactBAL();

                if(balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    fillGridView();
                }
                else
                {
                    lblErrMsg.Text = balContact.Message;
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;
                }
            }
        } 
       
    }
    #endregion gvContact : RowCommand Delete

}