﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master"
AutoEventWireup="true" CodeFile="CityList.aspx.cs"
Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
  <section class="mx-3 rounded p-2 bg-dark">
    <div class="d-flex justify-content-between">
      <h2 class="text-info">City List</h2>
      <asp:HyperLink
        runat="server"
        ID="add"
        NavigateUrl="~/AdminPanel/City/CityAddEditPage.aspx"
        ><span class="btn btn-success">+ Add</span></asp:HyperLink
      >
    </div>
    <div
      id="lblMsgDiv"
      runat="server"
      visible="false"
      class="w-100 my-2 alert alert-danger"
    >
      <asp:Label
        ID="lblErrMsg"
        runat="server"
        EnableViewState="False"
        Visible="False"
      ></asp:Label>
    </div>
    <div class="text-left">
      <asp:GridView ID="gvCity" runat="server" OnRowCommand="gvCity_RowCommand">
        <Columns>
          <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
              <asp:Button
                runat="server"
                ID="btnDelete"
                Text="Delete"
                CssClass="btn btn-danger btn-sm"
                CommandName="deleteRecord"
                CommandArgument='<%# Eval("CityID").ToString() %>'
              />
            </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
              <asp:HyperLink
                runat="server"
                ID="btnEdit"
                NavigateUrl='<%# "~/AdminPanel/City/CityAddEditPage.aspx?CityID="+ Eval("CityID").ToString().Trim() %>'
                Text="Edit"
                CssClass="btn btn-info btn-sm"
              ></asp:HyperLink>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="StateName" HeaderText="City Name" />
          <asp:BoundField DataField="CityName" HeaderText="City Name" />
          <asp:BoundField DataField="PinCode" HeaderText="Pin Code" />
          <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
        </Columns>
      </asp:GridView>
    </div>
  </section>
</asp:Content>
