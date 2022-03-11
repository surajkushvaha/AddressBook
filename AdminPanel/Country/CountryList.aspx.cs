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

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {

            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
        else
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();

            lblErrMsg.Text = "No data";
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }

    }
    #endregion Fill GridView

    #region gvCountry : RowCommand Delete
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                CountryBAL balCountry = new CountryBAL();

                if (balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    fillGridView();

                }
                else
                {

                    lblErrMsg.Text = balCountry.Message;
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;

                }
            }
        }

    }
    #endregion gvCountry : RowCommand Delete


}