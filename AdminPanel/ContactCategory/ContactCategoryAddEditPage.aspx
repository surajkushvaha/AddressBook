<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="ContactCategoryAddEditPage.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <section class="mx-3 rounded p-2 bg-dark">
        <div class="mb-3">

            <h2 class="text-info">
                <asp:HyperLink ID="hlBackBtn" runat="server" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryList.aspx"
                    CssClass="px-2">
                    <asp:Image runat="server" Width="35" ID="imgBackBtn" ImageUrl="~/Content/Images/back-button.png" />
                </asp:HyperLink>
                <asp:Label runat="server" ID="lblMode"></asp:Label>

            </h2>
        </div>
        <div id="lblMsgDiv" runat="server" visible="false" class="w-100 my-2 alert alert-info ">
            <asp:Label ID="lblContactCategoryMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </div>

        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblContactCategoryName" runat="server" Text="Contact Category Name"
                    CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row p-2 my-4 justify-content-center">

            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-info"
                OnClick="btnAdd_Click" />
        </div>
    </section>
</asp:Content>

