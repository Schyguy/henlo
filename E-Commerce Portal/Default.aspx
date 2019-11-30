<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce_Portal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent"
runat="server">
<head>
<style>
/*Styling sheet for home page, uses CSS grid to add title, images, and text*/
.home { grid-area: header; }
.image { grid-area: image; }
.main { grid-area: main; }
.bottom { grid-area: bottom; }

/*grid layout and styling of areas*/
.grid-container {
  display: grid;
  grid-template-areas:
    'header header header header header header'
    'image image main main main main'
    'bottom bottom bottom bottom bottom bottom';
  grid-gap: 10px;
  background-color: transparent;
  padding: 10px;
  margin-top: 5px;
}
/*home text styling*/
.grid-container > .home {
  background-color: transparent;
  text-align: center;
  color: black;
  padding: 0px;
  margin-bottom: 10px;
  margin-top: -10px;
  padding-bottom: 12px;
  border-bottom: 2px solid #D3D3D3;
  letter-spacing: 3px;
}
/*left image on home page styling*/
.grid-container > .image {
  background-color: transparent;
  text-align: center;
  padding: 0px 20px 0px 0px;
  font-size: 20px;
  margin-left: 5px;
  margin-top: 20px;
  border-right: 2px solid #D3D3D3;
}
/*body text styling*/
.grid-container > .main {
  background-color: transparent;
  text-align: left;
  color: black;
  padding: 3px;
  font-size: 15px;
  margin-left: 20px;
}
/*bottom logo area*/
.grid-container > .bottom {
  background-color: transparent;
  text-align: center;
  color: black;
  padding: 50px 0px;
  font-size: 15px;
  justify-content: center;
}
/*gazebo image on home page styling*/
.gazeboLogo {
    width: 200px;
    height: 250px;
}
/*styling of tool logos in the bottom area*/
.tool1, .tool2, .tool3, .tool4 {
    width: 50px;
    height: 50px;
    margin-right: 10px;
}
/*end of CSS styling*/
</style>
</head>
<body>
<!-- html div classes for grid layout -->
<div class="grid-container">
  <div class="home">
      <h3>HOME</h3>
  </div>
  <div class="image">
      <img src="/Images/GazeboLogo.png" alt="Gazebo Logo" class ="gazeboLogo"/>
  </div>
    <!-- main paragraph -->
  <div class="main">
      <br />
      <h3>Who We Are:</h3>
      <p>We are the Gazebo Guys, the #1 gazebo sellers in CPSC 236! We locally "handcraft" gazebos for your custom needs, any size, color, or material. We guarantee high quality gazebos for every single customer, and a free return policy if you are unsatifisied with your gazebo.</p>
      <br />
      <p>Here at Gazebo Guys, we have worked hard for many years to ensure customer satisfaction on every level. We hope to install beautiful gazebos in any location. If you have any questions, please contact us by visiting our contact page.</p>
  </div>
    <!-- logos in the bottom of the page -->
  <div class="bottom">
      <center>
          <img src="/Images/tool1.png" alt="tool 1" class ="tool1"/>
          <img src="/Images/tool3.png" alt="tool 3" class ="tool3"/>
          <img src="/Images/tool4.png" alt="tool 4" class ="tool4" />
          <img src="/Images/tool2.png" alt="tool 2" class ="tool2"/>
          <br />
          <h5><strong>Gazebos, Made Tough. ®</strong></h5>
      </center>
  </div>
</div>
</body>
</asp:Content>