<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoView.aspx.cs" Inherits="RemingtonDemo.Web.DemoView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Invoices</title>
    <link href="Styles/jquery-ui.css" rel="stylesheet" />
    <link href="Styles/Demo.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/knockout-3.4.2.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <div id="logo">
                <h1>Apex-Remington Demo</h1>
                <h3>Customer Invoices</h3>
            </div>
            <div id="controls">
                <table id="controlTbl">
                    <thead id="parameter_description">
                        <tr>
                            <td>Due Date Range</td>
                        </tr>
                    </thead>
                    <tbody id="parameters">
                        <tr>
                            <td>
                                <label>Start Due Date:</label>
                                <asp:TextBox ID="TxtStart" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>End Due Date:</label>
                                <asp:TextBox ID="TxtEnd" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                    <tbody id="command_buttons">
                        <tr>
                            <td>
                                <asp:Button ID="BtnRun" runat="server" Text="ASP.NET" OnClick="BtnRun_Click" />
                            </td>
                            <td>
                                <input id="runService" type="button" value="KnockOutJS" />
                            </td>
                            <td>
                                <asp:Button ID="BtnExport" runat="server" Text="Export" OnClick="BtnExport_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <hr />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <div>
            <table id="InvoiceTbl">
                <thead class="headings">
                    <tr>
                        <td>Sold At</td>
                        <td>Sold To</td>
                        <td>Account#</td>
                        <td>Invoice#</td>
                        <td>Customer PO#</td>
                        <td>Order Date</td>
                    </tr>
                </thead>
                <tbody id="details" class="records" data-bind="foreach: invoices">
                    <tr>
                        <td data-bind="text:SoldAt"></td>
                        <td data-bind="text: SoldTo"></td>
                        <td data-bind="text: AccountNumber"></td>
                        <td data-bind="text: InvoiceNumber"></td>
                        <td data-bind="text: CustomerPONumber"></td>
                        <td data-bind="text: OrderDate"></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script src="JS/CustomerInvoice.js"></script>
</body>
</html>
