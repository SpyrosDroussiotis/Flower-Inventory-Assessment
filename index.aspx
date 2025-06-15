<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Flower_Inventory_Assessment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .LogInbtn{
            width:275px; 
            height:50px; 
            border-radius: 10px; 
            padding: 8px; 
            background-color:green;
            cursor:pointer;
        }
        .LogInbtn:hover{
            background-color: #45a049;
        }
       
        
    </style>
</head>
<body style="background-color:lightgrey">
    <form id="form1" runat="server">
        <div>
            <h1 style="font-family:'Century Gothic'; text-align:center; font-size:70px; color:green" dir="ltr">Flower Inventory</h1>
        </div>
        <div style="margin-top:100px;">
        <p style="font-family:'Century Gothic'; text-align:center; font-size:40px; color:green" dir="ltr">Login</p>
                <div style="text-align:center">
                    <asp:TextBox id="UsernameTxt" style="width:250px; height:35px; border-radius: 10px; padding: 8px;" type="text" placeholder="Username..." runat="server" OnTextChanged="UsernameTxt_TextChanged"></asp:TextBox>
                </div>
                <div style="text-align:center">
                    <asp:TextBox runat="server" id="PasswordTxt" style=" font-family:'Century Gothic'; width:250px; height:35px; border-radius: 10px; padding: 8px; margin-top:10px" type="text" placeholder="Password..." OnTextChanged="PasswordTxt_TextChanged"></asp:TextBox>
                </div>
            <div style="text-align:center"> 
                <p>
                    <asp:Button id="LogInbtn"  runat="server" OnClick="loginbtn_click" class="LogInbtn" type="button" Text="Log In" />
                </p>
            </div>
            


</div>
        
    </form>
   
</body>
</html>
