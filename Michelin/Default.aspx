<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Michelin._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP MEMBERSHIP</h1>
        <p class="lead">ASP.NET Membership is a website used to manage users and what roles they have access to.</p>
        <p></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Registering</h2>
            <p>
             Users can register using their chorus number and then apply to the "IS" department
                to be given rights to access a variety of web sites needed to perform their task.
            </p>
            <p>
               <%-- <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>--%>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Roles / Access rights</h2>
            <p>
                There a several roles for example "Manager" is necessary to manage users overtime 
                or "HEM" necessary to manage the BCPM database.
            </p>
            <p>
                <%--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>--%>
            </p>
        </div>
        <div class="col-md-4">
            <h2>IS Department</h2>
            <p>
               Please contact the "IS" department using the "IS" help line if you have questions.
                (205) 665-1630
            </p>
            <p>
                <%--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>--%>
            </p>
        </div>
    </div>

</asp:Content>
