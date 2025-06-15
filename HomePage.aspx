<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Flower_Inventory_Assessment.HomePage" %>

<!DOCTYPE html>

 <style>
     .Grid{
         border-collapse:collapse;
         font-family:'Century Gothic';
         font-size:20px;
         margin-left:30px;
         width:65%;
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
     .Line{
         color:darkgray; 
         margin-bottom:20px; 
         margin-top:15px; 
         width:90%; 
         margin-left:0px; 
         margin-right:auto; 
         display:block;
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
   
<body style="background-color:lightgrey">
    <form id="form1" runat="server">
        <div>
          <h1 style="font-family:'Century Gothic'; text-align:left; font-size:70px; color:green" dir="ltr">Flower Categories</h1>
            <hr CssClass="Line" />
        </div>
           <div style="text-align:left">
               <div>
            <asp:TextBox id="SearchTxt" CssClass="Search" type="text" placeholder="Search..." runat="server" ></asp:TextBox>
               <asp:DropDownList ID="Filters" runat="server" CssClass="Sort" >
                  <asp:ListItem Text="Sort" Value="" Disable="True" Selected="True" />
                  <asp:ListItem Text="A-Z" Value="ASC" />
                  <asp:ListItem Text="Z-A" Value="DESC" />
               </asp:DropDownList>
             </div>
               <asp:Button ID="AddCategory" CssClass="AddBtn" runat="server" Text="Add Category" OnClick="AddNewCategory" />
                   
        </div>
        <div style="text-align:left">
            <asp:GridView ID="CategoriesData" runat="server" AutoGenerateColumns="false" CssClass="Grid" GridLines="None" RowStyle-Height="70px" OnRowDataBound="CategoriesData_RowDataBound" 
                onRowCommand="CategoriesData_RowCommand" DataKeyNames="CategoryID">
                <HeaderStyle Forecolor="Green" Font-Names="Century Gothic" HorizontalAlign="Left"/>
             <Columns>
                <asp:BoundField runat="server" DataField="CategoryID" HeaderText="No" >
                    <ItemStyle Width="5%"/>
                    <HeaderStyle Width="5%"/>
                    </asp:Boundfield >
                <asp:BoundField runat="server" DataField="NameOfCategory" HeaderText="Category Name" >
                     <ItemStyle Width="20%"/>
                    <HeaderStyle Width="20%"/>
                    </asp:Boundfield >
                <asp:BoundField runat="server" DataField="Description" HeaderText="Description" >
                     <ItemStyle Width="60%"/>
                    <HeaderStyle Width="60%"/>
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
