<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Flower_Inventory_Assessment.WebForm2" %>

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
     .Name{
         width:250px; 
         height:35px; 
         border-radius: 10px; 
         padding: 8px; 
         vertical-align:central;
         margin-left:45px;
     }
     .Description{
         width:500px; 
         height:80px; 
         border-radius: 10px;  
         margin-top:10px;
         margin-left:10px;
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
            <h1 style="font-family:'Century Gothic'; text-align:left; font-size:70px; color:green">New Flower Category</h1>
            <hr CssClass="Line" />
        </div>
        <div style="margin-left:30px;">
        <div>
            <asp:Label ID="LlbAddCatName" runat="server" Text="Category Name: "></asp:Label>
            <asp:TextBox id="AddCatNameTxt"  CssClass="Name" type="text" runat="server" ></asp:TextBox>
       </div>
       <div style=" display:flex; align-items:center;">
           <asp:Label ID="LlbAddCatDescription" runat="server" Text="Category Description: "></asp:Label>
       <asp:TextBox runat="server" id="AddCatDescription" CssClass="Description" type="text"  TextMode="MultiLine" ></asp:TextBox>
       </div>
            </div>
        <div style="margin-top:30px;">
            <asp:Button ID="Goback" CssClass="AddBtn" runat="server" Text="Back" OnClick="Back" />
            <asp:Button ID="AddCategory" CssClass="AddBtn" runat="server" Text="Add Category" OnClick="AddNewCategory" />
            <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>

             
        </div>
    </form>
</body>
</html>
