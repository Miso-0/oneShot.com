<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="OneShot.com.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="TopAdminHeader">
            <div class="searchBarbase">
                <input type="search" class="searchInput" placeholder="Promotion name" id="searchSomething">
                <button class="btnFind">
                    <span class="material-icons">search</span>
                </button>
            </div>
            <a href="#"> <span class="material-icons">notifications</span></a>
            <a href="#"><span class="material-icons">email</span></a>
        </div>
      <div class="main-content">
            <div class="sub-main-content">
                <div class="stats-slabs">
                    <div class="statistics">
                                   <div class="stat-header">
                            <h3>Statistics</h3>
                        </div>
                        <div class="stat-base">


                     

                            <div class="stat-data-A">
                                <div class="circle-stat">
                                    <span class="material-icons">person_outline</span>
                                </div>
                                <ul>
                                    <li>
                                        <h2 runat="server" id="totalCustomers">50k</h2>
                                    </li>
                                    <li>Customers</li>
                                </ul>
                            </div>

                            <div class="stat-data-A">
                                <div class="circle-stat">
                                    <span class="material-icons">category</span>
                                </div>
                                <ul>
                                    <li>
                                        <h2 runat="server" id="totalProducts">1,4k</h2>
                                    </li>
                                    <li>Products</li>
                                </ul>
                            </div>
                                   <div class="stat-data-A">
                                <div class="circle-stat">
                                    <span class="material-icons">trending_up</span>
                                </div>
                                <ul>
                                    <li>
                                        <h2 runat="server" id="totalSales">20k</h2>
                                    </li>
                                    <li>Sales</li>
                                </ul>
                            </div>
                            <div class="stat-data-A">
                                <div class="circle-stat">
                                    <span class="material-icons">attach_money</span>
                                </div>
                                <ul>
                                    <li>
                                        <h2 id="TRevenue" runat="server"></h2>
                                    </li>
                                    <li>Revenue</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="columnGraph">
                        <div id="columnchart_material" style="width: 100%; height: 400px;"></div>
                    </div>
                    <div class="LinenGraph">
                        <div id="chart_div" style="width: 100%; height: 400px;"></div>
                    </div>
                    <div class="orders">
                               <div class="orders-top-container">
                            <h3>Employees</h3>
                            <a href="#">
                                <span class="material-icons">visibility</span>
                            </a>
                        </div>
                        <div style="float:left;width:100%;"  runat="server" id="employees">
          
                        </div>
                    
                    </div>
                    <div class="PieChart">
                        <div id="piechart" style="width: 100%; height: 400px;"></div>
                    </div>
                </div>
                <div style="display:none" id="LineGraphLoader" runat="server">

                </div>

                <div style="display:none" runat="server" id="ColumnGraphDateLoader" class="ColumnGraphDate">

                </div>
            </div>

        </div>


    <!-- Pie chart js -->
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    google.charts.load('current', {
        'packages': ['corechart']
    });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {

        var data = google.visualization.arrayToDataTable([
            ['Task', 'Hours per Day'],
            ['Work', 11],
            ['Eat', 2],
            ['Commute', 2],
            ['Watch TV', 2],
            ['Sleep', 7]
        ]);

        var options = {
            title: 'OneShot.com Sales'
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
    }
</script>

<!-- line graph js -->
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    google.charts.load('current', {
        'packages': ['corechart']
    });
    google.charts.setOnLoadCallback(drawChart);


    function drawChart() {
        var dataClass = document.getElementsByClassName("dataLine");
        var data = google.visualization.arrayToDataTable([
            ['Month', 'Sales', 'Expenses'],

            [dataClass[0].innerText, parseInt(dataClass[1].innerText), parseInt(dataClass[2].innerText)],
            [dataClass[3].innerText, parseInt(dataClass[4].innerText), parseInt(dataClass[5].innerText)],
            [dataClass[6].innerText, parseInt(dataClass[7].innerText), parseInt(dataClass[8].innerText)],
            [dataClass[9].innerText, parseInt(dataClass[10].innerText), parseInt(dataClass[11].innerText)],
            [dataClass[12].innerText, parseInt(dataClass[13].innerText), parseInt(dataClass[14].innerText)],
            [dataClass[15].innerText, parseInt(dataClass[16].innerText), parseInt(dataClass[17].innerText)],
            [dataClass[18].innerText, parseInt(dataClass[19].innerText), parseInt(dataClass[20].innerText)],
            [dataClass[21].innerText, parseInt(dataClass[22].innerText), parseInt(dataClass[23].innerText)],
            [dataClass[24].innerText, parseInt(dataClass[25].innerText), parseInt(dataClass[26].innerText)],
            [dataClass[27].innerText, parseInt(dataClass[28].innerText), parseInt(dataClass[29].innerText)],
            [dataClass[30].innerText, parseInt(dataClass[31].innerText), parseInt(dataClass[32].innerText)],
            [dataClass[33].innerText, parseInt(dataClass[34].innerText), parseInt(dataClass[35].innerText)]


        ]);

        var options = {
            title: 'OneShot.com Performance',
            hAxis: {
                title: 'Month',
                titleTextStyle: {
                    color: '#333'
                }
            },
            vAxis: {
                minValue: 0
            }
        };

        var chart = new google.visualization.AreaChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
</script>

<!-- Column graph -->
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    google.charts.load('current', {
        'packages': ['bar']
    });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var dataClass = document.getElementsByClassName("dataLine2");
        var data = google.visualization.arrayToDataTable([
            ['Month', 'Visitors', 'Registered', 'Ordered'],
            [dataClass[0].innerText, parseInt(dataClass[1].innerText), parseInt(dataClass[2].innerText), parseInt(dataClass[3].innerText)],
            [dataClass[4].innerText, parseInt(dataClass[5].innerText), parseInt(dataClass[6].innerText), parseInt(dataClass[7].innerText)],
            [dataClass[8].innerText, parseInt(dataClass[9].innerText), parseInt(dataClass[10].innerText), parseInt(dataClass[11].innerText)],
            [dataClass[12].innerText, parseInt(dataClass[13].innerText), parseInt(dataClass[14].innerText), parseInt(dataClass[15].innerText)],
            [dataClass[16].innerText, parseInt(dataClass[17].innerText), parseInt(dataClass[18].innerText), parseInt(dataClass[19].innerText)],
            [dataClass[20].innerText, parseInt(dataClass[21].innerText), parseInt(dataClass[22].innerText), parseInt(dataClass[23].innerText)],
            [dataClass[24].innerText, parseInt(dataClass[25].innerText), parseInt(dataClass[26].innerText), parseInt(dataClass[27].innerText)],
            [dataClass[28].innerText, parseInt(dataClass[29].innerText), parseInt(dataClass[30].innerText), parseInt(dataClass[31].innerText)],
            [dataClass[32].innerText, parseInt(dataClass[33].innerText), parseInt(dataClass[34].innerText), parseInt(dataClass[35].innerText)],
            [dataClass[36].innerText, parseInt(dataClass[37].innerText), parseInt(dataClass[38].innerText), parseInt(dataClass[39].innerText)],
            [dataClass[40].innerText, parseInt(dataClass[41].innerText), parseInt(dataClass[42].innerText), parseInt(dataClass[43].innerText)],
            [dataClass[44].innerText, parseInt(dataClass[45].innerText), parseInt(dataClass[46].innerText), parseInt(dataClass[47].innerText)]

        ]);

        var options = {
            chart: {
                title: 'OneShot.com monthly website Traffic',
                subtitle: 'Visitors, Registered, and Ordered: Jan-Dec',
            }
        };

        var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

        chart.draw(data, google.charts.Bar.convertOptions(options));
    }
</script>

</asp:Content>
