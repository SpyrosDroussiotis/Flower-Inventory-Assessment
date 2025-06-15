<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCategory.aspx.cs" Inherits="Flower_Inventory_Assessment.DeleteCategory" %>

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
.DelBtn{
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
.DelBtn:hover{
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
     <asp:Label ID="CatNameTitletxt" runat="server" CssClass="Title"></asp:Label>
     <hr CssClass="Line" />
 </div>
         <div style="margin-left:30px;">
 <div>
     <asp:Label ID="LlbDeltCatName" runat="server" Text="Category Name: "></asp:Label>
     <asp:Textbox id="DelCatNameTxt"  CssClass="Name" runat="server"  ReadOnly="true" ></asp:Textbox>
</div>
<div style=" display:flex; align-items:center;">
    <asp:Label ID="LlbDelCatDescription" runat="server" Text="Category Description: "></asp:Label>
<asp:Textbox runat="server" id="DelCatDescription" CssClass="Description" ReadOnly="true" TextMode="MultiLine" ></asp:Textbox>
</div>
     </div>
        <div style="margin-top:20px; margin-bottom:5px;">
        <asp:label ID="Warning" runat="server" CssClass="Warning" Text="NOTE: Once you delete this it cannot be undone!"></asp:label>
            </div>
         <div>
    <asp:Button ID="Goback" CssClass="DelBtn" runat="server" Text="Back" OnClick="Back" />
    <asp:Button ID="DelCat" CssClass="DelBtn" runat="server" Text="Delete Category" OnClick="DelCategoryBtn" />
     
</div>
    </form>
</body>
</html>
