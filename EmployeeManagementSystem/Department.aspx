<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="EmployeeManagementSystem.Department" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Department</h3>
    <div id="filt" style="margin-top: 20px" class="container-fluid">
    <div ID="controls" runat="server" class="form-inline">
        
            <div class="col-sm-6 form-group">
                <asp:Label runat="server" ID="lblDeartment" CssClass="control-label">Department Name</asp:Label>
                <asp:TextBox runat="server" ID="txtDepartment" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="firstName" ForeColor="Red" ControlToValidate="txtDepartment" ErrorMessage="Enter Department" />
            </div>
            <div class="col-sm-3 form-group">
                <div class="checkbox">
                    <asp:CheckBox runat="server" ID="chkActive" Text="Active"></asp:CheckBox>
                </div>
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
            runat="server" ID="gvDepartment" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvDepartment_OnSelectedIndexChanged"
            AllowPaging="True" ShowHeaderWhenEmpty="True" EmptyDataText="There are no data records to display.">
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"
                    Visible="False" />
                <asp:BoundField DataField="Name" HeaderText="Department" />
               <asp:BoundField DataField="IsActive" HeaderText="Active"/>
                <asp:BoundField DataField="CreatedBy" HeaderText="Created By"/>
                <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  DataFormatString="{0:dd/MM/yyyy}"/>
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