<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true"
    CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">

    <section class="mx-3 rounded p-2 bg-dark">

        <div class="d-flex justify-content-between">
            <h2 class="text-info">State List</h2>
            <asp:HyperLink runat="server" ID="add" NavigateUrl="~/AdminPanel/State/StateAddEditPage.aspx"><span class="btn btn-success">+ Add</span></asp:HyperLink>
        </div>

        <asp:Panel id="lblMsgDiv" runat="server" visible="false" class="w-100 my-2 alert alert-info ">        
            <asp:Label ID="lblErrMsg" runat="server"
                EnableViewState="False" Visible="False"></asp:Label>
        </asp:Panel>

        <div class="text-left">
            <asp:GridView ID="gvState" runat="server" OnRowCommand="gvState_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm"
                                CommandName="deleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" NavigateUrl='<%# "~/AdminPanel/State/StateAddEditPage.aspx?StateID="+ Eval("StateID").ToString().Trim() %>'
                                Text="Edit" CssClass="btn btn-info btn-sm"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="StateCode" HeaderText="State Code" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />

                </Columns>
            </asp:GridView>
        </div>

    </section>

</asp:Content>

