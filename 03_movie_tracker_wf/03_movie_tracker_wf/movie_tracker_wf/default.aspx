<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="movie_tracker_wf._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Tracker</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Movie Tracker</h1>

        <div class="container">
            <asp:Label ID="Label1" runat="server" Text="Title" CssClass="column1"></asp:Label>
            <asp:TextBox ID="titleTextBox" runat="server" CssClass="column2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Title is required." ControlToValidate="titleTextBox" CssClass="column3" SetFocusOnError="True" Text="Required."></asp:RequiredFieldValidator>

            <asp:Label ID="Label2" runat="server" Text="Date Seen" CssClass="column1"></asp:Label>
            <asp:TextBox ID="dateTextBox" runat="server" TextMode="Date" CssClass="column2"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredValidator2"
                runat="server"
                ErrorMessage="Date is required."
                ControlToValidate="dateTextBox"
                CssClass="column3"
                SetFocusOnError="true"
                Text="<img src='images/error.png' alt='Date is requried.' title='Required.' />">
            </asp:RequiredFieldValidator>

            <asp:Label ID="Label3" runat="server" Text="Genre" CssClass="column1"></asp:Label>
            <asp:DropDownList
                ID="genreDropDownList"
                runat="server"
                CssClass="column2"
                DataSourceID="genreSqlDataSource"
                DataTextField="genre_description"
                DataValueField="genre_id">
            </asp:DropDownList>
            <asp:SqlDataSource
                runat="server"
                ID="genreSqlDataSource"
                ConnectionString='<%$ ConnectionStrings:movie_trackerConnectionString %>'
                SelectCommand="SELECT [genre_id], [genre_description] FROM [genres]">
            </asp:SqlDataSource>

            <asp:Label ID="Label4" runat="server" Text="Rating" CssClass="column1"></asp:Label>
            <asp:TextBox ID="ratingTextBox" runat="server" placeholder="1 to 10" CssClass="column2"></asp:TextBox>
            <asp:RangeValidator
                ID="RangeValidator1"
                runat="server"
                ErrorMessage="Rating must be from 1 to 10."
                ControlToValidate="ratingTextBox"
                MaximumValue="10"
                MinimumValue="1"
                SetFocusOnError="True"
                Type="Integer"
                Text="Must be from 1 to 10."
                CssClass="column3"
                Display="Dynamic">
            </asp:RangeValidator>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4"
                runat="server"
                ErrorMessage="Rating is required."
                ControlToValidate="ratingTextBox"
                CssClass="column3"
                SetFocusOnError="true"
                Text="Required.">
            </asp:RequiredFieldValidator>

            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" CssClass="column1" />
            <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="column2" CausesValidation="false" />
        </div>

        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Literal ID="outputLiteral" runat="server"></asp:Literal>
    </form>
</body>
</html>
