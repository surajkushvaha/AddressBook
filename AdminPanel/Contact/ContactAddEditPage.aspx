<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="ContactAddEditPage.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <section class="mx-3 rounded p-2 bg-dark">
        <div class="mb-3">

            <h2 class="text-info">
                <asp:HyperLink ID="hlBackBtn" runat="server" NavigateUrl="~/AdminPanel/Contact/ContactList.aspx"
                    CssClass="px-2">
                    <asp:Image runat="server" Width="35" ID="imgBackBtn" ImageUrl="~/Content/Images/back-button.png" />
                </asp:HyperLink>
                <asp:Label runat="server" ID="lblMode"></asp:Label>

            </h2>
        </div>


        <asp:Panel id="lblMsgDiv" runat="server" visible="false" class="w-100 my-2 alert alert-info ">        
          
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </asp:Panel>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblCountryName" runat="server" Text="Country Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblState" runat="server" Text="State Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblCity" runat="server" Text="City Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblContactCategory" runat="server" Text="Contact Category Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlContactCategory" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblContactName" runat="server" Text="Contact Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblContactNo" runat="server" Text="Contact No" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblWhatsappNo" runat="server" Text="Whatsapp No" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtWhatsappNo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>


        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtBirthDate"  CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblEmail" runat="server" Text="Email ID" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" type="email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblAge" runat="server" Text="Age" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtAge" type="number" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtAddress" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtBloodGroup" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblFacebookID" runat="server" Text="Facebook ID" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtFacebookID" type="url" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblLinkedInID" runat="server" Text="LinkedIn ID" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLinkedInID" type="url" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row p-2 my-4 justify-content-center">

            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-info" OnClick="btnAdd_Click" />
        </div>
    </section>
</asp:Content>

