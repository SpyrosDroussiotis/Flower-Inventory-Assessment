<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFlower.aspx.cs" Inherits="Flower_Inventory_Assessment.EditFlower" %>

<!DOCTYPE html>
<style>   
        .Title{
    font-family:'Century Gothic'; 
    text-align:left; 
    font-size:70px; 
    color:green;
    font-weight:bold;
}
      .Line{
      color:darkgray; 
      margin-bottom:20px; 
      margin-top:15px; 
      width:90%; 
      margin-left:0px; 
      margin-right:auto; 
      display:block;
  }
        .Box{
         width:250px; 
         height:35px; 
         border-radius: 10px; 
         padding: 8px; 
         vertical-align:central;
         margin-left:100px;
         margin-top:15px;
     }
     .Name{
         width:250px; 
height:35px; 
border-radius: 10px; 
padding: 8px; 
vertical-align:central;
margin-left:45px;
margin-top:15px;
     }
.EditBtn{
width:150px; 
height:50px; 
border-radius: 10px; 
padding: 8px; 
background-color:green;
cursor:pointer;
margin-bottom:20px;
margin-left:30px;
vertical-align:middle;
font-size:15px;
font-family:Century Gothic;
}
.EditBtn:hover{
    background-color: #45a049;
}

</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightgrey;">
   
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="FlowerNameTitletxt" runat="server" CssClass="Title"></asp:Label>
            <hr CssClass="Line" />
        </div>
        <div style="margin-left:30px;">
        <div>
            <asp:Label ID="LlbEditFlowerName" runat="server" Text="Flower Name: "></asp:Label>
            <asp:TextBox id="EditFlowerNameTxt"  CssClass="Name" type="text" runat="server" ></asp:TextBox>
       </div>
        <div>
     <asp:Label ID="Color" runat="server" Text="Color: "></asp:Label>
     <asp:TextBox id="ColorTxt"  CssClass="Box" type="text" runat="server" ></asp:TextBox>
</div>
             <div>
     <asp:Label ID="Price" runat="server" Text="Price: "></asp:Label>
     <asp:TextBox ID="PriceTxt"  CssClass="Box" type="text" runat="server" ></asp:TextBox>
</div>
            </div>
         <div style="margin-top:30px;">
            <asp:Button ID="Goback" CssClass="EditBtn" runat="server" Text="Back" OnClick="Back" />
            <asp:Button ID="EditFlowerButton" CssClass="EditBtn" runat="server" Text="Edit Flower" OnClick="EditFlowerBtn" />
            <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>

             
        </div>
    </form>
</body>
</html>
