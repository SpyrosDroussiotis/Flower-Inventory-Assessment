<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="Flower_Inventory_Assessment.WebForm3" %>

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
   
      .Search{
      width:20%; 
      height:30px;
      border-radius: 10px; 
      padding: 8px;
      margin-left:30px;
      margin-bottom:20px;
      vertical-align:middle;
  }
      .SearchBtn{
          width:70px;
          height:50px;
          border-radius: 10px; 
          padding: 8px;
          margin-left:-50px;
          margin-bottom:20px;
          vertical-align:middle;
          background-color:green;
          cursor:pointer;
          border-bottom-left-radius:0px
      }
      .SearchBtn:hover{
               background-color: #45a049;
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
 .GridBtn{
     background-color:green;
     cursor:pointer;
     font-family:Century Gothic;
     font-size:15px;
     width:70px; 
     height:50px; 
     height:50px; 
     border-radius:10px;
     cursor:pointer;
}
.GridBtn:hover{
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
    <asp:TextBox id="SearchTxt" CssClass="Search" type="text" placeholder="Search..." runat="server" ></asp:TextBox><asp:Button ID="SearchBtn" runat="server" CssClass="SearchBtn" Text="Search" Onclick="SearchByName"/>
       <asp:DropDownList ID="Filters" runat="server" CssClass="Sort" AutoPostBack="true" OnSelectedIndexChanged="Filters_SelectedIndexChanged">
          <asp:ListItem Text="Sort" Value="" Disable="True" Selected="True" />
          <asp:ListItem Text="A-Z" Value="ASC" Onclick="NameAsc" />
          <asp:ListItem Text="Z-A" Value="DESC" Onclick="NameDesc"/>
          <asp:ListItem Text="€-€€" Value="ASCPrice" Onclick="PriceAsc"/>
          <asp:ListItem Text="€€-€" Value="DESCPrice" Onclick="PriceDesc"/>
       </asp:DropDownList>
     </div>
       <asp:Button ID="AddCategory" CssClass="AddBtn" runat="server" Text="Add Flower" OnClick="AddNewFlower" />
       <asp:Button ID="BacktoHomepage" CssClass="AddBtn" runat="server" Text="Home" OnClick="GoBack" />
</div>
         <div style="text-align:left; margin-left:30px; font-family:'Century Gothic';">
     <asp:GridView ID="FlowerData" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" RowStyle-Height="70px" 
        onRowCommand="FlowerData_RowCommand" DataKeyNames="FlowerID">
         <HeaderStyle Forecolor="Green" Font-Names="Century Gothic" HorizontalAlign="Left"/>
      <Columns>
         <asp:BoundField runat="server" DataField="FlowerID" HeaderText="No" >
             <ItemStyle Width="7.5%"/>
             <HeaderStyle Width="7.55%"/>
             </asp:Boundfield >
         <asp:BoundField runat="server" DataField="Name" HeaderText="Flower Name" >
              <ItemStyle Width="25%"/>
             <HeaderStyle Width="25%"/>
             </asp:Boundfield >
         <asp:BoundField runat="server" DataField="Color" HeaderText="Color" >
              <ItemStyle Width="25%"/>
             <HeaderStyle Width="25%"/>
             </asp:Boundfield >
           <asp:BoundField runat="server" DataField="Price" HeaderText="Price" >
      <ItemStyle Width="25%"/>
     <HeaderStyle Width="25%"/>
     </asp:Boundfield >
          <asp:TemplateField>
              <ItemTemplate>
          <asp:Button ID="EditFlowerBtn" runat="server" CssClass="GridBtn" Text="Edit" CommandName="EditFlower" CommandArgument='<%# Container.DataItemIndex %>' ButtonType="Button"/>
          <asp:Button ID="DeleteFlowerBtn"  runat="server" CssClass="GridBtn" Text="Delete" CommandName="DeleteFlower" CommandArgument='<%# Container.DataItemIndex %>' ButtonType="Button"/>
          </ItemTemplate>
          </asp:TemplateField>
     </Columns>
         </asp:GridView>
 </div>
    </form>
</body>
</html>
