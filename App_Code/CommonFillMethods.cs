using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace AddressBook
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void fillDropDownCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectAll();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City"));
        }

        public static void fillDropDownState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectAll();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State"));

        }

        public static void fillDropDownCuntry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectAll();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Country"));

        }

        public static void fillDropDownContactCategory(DropDownList ddl)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddl.DataSource = balContactCategory.SelectAll();
            ddl.DataValueField = "ContactCategoryID";
            ddl.DataTextField = "ContactCategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Contact Category"));

        }
    }
}