<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="Flower_Inventory_Assessment.WebForm3" %>

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
    .Description{
    width:700px; 
    height:80px; 
    background-color:lightgrey;
    border-radius: 10px;  
    margin-top:10px;
    margin-left:10px;
    font-family:'Century Gothic';
}
      .Search{
      width:30%; 
      height:35px;
      border-radius: 10px; 
      padding: 8px;
      margin-left:30px;
      margin-bottom:20px;
      vertical-align:middle;
  }
  .Sort{
       width:5%; 
       height:35px;
       border-radius: 10px; 
       padding: 8px;
       margin-left:30px;
       margin-bottom:10px;
       vertical-align:middle;

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
            <asp:Label ID="CatNameTitletxt" runat="server" CssClass="Title"></asp:Label>
            <br />
                <asp:label runat="server" id="ShowCatDescription" CssClass="Description" TextMode="MultiLine" ></asp:label>       
            <hr CssClass="Line" />
        </div>

           <div style="text-align:left">
       <div>
    <asp:TextBox id="SearchTxt" CssClass="Search" type="text" placeholder="Search..." runat="server" ></asp:TextBox>
       <asp:DropDownList ID="Filters" runat="server" CssClass="Sort" >
          <asp:ListItem Text="Sort" Value="" Disable="True" Selected="True" />
          <asp:ListItem Text="A-Z" Value="ASC" />
          <asp:ListItem Text="Z-A" Value="DESC" />
          <asp:ListItem Text="€-€€" Value="ASC" />
          <asp:ListItem Text="€€-€" Value="DESC" />
       </asp:DropDownList>
     </div>
       <asp:Button ID="AddCategory" CssClass="AddBtn" runat="server" Text="Add Flower" OnClick="AddNewFlower" />
</div>
         <div style="text-align:left">
     <asp:GridView ID="FlowerData" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" RowStyle-Height="70px" OnRowDataBound="FlowerData_RowDataBound" 
         onRowCommand="FlowerData_RowCommand" DataKeyNames="FlowerID">
         <HeaderStyle Forecolor="Green" Font-Names="Century Gothic" HorizontalAlign="Left"/>
      <Columns>
         <asp:BoundField runat="server" DataField="FlowerID" HeaderText="No" >
             <ItemStyle Width="5%"/>
             <HeaderStyle Width="5%"/>
             </asp:Boundfield >
         <asp:BoundField runat="server" DataField="Name" HeaderText="Flower Name" >
              <ItemStyle Width="20%"/>
             <HeaderStyle Width="20%"/>
             </asp:Boundfield >
         <asp:BoundField runat="server" DataField="Color" HeaderText="Color" >
              <ItemStyle Width="20%"/>
             <HeaderStyle Width="20%"/>
             </asp:Boundfield >
           <asp:BoundField runat="server" DataField="Price" HeaderText="Price" >
      <ItemStyle Width="20%"/>
     <HeaderStyle Width="20%"/>
     </asp:Boundfield >
          <asp:TemplateField>
              <ItemTemplate>
          <asp:Button ID="EditCatBtn" runat="server" CssClass="GridBtn" Text="Edit" CommandName="EditCategory" CommandArgument='<%# Container.DataItemIndex %>' ButtonType="Button"/>
          <asp:Button ID="DeleteCatBtn"  runat="server" CssClass="GridBtn" Text="Delete" CommandName="DeleteCategory" CommandArgument='<%# Container.DataItemIndex %>' ButtonType="Button"/>
          </ItemTemplate>
          </asp:TemplateField>
     </Columns>
         </asp:GridView>
 </div>
    </form>
</body>
</html>
