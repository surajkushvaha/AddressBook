<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <section class="mx-3 rounded p-2 bg-dark">
        <div class="mb-3">

            <h2 class="text-info">
                <asp:HyperLink ID="hlBackBtn" runat="server" NavigateUrl="~/AdminPanel/Country/CountryList.aspx"
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
                <asp:TextBox ID="txtCountryName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblCountryCode" runat="server" Text="Country Code" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCountryCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 my-4 justify-content-center">

            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-info"
                OnClick="btnAdd_Click" />
        </div>
    </section>
</asp:Content>

