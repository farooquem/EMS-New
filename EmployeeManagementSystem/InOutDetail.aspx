<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InOutDetail.aspx.cs" Inherits="EmployeeManagementSystem.InOutDetail" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>In/Out Details</h3>
<div id="filt" style="margin-top: 20px" class="container-fluid">
    <div class="row">
        <div class="col-sm-3 form-group">
            <asp:Label runat="server" ID="lblFromDate" CssClass="control-label">Username</asp:Label>
            <asp:TextBox runat="server" TextMode="Date" ID="txtFromDate" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="fromDate" ForeColor="Red" ControlToValidate="txtFromDate" ErrorMessage="Enter From Date" />
        </div>
        <div class="col-sm-3 form-group">
            <asp:Label runat="server" ID="lblToDate" CssClass="control-label">Username</asp:Label>
            <asp:TextBox runat="server" TextMode="Date" ID="txtToDate" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="toDate" ForeColor="Red" ControlToValidate="txtToDate" ErrorMessage="Enter To Date" />
        </div>
        <div class="col-sm-3 form-group">
            <asp:Label runat="server" ID="lblEmployee" CssClass="control-label">Username</asp:Label>
            <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-3 form-group">
            <div style="margin-top: 20px">
            <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_OnClick"/>
            <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_OnClick" CausesValidation="False" OnClientClick="return cleanForm();" />
            </div>
                </div>
    </div>
</div>
    <div id="grid">
        <asp:GridView CssClass="table  table-bordered table-hover table-striped"
                      runat="server" ID="gvInOut" AutoGenerateColumns="False" AllowPaging="True" ShowHeaderWhenEmpty="True"
                      EmptyDataText="There are no data records to display.">
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" />
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee" />
                <asp:BoundField DataField="Date" HeaderText="Date"/>
                <asp:BoundField DataField="InTime" HeaderText="In"/>
                <asp:BoundField DataField="OutTime" HeaderText="Out" />
            </Columns>
        </asp:GridView>
    </div>
    <script type="text/javascript">
          function cleanForm() {

              document.forms[0].reset();
              for (var i = 0; i < Page_Validators.length; i++) {
                  Page_Validators[i].style.visibility = 'hidden';
              }
              return true;
          }
      </script>
</asp:Content>
