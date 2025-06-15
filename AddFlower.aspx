<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFlower.aspx.cs" Inherits="Flower_Inventory_Assessment.AddFlower" %>

<!DOCTYPE html>
<style>
    .Title{
        font-family:'Century Gothic'; 
        text-align:left; 
        font-size:70px; 
        color:green
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
         margin-left:126px;
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
     
       .AddBtn{
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
       .AddBtn:hover{
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
            <asp:label ID="AddFlowerTxt" runat="server" CssClass="Title" Text="Add New Flower" ></asp:label>
            <hr CssClass="Line" />
        </div>
        <div style="margin-left:30px;">
        <div>
            <asp:Label ID="LlbAddFlowerName" runat="server" Text="Flower Name: "></asp:Label>
            <asp:TextBox id="AddFlowerNameTxt"  CssClass="Name" type="text" runat="server" ></asp:TextBox>
       </div>
       <div >
           <asp:Label ID="LlbAddFlowerColor" runat="server" Text="Color "></asp:Label>
       <asp:TextBox runat="server" id="AddFlowerColor" CssClass="Box" type="text"  ></asp:TextBox>
       </div>
        <div >
        <asp:Label ID="LblAddFlowerPrice" runat="server" Text="Price "></asp:Label>
        <asp:TextBox runat="server" id="AddFlowerPrice" CssClass="Box" type="text"  ></asp:TextBox>
        </div>
            </div>
        <div style="margin-top:30px;">
            <asp:Button ID="Goback" CssClass="AddBtn" runat="server" Text="Back" OnClick="Back" />
            <asp:Button ID="AddFlowerBtn" CssClass="AddBtn" runat="server" Text="Add Flower" OnClick="AddNewFlower" />
             
        </div>
    </form>
</body>
</html>
