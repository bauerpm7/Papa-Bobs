<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsMegaChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class ="container">
            <div class ="page-header">
                <h1>Welcome to Papa Bob's!</h1>
                <h2>Pizza To Code By</h2>
            </div>
        </div>
        <div class ="container">
            <div class="form-group">
                <label>Size:</label>
                <asp:DropDownList ID="pizzaSizeDropDownMenu" runat="server" AutoPostBack="true" OnSelectedIndexChanged="recalculateTotal" CssClass="form-control">
                    <asp:ListItem Text="Choose one..." Value="" Selected="True"/>
                    <asp:ListItem Text="Small (12 inch - $12)" Value="Small" />
                    <asp:ListItem Text="Medium (14 inch - $14)" Value="Medium" />
                    <asp:ListItem Text="Large (16 inch - $16)" Value="Large" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Crust:</label>
                <asp:DropDownList ID="pizzaCrustDropDownMenu" runat="server" AutoPostBack="true" OnSelectedIndexChanged="recalculateTotal" CssClass="form-control">
                    <asp:ListItem Text="Choose one..." Value="" Selected="True"/>
                    <asp:ListItem Text="Regular Crust" Value="Regular" />
                    <asp:ListItem Text="Thin Crust" Value="Thin" />
                    <asp:ListItem Text="Thick Crust (+ $2)" Value="Thick" />
                </asp:DropDownList>
            </div>
            <div class="checkbox"><label><asp:CheckBox ID="pepperoniCheckBox" AutoPostBack="true" runat="server" OnCheckedChanged="recalculateTotal"></asp:CheckBox> Pepperoni</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="sausageCheckBox" AutoPostBack="true" runat="server" OnCheckedChanged="recalculateTotal"></asp:CheckBox> Sausage</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="onionCheckBox" AutoPostBack="true" runat="server" OnCheckedChanged="recalculateTotal"></asp:CheckBox> Onion</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="greenPepperCheckBox" AutoPostBack="true" runat="server" OnCheckedChanged="recalculateTotal"></asp:CheckBox> Green Peppers</label></div>
        </div>
        <div class ="container">
            <h2>Deliver To:</h2>
            <div class="form-group">
                <label>Name: </label>
                <asp:TextBox ID="nameTextBox" runat="server"  CssClass="form-control"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <label>Address: </label>
                <asp:TextBox ID="addressTextBox" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Zip Code: </label>
                <asp:TextBox ID="zipCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Phone: </label>
                <asp:TextBox ID="phoneNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="container">
            <h3>Payment:</h3>
            <div class="radio"><label><asp:RadioButton ID="cashRadioButton" runat="server" GroupName="paymentGroup"></asp:RadioButton>Cash</label></div>
            <div class="radio"><label><asp:RadioButton ID="creditRadioButton" runat="server" GroupName="paymentGroup"></asp:RadioButton>Credit</label></div>
        </div>
        <div class="container">
            <asp:Button ID="orderButton" runat="server" Text="Order" CssClass="btn btn-lg btn-primary" OnClick="orderButton_Click"/>
        </div>
        <div class="container">
            <p>&nbsp;</p>
            <asp:Label ID="validationLabel" style="color: red; font-weight: bold; font-size: 16px" runat="server"></asp:Label>
        </div>
        
        <div class="container">
            <h3>Total Cost: <asp:Label ID ="resultLabel" runat="server"></asp:Label></h3>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
        </div>
    </form>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
