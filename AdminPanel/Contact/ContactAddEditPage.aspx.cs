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

public partial class AdminPanel_Contact_ContactAddEditPage : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    
    {
        if (!Page.IsPostBack)
        {
            fillDropDown();
            if (Request.QueryString["ContactID"] != null)
            {
                lblMode.Text = "Edit Contact";
                btnAdd.Text = "Edit";
                fillControls(Convert.ToInt32(Request.QueryString["ContactID"]));

            }
            else
            {
                lblMode.Text = "Add Contact";
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
            if (ddlCountry.SelectedIndex == 0)
            {
                strErrorMsg += "- Select  Country <br/>";
            }
            if (ddlState.SelectedIndex == 0)
            {
                strErrorMsg += "- Select  State <br/>";
            }
            if (ddlCity.SelectedIndex == 0)
            {
                strErrorMsg += "- Select  City <br/>";
            }
            if (ddlContactCategory.SelectedIndex == 0)
            {
                strErrorMsg += "- Select  Contact Category <br/>";
            }
            if (txtContactName.Text.Trim() == "")
            {
                strErrorMsg += "- Enter  Contact Name <br/>";
            }
            if (txtContactNo.Text.Trim() == "")
            {
                strErrorMsg += "- Enter  Contact No <br/>";
            }
            if (txtEmail.Text.Trim() == "")
            {
                strErrorMsg += "- Enter  Email <br/>";
            }
            if (txtAddress.Text.Trim() == "")
            {
                strErrorMsg += "- Enter  Address <br/>";
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
            ContactENT entContact = new ContactENT();

            if (ddlCountry.SelectedIndex != 0)
            {
                entContact.CountryID =Convert.ToInt32(ddlCountry.SelectedValue.Trim());
            }
            if (ddlState.SelectedIndex != 0)
            {
                entContact.StateID = Convert.ToInt32(ddlState.SelectedValue.Trim());
            }
            if (ddlCity.SelectedIndex != 0)
            {
                entContact.CityID = Convert.ToInt32(ddlCity.SelectedValue.Trim());
            }
            if (ddlContactCategory.SelectedIndex != 0)
            {
                entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue.Trim());
            }
            if (txtContactName.Text.Trim() != "")
            {
                entContact.ContactName = txtContactName.Text.Trim();
            }
            if (txtContactNo.Text.Trim() != "")
            {
                entContact.ContactNo = txtContactNo.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                entContact.Email = txtEmail.Text.Trim();
            }
            if (txtAddress.Text.Trim() != "")
            {
                entContact.Address = txtAddress.Text.Trim();
            }
            if (txtBirthDate.Text.Trim() != "")
            {
                entContact.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
            }
           
            if(txtAge.Text.Trim()!= "")
                entContact.Age = Convert.ToInt32(txtAge.Text.Trim());

            entContact.WhatsappNo = txtWhatsappNo.Text.Trim();
            entContact.BloodGroup = txtBloodGroup.Text.Trim();
            entContact.FacebookID = txtFacebookID.Text.Trim();
            entContact.LinkedINID = txtLinkedInID.Text.Trim();
        
        #endregion Collect Data 

            ContactBAL balContact = new ContactBAL();
            if (Request.QueryString["ContactID"] != null)
            {
                entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"].ToString().Trim());
                if (balContact.Update(entContact))
                {
                    ClearField();
                    Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                }
                else
                {
                    lblErrMsg.Text = balContact.Message;
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;
                }
            }
            else
            {

                if (balContact.Insert(entContact))
                {
                    ClearField();
                    lblErrMsg.Text = "Data Inserted Successfully";
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;
                }
                else
                {
                    lblErrMsg.Text = balContact.Message;
                    lblErrMsg.Visible = true;
                    lblMsgDiv.Visible = true;
                }
            }
       

    }

    #endregion Button : Save

    #region Clear Form
    private void ClearField()
    {
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;
        ddlContactCategory.SelectedIndex = 0;
        txtContactName.Text = "";
        txtContactNo.Text = "";
        txtWhatsappNo.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFacebookID.Text = "";
        txtLinkedInID.Text = "";

        ddlCountry.Focus();

    }
    #endregion Clear Form

    #region fillDropDown
    private void fillDropDown(){
        CommonFillMethods.fillDropDownCuntry(ddlCountry);
        CommonFillMethods.fillDropDownState(ddlState);
        CommonFillMethods.fillDropDownCity(ddlCity);
        CommonFillMethods.fillDropDownContactCategory(ddlContactCategory);

    }

    #endregion fillDropDown

    #region Fill Controls

    private void fillControls(SqlInt32 ContactID)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID);
        if (!entContact.CountryID.IsNull)
        {
            ddlCountry.SelectedValue = entContact.CountryID.ToString().Trim();
        }
        if (!entContact.StateID.IsNull)
        {
            ddlState.SelectedValue = entContact.StateID.ToString().Trim();
        }
        if (!entContact.CityID.IsNull)
        {
            ddlCity.SelectedValue = entContact.CityID.ToString().Trim();
        }
        if (!entContact.ContactCategoryID.IsNull)
        {
            ddlContactCategory.SelectedValue = entContact.ContactCategoryID.ToString().Trim();
        }
        if (!entContact.ContactName.IsNull)
        {
            txtContactName.Text = entContact.ContactName.ToString().Trim();
        }
        if (!entContact.ContactNo.IsNull)
        {
            txtContactNo.Text = entContact.ContactNo.ToString().Trim();
        }
        if (!entContact.WhatsappNo.IsNull)
        {
            txtWhatsappNo.Text = entContact.WhatsappNo.ToString().Trim();
        }
        if (!entContact.BirthDate.IsNull)
        {
            txtBirthDate.Text = (entContact.BirthDate).ToString().Trim();
        }
        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.ToString().Trim();
        }
        if (!entContact.Age.IsNull)
        {
            txtAge.Text = entContact.Age.ToString().Trim();
        }
        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.ToString().Trim();
        }
        if (!entContact.BloodGroup.IsNull)
        {
            txtBloodGroup.Text = entContact.BloodGroup.ToString().Trim();
        }
        if (!entContact.FacebookID.IsNull)
        {
            txtFacebookID.Text = entContact.FacebookID.ToString().Trim();
        }
        if (!entContact.LinkedINID.IsNull)
        {
            txtLinkedInID.Text = entContact.LinkedINID.ToString().Trim();
        }
        if (balContact.Message != null)
        {
            lblErrMsg.Text = balContact.Message;
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }
    }
    #endregion Fill Controls

}