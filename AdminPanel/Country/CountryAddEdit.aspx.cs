using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Configuration;
using AddressBook.ENT;
using AddressBook.BAL;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblMode.Text = "Edit Country";
                btnAdd.Text = "Edit";
                fillControls(Convert.ToInt32(Request.QueryString["CountryID"]));

            }
            else
            {
                lblMode.Text = "Add Country";
                btnAdd.Text = "Add";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        #region Server side validation
        string strErrorMsg = "";
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMsg += "- Enter Contry name.<br/>";

        }
        if (txtCountryCode.Text.Trim() == "")
        {
            strErrorMsg += "- Enter Contry code.<br/>";

        }

        if (strErrorMsg != "")
        {
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
            lblErrMsg.Text = strErrorMsg;
            return;
        }
        #endregion Server side validation

        #region Collect Data
        CountryENT entCountry = new CountryENT();
        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();

        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();

        }
        #endregion Collect Data

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] != null)
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"].ToString().Trim());
            if (balCountry.Update(entCountry))
            {
                ClearField();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblErrMsg.Text = balCountry.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
        else
        {

            if (balCountry.Insert(entCountry))
            {
                ClearField();
                lblErrMsg.Text = "Data Inserted Successfully";
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
            else
            {
                lblErrMsg.Text = balCountry.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
    }
    #endregion Button : Save

    #region Clear Fields
    private void ClearField()
    {
        txtCountryCode.Text = "";
        txtCountryName.Text = "";
        txtCountryName.Focus();
    }
    #endregion Clear Fields

    #region Fill Controls
    private void fillControls(SqlInt32 CountryID)
    {

        CountryBAL balCountry = new CountryBAL();
        CountryENT entCountry = new CountryENT();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.ToString();
        }
        if(!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.ToString();
        }

        if (balCountry.Message != null)
        {
            lblErrMsg.Text = balCountry.Message;
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }
    }
    #endregion Fill Controls
}