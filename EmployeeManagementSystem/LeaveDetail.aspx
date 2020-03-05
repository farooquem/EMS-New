<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveDetail.aspx.cs" Inherits="EmployeeManagementSystem.LeaveDetail" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Leave Details</h3>
<div id="filt" style="margin-top: 20px" class="container-fluid">
<div ID="controls" runat="server">
   <div class="row">
        <div class="col-sm-4 form-group">
            <asp:Label runat="server" ID="lblEmployeeName" CssClass="control-label">Employee</asp:Label>
            <asp:DropDownList runat="server" ID="ddlEmployeeName" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ID="employeeName" ForeColor="Red" ControlToValidate="ddlEmployeeName" ErrorMessage="Select name" />
        </div>
        <div class="col-sm-4 form-group">
            <asp:Label runat="server" ID="lblFromDate" CssClass="control-label">From Date</asp:Label>
            <asp:TextBox runat="server" TextMode="Date" ID="txtFromDate" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server"  ID="fromDate" ForeColor="Red" ControlToValidate="txtFromDate" ErrorMessage="Enter from date" />
        </div>
        <div class="col-sm-4 form-group">
            <asp:Label runat="server" ID="lblToDate" CssClass="control-label">To Date</asp:Label>
            <asp:TextBox runat="server" TextMode="Date" ID="txtToDate" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="toDate" ForeColor="Red" ControlToValidate="txtToDate" ErrorMessage="Enter to date" />
        </div>
        </div>
    <div class="row">
        <div class="col-sm-6 form-group">
            <asp:Label runat="server" ID="lblReason" CssClass="control-label">Reason</asp:Label>
            <asp:TextBox runat="server" ID="txtReason" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="reason" ForeColor="Red" ControlToValidate="txtReason" ErrorMessage="Enter Reason" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-3 form-group">
        <asp:CheckBox runat="server" ID="chkApprove"  CssClass="form-control"></asp:CheckBox>
    </div>
    </div>
        <div class="row pull-right">
            <%-- <div class="col-sm-6 form-group" style="width: 100%">
                <asp:DropDownList runat="server" ID="ddlFilter" Height="33px" ></asp:DropDownList>
                <asp:TextBox runat="server" ID="txtSearch" Height="33px"></asp:TextBox>
                    <asp:Button runat="server" Text="Search" CssClass="btn btn-primary" ID="btnSearch" OnClick="btnSearch_OnClick" CausesValidation="False" />
                    </div>--%>
            
            <div class="col-sm-12 form-group" <%-- style="width: 100%"--%>>
                <asp:Button runat="server" Text="New" CssClass="btn btn-primary" ID="btnNew" OnClick="btnNew_OnClick" CausesValidation="False" />
                <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_OnClick" />
                <asp:Button runat="server" Text="Reset" ID="btnReset" CssClass="btn btn-primary" OnClick="btnReset_OnClick" OnClientClick="return cleanForm();" CausesValidation="False" />
            </div>
        </div>
   
    
    
</div>
    <div id="grid">
        <asp:GridView CssClass="table table-striped table-bordered table-hover"
                      runat="server" ID="gvLeave" AutoGenerateColumns="False" OnRowDeleting="gvLeave_OnRowDeleting" OnSelectedIndexChanged="gvLeave_OnSelectedIndexChanged"
                      
                      AllowPaging="True" ShowHeaderWhenEmpty="True" EmptyDataText="There are no data records to display.">
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete?'); " CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="FromDate" HeaderText="From"  DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="ToDate" HeaderText="To" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="NoOfDate" HeaderText="Days" />
                <asp:BoundField DataField="LeaveReason" HeaderText="Reason" />
                <asp:BoundField DataField="Approved" HeaderText="Approved" />
                <asp:BoundField DataField="CreatedOn" HeaderText="Added On" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="CreatedBy" HeaderText="Added By" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField runat="server" ID="hdnId" Visible="False"/>
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
