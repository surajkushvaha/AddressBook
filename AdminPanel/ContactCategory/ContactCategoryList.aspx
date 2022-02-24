<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <section class="mx-3 rounded p-2 bg-dark">

        <div class="d-flex justify-content-between">
            <h2 class="text-info">Contact Category List</h2>
            <asp:HyperLink runat="server" ID="add" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEditPage.aspx"><span class="btn btn-success">+ Add</span></asp:HyperLink>
        </div>
         <div id="lblMsgDiv" runat="server" visible="false" class="w-100 my-2 alert alert-danger ">
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </div>
        <div class="text-left">
            <asp:GridView ID="gvContactCategory" runat="server" OnRowCommand="gvContactCategory_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm"
                                CommandName="deleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEditPage.aspx?ContactCategoryID="+ Eval("ContactCategoryID").ToString().Trim() %>'
                                Text="Edit" CssClass="btn btn-info btn-sm"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />
                </Columns>
            </asp:GridView>
        </div>

    </section>
</asp:Content>

