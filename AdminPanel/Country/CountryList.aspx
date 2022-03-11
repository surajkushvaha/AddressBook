<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <section class="mx-3 rounded p-2 bg-dark">

        <div class="d-flex justify-content-between">
            <h2 class="text-info">Country List</h2>
            <asp:HyperLink runat="server" ID="add" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx"><span class="btn btn-success">+ Add</span></asp:HyperLink>
        </div>

        <asp:Panel ID="lblMsgDiv" runat="server" Visible="false" class="w-100 my-2 alert alert-info ">
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </asp:Panel>
        <div class="text-left">
            <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm"
                                CommandName="deleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID="+ Eval("CountryID").ToString().Trim() %>'
                                Text="Edit" CssClass="btn btn-info btn-sm"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                </Columns>
            </asp:GridView>
        </div>

    </section>
</asp:Content>

