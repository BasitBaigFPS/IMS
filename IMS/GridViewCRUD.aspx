<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewCRUD.aspx.cs" Inherits="IMS.GridViewCRUD" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>GridView Crud (Select Insert Edit Update Delete) Operations using Single Stored Procedure in ASP.Net</title>
    <style type="text/css">
        .GridviewDiv {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="GridviewDiv">
            <asp:GridView runat="server" ID="gvDetails" ShowFooter="true" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" DataKeyNames="productid,productname" OnPageIndexChanging="gvDetails_PageIndexChanging" OnRowCancelingEdit="gvDetails_RowCancelingEdit"
                OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating" OnRowDeleting="gvDetails_RowDeleting" OnRowCommand="gvDetails_RowCommand">
                <HeaderStyle CssClass="headerstyle" />
                <Columns>
                    <asp:BoundField DataField="productid" HeaderText="Product Id" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label ID="lblProductname" runat="server" Text='<%# Eval("productname")%>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductname" runat="server" Text='<%# Eval("productname")%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtpname" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductprice" runat="server" Text='<%# Eval("price")%>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtprice" runat="server" />
                            <asp:Button ID="btnAdd" CommandName="AddNew" runat="server" Text="Add" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblresult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
