<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <section class="mx-3 rounded p-2 bg-dark">

        <div class="d-flex justify-content-between">
            <h2 class="text-info">Contact List</h2>
            <asp:HyperLink runat="server" ID="add" NavigateUrl="~/AdminPanel/Contact/ContactAddEditPage.aspx"><span class="btn btn-success">+ Add</span></asp:HyperLink>

        </div>
         <div id="lblMsgDiv" runat="server" visible="false" class="w-100 my-2 alert alert-danger ">
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </div>
        <div class="text-left">

            <asp:GridView ID="gvContact" runat="server" SkinID="resTable" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm"
                                CommandName="deleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEditPage.aspx?ContactID="+ Eval("ContactID").ToString().Trim() %>'
                                Text="Edit" CssClass="btn btn-info btn-sm"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />
                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                    <asp:BoundField DataField="WhatsappNo" HeaderText="Whatsapp No" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Birthdate" />
                    <asp:BoundField DataField="Email" HeaderText="Email ID" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                    <asp:BoundField DataField="FacebookID" HeaderText="Facebook ID" />
                    <asp:BoundField DataField="LinkedINID" HeaderText="Linkedin ID" />
                </Columns>
            </asp:GridView>
        </div>

    </section>
</asp:Content>

