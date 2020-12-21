<%@ Page Title="Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="northwind.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Customer:
        <asp:DropDownList
            ID="customerDropDownList"
            runat="server"
            DataSourceID="customerSqlDataSource"
            DataTextField="CompanyName"
            DataValueField="CustomerID"
            AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource
            runat="server"
            ID="customerSqlDataSource"
            ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>'
            SelectCommand="SELECT [CustomerID], [CompanyName] FROM [Customers]">
        </asp:SqlDataSource>
    </p>
    <asp:GridView ID="ordersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="ordersSqlDataSource" CellPadding="4" CssClass="table-condensed" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" InsertVisible="False" SortExpression="OrderID"></asp:BoundField>
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia"></asp:BoundField>
            <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight"></asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource
        runat="server"
        ID="ordersSqlDataSource"
        ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>'
        SelectCommand="SELECT [OrderID], [OrderDate], [ShippedDate], [ShipVia], [Freight] FROM [Orders] WHERE ([CustomerID] = @CustomerID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="customerDropDownList" PropertyName="SelectedValue" Name="CustomerID" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource
        ID="orderSqlDataSource"
        runat="server"
        ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString1 %>'
        DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = @OrderID"
        InsertCommand="INSERT INTO [Orders] ([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]) VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)"
        SelectCommand="SELECT * FROM [Orders] WHERE ([OrderID] = @OrderID)"
        UpdateCommand="UPDATE [Orders] SET [CustomerID] = @CustomerID, [EmployeeID] = @EmployeeID, [OrderDate] = @OrderDate, [RequiredDate] = @RequiredDate, [ShippedDate] = @ShippedDate, [ShipVia] = @ShipVia, [Freight] = @Freight, [ShipName] = @ShipName, [ShipAddress] = @ShipAddress, [ShipCity] = @ShipCity, [ShipRegion] = @ShipRegion, [ShipPostalCode] = @ShipPostalCode, [ShipCountry] = @ShipCountry WHERE [OrderID] = @OrderID">
        <DeleteParameters>
            <asp:Parameter Name="OrderID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
            <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ordersGridView" PropertyName="SelectedValue" Name="OrderID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
            <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
            <asp:Parameter Name="OrderID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:DetailsView ID="orderDetailsView" runat="server" Height="50px" CellPadding="4" CssClass="table-condensed" DataSourceID="orderSqlDataSource" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
</asp:Content>