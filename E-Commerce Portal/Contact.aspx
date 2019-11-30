<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="E_Commerce_Portal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <style>
            h3 {
                text-align: center;
                color: black;
                padding: 0px;
                margin-bottom: 20px;
                padding-bottom: 22px;
                margin-top: 25px;
                letter-spacing: 3px;
                border-bottom: 2px solid #D3D3D3;
                border-bottom-width: 2px 250px;
            }
        </style>
    </head>
    <h3>CONTACT</h3>
    <address>
        <strong>Address:</strong>
        <br />
        1 Morrow Way<br />
        Slippery Rock, PA 16057<br />
    </address>
    <!-- email address for support -->
    <address>
        <strong>Support:</strong> 
        <br />
        Joseph: <a href="jmp1045@sru.edu">jmp1045@sru.edu</a><br />
        Ben: <a href="bts1009@sru.edu">bts1009@sru.edu</a><br />
        Adam: <a href="ajs1045@sru.edu">ajs1045@sru.edu</a><br />
    </address>
</asp:Content>
