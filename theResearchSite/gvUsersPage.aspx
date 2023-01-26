<%@ Page Title="" Language="C#" MasterPageFile="~/TheResearchMasterPage.Master" AutoEventWireup="true" CodeBehind="gvUsersPage.aspx.cs" Inherits="theResearchSite.gvUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="GeneralCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <asp:GridView ID="GVusers" CssClass="grid-users" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowDeleting="GVusers_RowDeleting" OnRowEditing="GVusers_RowEditing" OnRowDataBound="GVusers_RowDataBound"
        OnRowCancelingEdit="GVusers_RowCancelingEdit" OnRowCommand="GVusers_RowCommand" AllowSorting="true"
        OnSorting="gvUsers_Sorting" ShowFooter="true" OnRowUpdating="GVusers_RowUpdating"
        >
        <Columns>
            <asp:TemplateField HeaderText="מזהה משתמש" InsertVisible="False" SortExpression="Id">
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("IdUser") %>' ID="lIdUser"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("IdUser") %>' ID="Label1"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="שם משתמש" SortExpression="userName">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("userName") %>' ID="txbUserName"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("userName") %>' ID="lUserName"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txbUserNameFooter"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="שם " SortExpression="name">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("name") %>' ID="txbName"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("name") %>' ID="lName"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txbNameFooter"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="אימייל" SortExpression="email">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("email") %>' ID="txbEmail"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("email") %>' ID="lEmail"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txbEmailFooter"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ססמה" SortExpression="password">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("password") %>' ID="txbPassword"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("password") %>' ID="lPassword"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txbPasswordFooter"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="רמת הרשאה" SortExpression="name">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlAuthsEdit" runat="server"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("authLevel.name") %>' ID="lAuthName"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlAuth" runat="server"></asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="מחיקה" CommandName="Delete" CausesValidation="False" ID="LinkButton71"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton runat="server" Text="עדכון" CommandName="Update" CausesValidation="True" ID="LinkButton1"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" Text="ביטול" CommandName="Cancel" CausesValidation="False" ID="LinkButton2"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="עריכה" CommandName="Edit" CausesValidation="False" ID="LinkButton2"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btInsert" CommandName="insert" runat="server" Text="הוספה" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
