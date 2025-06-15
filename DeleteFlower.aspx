<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteFlower.aspx.cs" Inherits="Flower_Inventory_Assessment.DeleteFlower" %>

<!DOCTYPE html>
<style>   
    .Title{
        font-family:'Century Gothic'; 
        text-align:left; 
        font-size:70px; 
        color:green;
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
.DeleteBtn{
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
.DeleteBtn:hover{
    background-color: #45a049;
}
.Warning{
    color:red;
    font-size:13px;
    font-family:'Century Gothic';
    margin-left:30px;
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
            <asp:Label ID="LlbDeleteFlowerName" runat="server" Text="Flower Name: "></asp:Label>
            <asp:TextBox id="DeleteFlowerNameTxt"  CssClass="Name" ReadOnly="true" runat="server" ></asp:TextBox>
       </div>
        <div>
     <asp:Label ID="Color" runat="server" Text="Color: "></asp:Label>
     <asp:TextBox id="ColorTxt"  CssClass="Box" ReadOnly="true" runat="server" ></asp:TextBox>
</div>
             <div>
     <asp:Label ID="Price" runat="server" Text="Price: "></asp:Label>
     <asp:TextBox ID="PriceText"  CssClass="Box" ReadOnly="true" runat="server" ></asp:TextBox>
</div>
            </div>
        <div style="margin-top:20px; margin-bottom:5px;">
<asp:label ID="Warning" runat="server" CssClass="Warning" Text="NOTE: Once you delete this it cannot be undone!"></asp:label>
    </div>
         <div style="margin-top:30px;">
            <asp:Button ID="Goback" CssClass="DeleteBtn" runat="server" Text="Back" OnClick="Back" />
            <asp:Button ID="DelFlowerBtn" CssClass="DeleteBtn" runat="server" Text="Delete Flower" OnClick="DeleteCategoryBtn" />
             
        </div>
    </form>
</body>
</html>
