<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payroll.aspx.cs" Inherits="EmployeeManagementSystem.payroll" MasterPageFile="~/Site.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Employee Payroll</h3>

    <div class="container ">
        <!-- Header -->
        <div id="content">
            <ul id="tabs" class="nav nav-tabs" data-tabs="tabs">
                <li class="active"><a href="#tab1"
                    data-toggle="tab">Generate Slip</a></li>
                <li><a href="#tab2" data-toggle="tab">View Slip</a></li>
            </ul>
            <div id="my-tab-content" class="tab-content">
                <div class="tab-pane  active" id="tab1">
                    <div class="row header" style="margin-top: 20px; margin-left: 10px">
                        <div class="col-sm-3 form-group">
                            <asp:Label runat="server" ID="lblYear" CssClass="control-label">Year</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlYear" TextMode="Number" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="year" ForeColor="Red"
                                ControlToValidate="ddlYear" ErrorMessage="Select year" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <asp:Label runat="server" ID="lblMonth" CssClass="control-label">Month</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlMonth" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="month" ForeColor="Red"
                                ControlToValidate="ddlMonth" ErrorMessage="Select month" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <asp:Label runat="server" ID="lblEmployee" CssClass="control-label">Employee</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="employee" ForeColor="Red"
                                                        ControlToValidate="ddlEmployee" ErrorMessage="Select Employee" />
                        </div>
                        <div class="col-sm-3 form-group" style="margin-top: 20px;">
                            <asp:Button runat="server" Text="Generate" CssClass="btn btn-danger" CausesValidation="False" ID="btnGenerate" OnClick="btnGenerate_OnClick"
                                OnClientClick="return confirm('Are you sure you want to proceed. previous data will get deleted for the month?'); " />
                        </div>
                    </div>
                </div>
                <div class="tab-pane" id="tab2">
                    <div class="row header" style="margin-top: 20px; margin-left: 10px">

                        <div class="col-sm-3 form-group">
                            <asp:Label runat="server" ID="lblViewYear" CssClass="control-label">Year</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlViewYear" TextMode="Number" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ForeColor="Red"
                                ControlToValidate="ddlViewYear" ErrorMessage="Select year" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <asp:Label runat="server" ID="lblViewMonth" CssClass="control-label">Month</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlViewMonth" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ForeColor="Red"
                                ControlToValidate="ddlViewMonth" ErrorMessage="Select month" />
                        </div>
                        <div class="col-sm-3 form-group" style="margin-top: 20px;">
                            <asp:Button runat="server" Text="Generate" CssClass="btn btn-primary" ID="BtnView" OnClick="BtnView_OnClick" />
                        </div>
                    </div>

                    <div id="grid">
                        <asp:GridView CssClass="table table-striped table-bordered table-hover"
                            runat="server" ID="gvpaySlip" AutoGenerateColumns="False"
                            AllowPaging="True" ShowHeaderWhenEmpty="True" EmptyDataText="There are no data records to display.">
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" ReadOnly="True" />
                                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
                                <asp:BoundField DataField="EPF" HeaderText="EPF" />
                                <asp:BoundField DataField="CashInHand" HeaderText="CashInHand" />
                                <asp:BoundField DataField="CreatedBy" HeaderText="Generated By" />
                                <asp:BoundField DataField="CreatedOn" HeaderText="Generated On" DataFormatString="{0:dd/MM/yyyy hh:MM tt}" />
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField runat="server" ID="hdnId" Visible="False" />
                    </div>
                </div>
            </div>

        </div>
    </div>
    <asp:HiddenField ID="selected_tab" runat="server"/>
    <script type="text/javascript">
        var selected_tab = 1;
        $(function () {
            var tabs = $("#tabs").tab({
                select: function (e, i) {
                    selected_tab = i.index;
                }
            });
            selected_tab = $("[id$=selected_tab]").val() != "" ? parseInt($("[id$=selected_tab]").val()) : 0;
            tabs.tab('show', selected_tab);
            $("form").submit(function () {
                $("[id$=selected_tab]").val(selected_tab);
            });
        });
 
    </script>
</asp:Content>
