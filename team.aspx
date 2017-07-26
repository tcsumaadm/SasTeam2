<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="team.aspx.cs" Inherits="SASTeam.team" %>

<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team Details</title>

    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    <script src="Scripts/jquery.quicksearch.js"></script>
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" />
   <%-- <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GridView1] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>--%>
</head>
<body>
    
    <form id="form1" runat="server">
      <%--  <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>--%>
        <div>


            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3" Font-Size="Large" OnDataBound="GridView1_DataBound" AllowSorting="True" OnSorting="GridView1_Sorting1">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" Font-Size="Large" HorizontalAlign="Left" />
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" Visible="false"></asp:BoundField>
                    <asp:BoundField HeaderText="EmpId" DataField="EmpId" SortExpression="EmpId"></asp:BoundField>
                    <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField HeaderText="Designation" DataField="Designation" SortExpression="Currency"></asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location"></asp:BoundField>

                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

            </asp:GridView>

        </div>
    </form>
</body>
</html>
