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

public partial class AdminPanel_State_StateAddEditPage : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["StateID"] != null)
            {
                lblMode.Text = "Edit State";
                btnAdd.Text = "Edit";
                fillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {
                lblMode.Text = "Add State";
                btnAdd.Text = "Add";

            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        

        #region Server Side Validation
        //server side validation
        String strErrorMsg = "";
        if (ddlCountry.SelectedIndex == 0)
        {
            strErrorMsg += "- Select  Country <br/>";
        }
        if (txtStateName.Text.Trim() == "")
        {
            strErrorMsg += "- Enter  State <br/>";
        }
        if (txtStateCode.Text.Trim() == "")
        {
            strErrorMsg += "- Enter  State Code <br/>";
        }
        if (strErrorMsg != "")
        {
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
            lblErrMsg.Text = strErrorMsg;
            return;
        }
        #endregion Server Side Validation

        #region Collect Data
        StateENT entState = new StateENT();
        if (ddlCountry.SelectedIndex != 0)
        {
            entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        }
        if (txtStateName.Text.Trim() != "")
        {
            entState.StateName = txtStateName.Text.Trim();     
        }
        if (txtStateCode.Text.Trim() != "")
        {
            entState.StateCode = txtStateCode.Text.Trim();
        }
        #endregion Collect Data

        StateBAL balState = new StateBAL();
        if (Request.QueryString["StateID"] != null)
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"].ToString().Trim());
            if (balState.Update(entState))
            {
                ClearField();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblErrMsg.Text = balState.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
        else
        {

            if (balState.Insert(entState))
            {
                ClearField();
                lblErrMsg.Text = "Data Inserted Successfully";
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
            else
            {
                lblErrMsg.Text = balState.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
    }
    #endregion Button : Save

    #region Clear Fields
    private void ClearField()
    {
        ddlCountry.SelectedIndex = 0;
        txtStateCode.Text = "";
        txtStateName.Text = "";
        ddlCountry.Focus();
    }
    #endregion Clear Fields

    #region FillDropDown
    private void FillDropDownList()
    {
        CommonFillMethods.fillDropDownCuntry(ddlCountry);
    }
    #endregion FillDropDown

    #region FillControl
    private void fillControls(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        StateENT entState = new StateENT();

        entState = balState.SelectByPK(StateID);

        if (!entState.CountryID.IsNull)
        {
            ddlCountry.SelectedValue = entState.CountryID.ToString().Trim();

        }
        if(!entState.StateName.IsNull)
        {
            txtStateName.Text = entState.StateName.ToString();

        }
        if(!entState.StateCode.IsNull)
        {
            txtStateCode.Text = entState.StateCode.ToString();
        }

        if (balState.Message != null)
        {
            lblErrMsg.Text = balState.Message;
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }
    }
    #endregion FillControl
}