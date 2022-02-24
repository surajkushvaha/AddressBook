<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEditPage.aspx.cs" Inherits="AdminPanel_City_CityAddEditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
     <section class="mx-3 rounded p-2 bg-dark">
        <div class="mb-3">

            <h2 class="text-info">
                <asp:HyperLink ID="hlBackBtn" runat="server" NavigateUrl="~/AdminPanel/City/CityList.aspx"
                    CssClass="px-2">
                    <asp:Image runat="server" Width="35" ID="imgBackBtn" ImageUrl="~/Content/Images/back-button.png" />
                </asp:HyperLink>
                <asp:Label runat="server" ID="lblMode"></asp:Label>

            </h2>
        </div>
        <div id="lblMsgDiv" runat="server" visible="false" class="w-100 my-2 alert alert-info ">
            <asp:Label ID="lblCityMsg" runat="server" 
             EnableViewState="False" Visible="False"></asp:Label>
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </div>
        
         <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblStateName" runat="server" Text="State Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblCityName" runat="server" Text="City Name" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCityName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblSTDCode" runat="server" Text="STD Code" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtSTDCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="row p-2 justify-content-center">
            <div class="col-md-4 align-self-center">
                <asp:Label ID="lblPinCode" runat="server" Text="PIN Code" CssClass="text-light"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPinCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row p-2 my-4 justify-content-center">

            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-info"
                OnClick="btnAdd_Click" />
        </div>
    </section>
</asp:Content>

