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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEditPage : System.Web.UI.Page
{
    #region Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblMode.Text = "Edit Contact Category";
                btnAdd.Text = "Edit";
                fillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));

            }
            else
            {
                lblMode.Text = "Add Contact Category";
                btnAdd.Text = "Add";

            }
        }
    }
        #endregion Load Event

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        string strErrorMsg = "";
        if (txtContactCategoryName.Text.Trim() == "")
        {
            strErrorMsg += "- Enter Contry name.<br/>";

        }


        if (strErrorMsg != "")
        {
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
            lblErrMsg.Text = strErrorMsg;
            return;
        }

        #endregion Server Side Validation

        #region Collecting Data
        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        if (txtContactCategoryName.Text.Trim() != "")
        {
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();
        }
        #endregion Collecting Data

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if (Request.QueryString["ContactCategoryID"] != null)
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"].ToString().Trim());
            if (balContactCategory.Update(entContactCategory))
            {
                ClearField();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblErrMsg.Text = balContactCategory.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
        else
        {

            if (balContactCategory.Insert(entContactCategory))
            {
                ClearField();
                lblErrMsg.Text = "Data Inserted Successfully";
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
            else
            {
                lblErrMsg.Text = balContactCategory.Message;
                lblErrMsg.Visible = true;
                lblMsgDiv.Visible = true;
            }
        }
       
    }
    #endregion Button : Save

    #region Clear Field
    private void ClearField()
    {
        txtContactCategoryName.Text = "";
        txtContactCategoryName.Focus();
    }
    #endregion Clear Field

    #region Fill Controls
    private void fillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);

        if(!entContactCategory.ContactCategoryName.IsNull)
        {
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.ToString().Trim();
        }
        if (balContactCategory.Message != null)
        {
            lblErrMsg.Text = balContactCategory.Message;
            lblErrMsg.Visible = true;
            lblMsgDiv.Visible = true;
        }
    }
    #endregion Fll Controls
}