<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Northwind._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Northwind Portal</h1>
        <p class="lead">The portal allows Northwind employees to maintain the company database.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Northwind Traders</h2>
            <p>
                The Northwind database is a fictional database that has been used as an example since the 1990s.</p>
            <p>
                <a class="btn btn-default" href="http://www.northwindtraders.com">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Other fictional companies</h2>
            <p>
                Microsoft uses a variety of fictional companies in the documentation and training material for its products. Microsoft documentation and learning materials often contain fictional scenarios and descriptions of how their products can be deployed and used in these scenarios.
            </p>
            <p>
                <a class="btn btn-default" href="https://en.wikipedia.org/wiki/Category:Fictional_companies">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>The ultimate answer</h2>
            <p>
                The answer to the ultimate question of life, the universe and everything is 42.
            </p>
            <p>
                <a class="btn btn-default" href="https://en.wikipedia.org/wiki/42_(number)">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
