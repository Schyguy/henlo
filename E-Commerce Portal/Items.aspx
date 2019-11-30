<%@ Page Title="Items" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="E_Commerce_Portal.Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<head>
<style>
/*image styling of the gazebo images on the items page*/
img {
    width: 225px;
    height: 150px;
}
.h3 {
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
p {
    color: black;
}
hr {
    border-bottom: 1px solid #D3D3D3;
}
</style>
</head>

  <h3 class = "h3">ITEMS</h3>

  <asp:ListView ID="gazeboList" runat="server" 
      DataKeyNames="GazeboID" GroupItemCount="3"
      ItemType="E_Commerce_Portal.Models.Gazebo" SelectMethod="GetGazebos">
    <EmptyDataTemplate>
        <table>
            <tr>
                <td>No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <EmptyItemTemplate>
        <td/>
    </EmptyItemTemplate>
    <GroupTemplate>
        <tr id="itemPlaceholderContainer" runat="server">
            <td id="itemPlaceholder" runat="server"></td>
        </tr>
    </GroupTemplate>
    <ItemTemplate>
        <td runat="server">
            <table align = "center" style = "border: 2px solid #D3D3D3;">
                <tr>
                    <td>
                        <img src="/Images/<%#Item.ImagePath%>" width="225" height="150" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <span>
                            <center><%#:Item.GazeboName%></center>
                        </span>
                        <span>
                            <center>Price: <%#:String.Format("{0:c}", Item.UnitPrice)%></center>
                        </span>
                        <br />
                        <a href="/AddToCart.aspx?gazeboID=<%#:Item.GazeboID %>">               
                            <span class="ItemsItem">
                                <b>Add To Cart<b>
                            </span>           
                        </a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </p>
        </td>
    </ItemTemplate>
    <LayoutTemplate>
        <table style="width:100%"; align ="center">
            <tbody>
                    <tr>
                        <td>
                            <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                <tr id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr></tr>
            </tbody>
         </table>
    </LayoutTemplate>
    </asp:ListView>
</asp:Content>
