<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="assignment1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="table row">
        <div class="col-md-2">First name</div>
        <div class="col-md-2"><asp:TextBox ID="firstTextBox" runat="server"></asp:TextBox></div>
        <div class="col-md-2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="firstTextBox" SetFocusOnError="True" Text="Required."></asp:RequiredFieldValidator></div>
    </div>
    <div class="table row">
        <div class="col-md-2">Last name</div>
        <div class="col-md-2"><asp:TextBox ID="lastTextBox" runat="server"></asp:TextBox></div>
        <div class="col-md-2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." ControlToValidate="lastTextBox" SetFocusOnError="True" Text="Required."></asp:RequiredFieldValidator></div>
    </div>
    <div class="table row">
        <div class="col-md-2">Division</div>
        <div class="col-md-2">
            <asp:DropDownList ID="divisionDropDownList" runat="server" DataSourceID="divisionSqlDataSource" DataTextField="division_name" DataValueField="division_id"></asp:DropDownList><asp:SqlDataSource runat="server" ID="divisionSqlDataSource" ConnectionString='<%$ ConnectionStrings:HASCConnectionString %>' SelectCommand="SELECT [division_id], [division_name], [teams_made] FROM [divisions]"></asp:SqlDataSource>
        </div>
        <div class="col-md-2"></div>
    </div>
    <div class="table row">
        <div class="col-md-2">Email</div>
        <div class="col-md-2"><asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox></div>
        <div class="col-md-2"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a proper email." ControlToValidate="emailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email name is required." ControlToValidate="emailTextBox" SetFocusOnError="True" Text="Required."></asp:RequiredFieldValidator></div>
    </div>
    <div class="table row">
        <div class="col-md-2">Birth date</div>
        <div class="col-md-2"><asp:TextBox ID="dateTextBox" runat="server" TextMode="Date"></asp:TextBox></div>
        <div class="col-md-2"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Date is required." ControlToValidate="dateTextBox" SetFocusOnError="True" Text="Required."></asp:RequiredFieldValidator></div>
    </div>
    <div class="table row">
        <div class="col-md-2"></div>
        <div class="col-md-2">
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
            <asp:Button ID="cancelButton" runat="server" Text="Cancel" CausesValidation="False" OnClick="cancelButton_Click" />
        </div>
        <div class="col-md-2"></div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <div class="table row">
        <div class="col-md-6">
            <asp:Literal ID="outputLiteral" runat="server"></asp:Literal>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
