<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MantenerEstado._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>

    <script src="script/jquery-1.5.2.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        $(function() {

            $('#<%=gvOrders.ClientID %> img').click(function() {

                var img = $(this)
                var orderid = $(this).attr('orderid');

                var tr = $('#<%=gvOrders.ClientID %> tr[orderid =' + orderid + ']')
                tr.toggle();

                if(tr.is(':visible'))
                    img.attr('src', 'images/minus.gif');
                else
                    img.attr('src', 'images/plus.gif');

            });

        });
    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <p>
    <asp:TextBox ID="txtCustomrId" runat="server"></asp:TextBox>
    <asp:Button ID="serach" runat="server" Text="Ordenes del Cliente" 
        onclick="serach_Click" />
    </p>
    <div>
        <asp:GridView ID="gvOrders" runat="server" CellPadding="3" ForeColor="Black" 
            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  DataKeyNames="OrderId"
            onrowdatabound="gvProducts_RowDataBound" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            onpageindexchanging="gvOrders_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" src="images/plus.gif" orderid="<%# Eval("OrderId") %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="OrderId" HeaderText="Id" />
                <asp:BoundField DataField="OrderDate" HeaderText="Fecha Orden"  DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="RequiredDate" HeaderText="Fecha Requerimiento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="ShippedDate" HeaderText="Fecha Envio" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="ShipVia" HeaderText="Envio Por" />
                <asp:BoundField DataField="ShipName" HeaderText="Envio Nombre" />
                
                 <asp:TemplateField>
                    <ItemTemplate>
                        <tr style="display:none;" orderid="<%# Eval("OrderId") %>">
                            <td colspan="100%">
                                <div style="position:relative;left:25px;">
                                    <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                        CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="ProductId">
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Producto">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" 
                                                        Text='<%# Bind("Product.ProductName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" 
                                                        Text='<%# Bind("Product.ProductName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitPrice" HeaderText="Precio Unitario"  />
                                            <asp:BoundField DataField="Quantity" HeaderText="Cantidad"  />
                                            <asp:BoundField DataField="Discount" HeaderText="Descuento"  />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
