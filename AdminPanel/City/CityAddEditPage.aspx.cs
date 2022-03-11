using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEditPage : System.Web.UI.Page
{
    #region Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                lblMode.Text = "Edit City";
                btnAdd.Text = "Edit";
                fillControls(Convert.ToInt32(Request.QueryString["CityID"]));

            }
            else
            {
                lblMode.Text = "Add City";
                btnAdd.Text = "Add";

            }
        }
    }
        #endregion Load Event

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        #region Server Side Validation
        String strErrorMsg = "";
        if (ddlState.SelectedIndex == 0)
        {
            strErrorMsg += "- Select  State <br/>";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMsg += "- Enter  City <br/>";
        }
        if (txtPinCode.Text.Trim() == "")
        {
            strErrorMsg += "- Enter  Pin Code <br/>";
        }
        if (txtSTDCode.Text.Trim() == "")
        {
            strErrorMsg += "- Enter  STD Code <br/>";
        }
        if (strErrorMsg != "")
        {
            lblMsgDiv.Visible = true;
            lblErrMsg.Text = strErrorMsg;
            lblErrMsg.Visible = true;
            return;
        }
        #endregion Server Side Validation

        #region Collect Form Data

        CityENT entCity = new CityENT();

        if (ddlState.SelectedIndex > 0)
            entCity.StateID =Convert.ToInt32(ddlState.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            entCity.STDCode = txtSTDCode.Text.Trim();

        if (txtPinCode.Text.Trim() != "")
            entCity.PinCode = txtPinCode.Text.Trim();


        #endregion Collect Form Data

        CityBAL balCity = new CityBAL();
        if (Request.QueryString["CityID"] != null)
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"].ToString().Trim());
            if(balCity.Update(entCity)){
                ClearField();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
            }
            else
            {
                lblErrMsg.Text = balCity.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
        else
        {

            if (balCity.Insert(entCity))
            {
                ClearField();
                lblErrMsg.Text = "Data Inserted Successfully";
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
            else
            {
                lblErrMsg.Text = balCity.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
       


    }
    #endregion Button : Save

    #region Clear Form
    private void ClearField()
    {
        ddlState.SelectedIndex = 0;
        txtCityName.Text = "";
        txtPinCode.Text = "";
        txtSTDCode.Text = "";

        ddlState.Focus();
    }
    #endregion Clear Form

    #region Fill DropDown
    private void FillDropDownList()
    {
        CommonFillMethods.fillDropDownState(ddlState);
        

    }
    #endregion Fill DropDown

    #region Fill Controls

    private void fillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();
        entCity = balCity.SelectByPK(CityID);
        if(!entCity.StateID.IsNull)
            ddlState.SelectedValue = entCity.StateID.Value.ToString().Trim();
        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString().Trim();
        if (!entCity.STDCode.IsNull)
            txtSTDCode.Text = entCity.STDCode.Value.ToString().Trim();
        if (!entCity.PinCode.IsNull)
            txtPinCode.Text = entCity.PinCode.Value.ToString().Trim();
       
        if(balCity.Message != null)
        {
            lblErrMsg.Text = balCity.Message;
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }

    }
    #endregion Fill Controls

}