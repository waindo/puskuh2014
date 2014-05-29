<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/MasterPage3.master" CodeFile="home.aspx.cs" Inherits="Pages_home" %>
<%@ OutputCache Location="None" VaryByParam="None" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="STYLESHEET" type="text/css" href="../JavaScript/codebase/dhtmlxchart.css" />
<link rel="STYLESHEET" type="text/css" href="../puskuh/js/fushioncharts/prettify.css" />
    <script src="../puskuh/js/fushioncharts/FusionCharts.js" type="text/javascript"></script>
    <script src="../puskuh/js/fushioncharts/prettify.js" type="text/javascript"></script>
    <script src="../puskuh/js/fushioncharts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../puskuh/js/fushioncharts/json2.js" type="text/javascript"></script>

<div id='tabchart' style="width: 1320px; height: 700px; aborder: #B5CDE4 1px solid;"></div>

<div id="tab1" style="width:100%;height:100%;float:left"></div>
<div id="tab2" style="width:100%;height:100%;float:left"></div>
<div id="tab3" style="width:100%;height:100%;float:left"></div>
<div id="tab4" style="width:100%;height:100%;float:left"></div>
<div id="tab5" style="width:100%;height:100%;float:left"></div>
<div id="MAP" style="width:100%;height:100%;float:left">
<iframe src="http://indogeoportal.com" width="100%" height="100%" frameborder="0" id="Iframe1" name="iframe_a"></iframe>
</div>



    <script language="JavaScript" type="text/javascript">
    var localURL = "home.aspx";


        tabbar1 = new dhtmlXTabBar(
                {
                    parent: "tabchart",
                    image_path: "../JavaScript/codebase/imgs/",
                    skin: "dhx_skyblue",
                    tabs: [{
                        id: "tabchart1",
                        label: "Jumlah Polygon",
                        width: "150px",
                        active: true
                    }, {
                        id: "tabchart2",
                        label: "Jumlah Permohonan",
                        width: "150px"
                    }, {
                        id: "tabchart3",
                        label: "Jumlah Penunjukan",
                        width: "150px"
                    }, {
                        id: "tabchart4",
                        label: "Jumlah SK Penetapan",
                        width: "150px"
                    }, {
                        id: "tabchart5",
                        label: "Rekap",
                        width: "150px"
                    }, {
                        id: "tabchart6",
                        label: "MAP",
                        width: "150px"

                    }]
                }
        );
//                tabbar1.setContent("tabchart", "tab");
        tabbar1.setContent("tabchart1", "tab1");
        tabbar1.setContent("tabchart2", "tab2");
        tabbar1.setContent("tabchart3", "tab3");
        tabbar1.setContent("tabchart4", "tab4");
        tabbar1.setContent("tabchart5", "tab5");
        tabbar1.setContent("tabchart6", "MAP");
        tabbar1.enableAutoReSize(false);

        graphicpolygon();
        graphicpemohon();
        graphicpenunjukan();
        graphicpenetapan();
        graphicrekap();

        function graphicpolygon() {
            var fusionchart = new FusionCharts("../puskuh/js/fushioncharts/MSColumn3D.swf", "myChartId", "750", "500");
            var s = ""
			        + "rnd=" + Math.random() * 4
			        + "&sm=jmlpolygon"
                    + "&DropDownAsset=JMLPOLYGON"
					+ "";
            fusionchart.setXMLUrl(localURL + "?" + s);
            fusionchart.render("tab1");
        }

        function graphicpemohon() {
            var fusionchart = new FusionCharts("../puskuh/js/fushioncharts/MSColumn3D.swf", "myChartId", "750", "500");
            var s = ""
			        + "rnd=" + Math.random() * 4
			        + "&sm=jmlpolygon"
                    + "&DropDownAsset=JMLPEMOHON"
					+ "";
            fusionchart.setXMLUrl(localURL + "?" + s);
            fusionchart.render("tab2");
        }

        function graphicpenunjukan() {
            var fusionchart = new FusionCharts("../puskuh/js/fushioncharts/MSColumn3D.swf", "myChartId", "750", "500");
            var s = ""
			        + "rnd=" + Math.random() * 4
			        + "&sm=jmlpolygon"
                    + "&DropDownAsset=JMLPENUNJUKAN"
					+ "";
            fusionchart.setXMLUrl(localURL + "?" + s);
            fusionchart.render("tab3");
        }

        function graphicpenetapan() {
            var fusionchart = new FusionCharts("../puskuh/js/fushioncharts/MSColumn3D.swf", "myChartId", "750", "500");
            var s = ""
			        + "rnd=" + Math.random() * 4
			        + "&sm=jmlpolygon"
                    + "&DropDownAsset=JMLPENETAPAN"
					+ "";
            fusionchart.setXMLUrl(localURL + "?" + s);
            fusionchart.render("tab4");
        }

        function graphicrekap() {
            var fusionchart = new FusionCharts("../puskuh/js/fushioncharts/MSColumn3D.swf", "myChartId", "750", "500");
            var s = ""
			        + "rnd=" + Math.random() * 4
			        + "&sm=jmlrekap"
                    + "&DropDownAsset=REKAP"
					+ "";
            fusionchart.setXMLUrl(localURL + "?" + s);
            fusionchart.render("tab5");
        }

    </script>
</asp:Content>