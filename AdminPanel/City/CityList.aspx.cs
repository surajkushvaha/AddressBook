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
public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            filGriedView();
        }
    }
    #endregion Load Event

    #region FillGriedView
    private void filGriedView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll();

        if (dtCity != null && dtCity.Rows.Count > 0)
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();
        }
        else
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();

            lblErrMsg.Text = "No data";
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }
        
    }
    #endregion FillGriedView

    #region gvCity : RowCommand Delete
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                CityBAL balCity = new CityBAL();

                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    filGriedView();
                }
                else
                {
                    lblErrMsg.Text = balCity.Message;
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;
                }
                
            }
        } 
       
    }
    #endregion gvCity : RowCommand Delete

    
}