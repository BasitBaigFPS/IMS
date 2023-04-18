<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WarehouseDashboard.aspx.cs" Inherits="IMS.WarehouseDashboard" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<%--     <script language="JavaScript" type="text/javascript">
         var t = setInterval("document.forms[0].submit();", 30000); //2 seconds measured in miliseconds
</script>--%>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%=this.litMIRList.ClientID%>').attr('size', $('#<%=this.litMIRList.ClientID%> option').length);
            $('#<%=this.litUCGIN.ClientID%>').attr('size', $('#<%=this.litUCGIN.ClientID%> option').length);

            ChangeSpace();
            ChangeGap();
        });


<%--        function ChangeSpace() {
            var chart = $find("<%=RadHtmlChart1.ClientID%>");
                chart._chartObject.options.series[1].spacing = 10;
                chart.repaint();
            }

            function ChangeGap() {
                var chart = $find("<%=RadHtmlChart1.ClientID%>");
                chart._chartObject.options.series[1].gap = 550;
                chart.repaint();
            }--%>

    </script>

    <div id="columns">
        
        <ul id="column1" class="column">
  
            <li class="widget color-red" id="static1">
                <div class="widget-head">
                    <h3>UN-RECEIVED/PENDING GIN</h3>
                </div>
                <div class="widget-content">                        
                     <asp:Literal ID="litUNRGIN" runat="server"></asp:Literal> 
                </div>
            </li>

            <li class="widget color-green" id="static2">
                <div class="widget-head">
                    <h3>MATERIAL ISSUANCE REQUEST</h3>
                </div>
                <div class="widget-content">                     
                       <%--  <asp:ListBox ID="MIRList" runat="server" Width="339px"></asp:ListBox>  --%>   
                         <asp:Literal ID="litMIRList" runat="server"></asp:Literal> 
                </div>
            </li>

            <li class="widget color-red" id="static3">
                <div class="widget-head">
                    <h3>DAYS PASS SINCE LAST IMS TRANSACTIONS</h3>
                </div>
                <div class="widget-content">                      
                         <asp:Literal ID="litTrans" runat="server"></asp:Literal> 
                </div>
            </li>

        </ul>

        <ul id="column2" class="column">
            <li class="widget color-blue" id="static4">  
                <div class="widget-head">
                    <h3>UNCONFIRMED GIN RECORD</h3>
                </div>
                <div class="widget-content">
                    <asp:Literal ID="litUCGIN" runat="server"></asp:Literal>
                </div>
            </li>
                    <asp:TextBox ID="txtbranchID" runat="server" Visible="False" Width="16px"></asp:TextBox>
                    <asp:TextBox ID="txtstoreID" runat="server" Visible="False" Width="16px"></asp:TextBox>

   <%--     <li class="widget color-yellow" id="static5">                 
               <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" /> 
            <div class="widget-head">
                   <h3>TOP 5 ISSUED ITEMS</h3>
                </div>
                <div class="widget-content">
                    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" DataSourceID="SqlDataSource2" Width="410px" Height="302px" Font-Size="Smaller" Skin="Office2010Silver">
                        <PlotArea>
                            <Series>
                                <telerik:ColumnSeries Name="Quantity" DataFieldY="QttyIssued" >
                                    <TooltipsAppearance Color="White" DataFormatString="{0}"></TooltipsAppearance>
                                    <LabelsAppearance Visible="false">
                                    </LabelsAppearance>
                                </telerik:ColumnSeries>
                            </Series>
                             
                            <XAxis DataLabelsField="ItemCode" Visible="true">
                                <MinorGridLines Visible="true"></MinorGridLines>
                                <MajorGridLines Visible="false"></MajorGridLines>

                                <LabelsAppearance DataFormatString="{0}" RotationAngle="0">
                                        <TextStyle Bold="false" FontFamily="Ariel Narrow" Color="Black" FontSize="7" Italic="false" Margin="0" Padding="0" />
                                </LabelsAppearance>

                                 <TitleAppearance Position="Center" RotationAngle="0" Text="Item Code">
                                     <TextStyle Bold="false" FontFamily="Ariel Narrow" Color="#3333FF" FontSize="12" Italic="false" Margin="2" Padding="5" />
                                </TitleAppearance>
                            </XAxis>

                            <YAxis Visible="true">                              
                                <MinorGridLines Visible="false"></MinorGridLines>

                                <LabelsAppearance DataFormatString="{0}" RotationAngle="0">
                                        <TextStyle Bold="false" FontFamily="Calibri" Color="Black" FontSize="12" Italic="false" Margin="0" Padding="0" />
                                </LabelsAppearance>

                                 <TitleAppearance Position="Center" RotationAngle="0" Text="Quantity Issued">
                                     <TextStyle Bold="false" FontFamily="Helvetica" Color="Black" Italic="false" Margin="2" Padding="2" />
                                </TitleAppearance>

                            </YAxis>
                        </PlotArea>
                        <Legend>
                            <Appearance  Visible="true"></Appearance>
                        </Legend>
                        <ChartTitle Text="Top 5 Issued Items">
                        <Appearance Visible="true">
                       </Appearance>
                        </ChartTitle>

                    <Navigator>
                    <XAxis Visible="true">
                    </XAxis>
                    </Navigator>
                    </telerik:RadHtmlChart>
                    
            </div>

              <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:INVENTORY %>"
                      SelectCommand="SELECT TOP 5 [fkIssueByBranchID],[fkIssueByStoreID],[fkIssueByDeptID],[ItemCount],[ItemCode],[ItemTitle],[QttyIssued],[IsCancel]
                    ,[StoreName],[deptName] FROM [INVENTORY].[dbo].[View_MostFrequentlyIssuedItems] where fkIssueByStoreID=@fkIssueByStoreID and pkCatID in (1,2) order by QttyIssued desc">
 
                     <SelectParameters>       
                           <asp:ControlParameter ControlID="txtstoreID" Name="fkIssueByStoreID" DefaultValue="1" PropertyName="Text"></asp:ControlParameter>                                
                    </SelectParameters>
               </asp:SqlDataSource>
            </li>--%>


<%--           <li class="widget color-blue" id="static6">  
                 <div class="widget-head">
                    <h3>10 MOST ISSUED ITEMS</h3>
                </div>
                <div class="widget-content">
                         <asp:Literal ID="litTopMostIssued" runat="server" ></asp:Literal>
                </div>                                 
            </li>

    --%>
        </ul>
        
        <ul id="column3" class="column">
            <li class="widget color-orange" id="static7">  
                <div class="widget-head">
                    <h3>Last Issued 5 GIN (Goods Issued Note)</h3>
                </div>
                <div class="widget-content">
                    <asp:Literal ID="lit5GIN" runat="server" ></asp:Literal> 
                </div>
            </li>

            <li class="widget color-white" id="static8">  
                <div class="widget-head">
                    <h3>Last Received 5 GRN (Goods Received Notes)</h3>
                </div>
                <div class="widget-content">
                    <asp:Literal ID="lit5GRN" runat="server" ></asp:Literal> 
                </div>
            </li>

  <%--          <li class="widget color-red" id="static9">  
                <div class="widget-head">
                    <h3>LOW BALANCE INVENTORY STATISTICS</h3>
                </div>
                <div class="widget-content">
                    <asp:Literal ID="litZeroBal" runat="server" ></asp:Literal> 
                </div>
            </li>--%>
            
        </ul>
        
    </div>
</asp:Content>

