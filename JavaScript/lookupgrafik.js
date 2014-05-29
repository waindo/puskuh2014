var id=null,title=null;
function showDivgrafik(idDiv,id1,title1)
{
    try
    {
        var obj = null;
        var iprame = null;
        var judul = null;
        var konten = null;
        var x = null; var y = null;
	//	document.getElementById('lookupKey').value = '';
	    id=id1;
	    title=title1;
	   // konten = document.getElementById('contentLookupgrafik');
	    //konten.style.opacity=0;
        obj = document.getElementById(idDiv);
        obj.style.width = "920px";
        obj.style.height = "510px";
        obj.style.backgroundColor = "#dfdfdf";
        //obj.style.border = "solid 1 #f0f8ff";
        obj.style.zIndex = "9999";
        obj.style.position = "fixed";
        //obj.style.visibility = "visible";
        obj.style.display = "block";
       // alert('tst');
        //judul = document.getElementById('jdl');
        //judul.innerHTML = title;
        obj.style.visibility = "visible";
        openContentLookupgrafik('contentLookupgrafik');
        goToCentergrafik(idDiv);
        showBackLookupgrafik();
        //initLookupGrid(url);
    }
    catch(e)
    {
        alert(e.description);
    }
}

function hideLookupgrafik(idDiv)
{
    try
    {
        var obj = null;
        var obj2=null;
        var obj3=null;
        var x = null; var y = null;
        obj = document.getElementById(idDiv);
        obj.style.width = "0px";
        obj.style.height = "0px";
        obj.style.backgroundColor = "#dfdfdf";
        obj.style.border = "solid 1 #000000";
        obj.style.zIndex = "-1";
        obj.style.position = "fixed";
        obj.style.display = "block";
        obj.style.visibility = "hidden";
        
        obj2 = document.getElementById('imgcollapse');
        obj2.style.visibility="hidden";
        obj3 = document.getElementById('imgexpand');
        obj3.style.visibility="visible";
        
        hideBackLookupgrafik();
    }
    catch(e)
    {
        alert(e.description);
    }
}

function hideContentLookupgrafik(idDiv)
{
    try
    {
        var obj = null;
        var obj2 = null;
        var obj3 = null;
        
        var x = null; var y = null;
        obj = document.getElementById(idDiv);
        //obj.style.width = "0px";
        //obj.style.height = "0px";
        obj.style.position = "fixed";
        obj.style.display = "block";
        obj.style.visibility = "hidden";
        
        obj3 = document.getElementById('imgexpand');
        obj3.style.visibility="hidden";
        
        obj4 = document.getElementById('imgcollapse');
        obj4.src="images/collapse.gif";
        obj4.style.visibility="visible";
        obj4.style.width="20px";
        
        
        obj2 = document.getElementById('lookup');
        obj2.style.height = "30px";
        obj2.style.width = "300px";
    }
    catch(e)
    {
        alert(e.description);
    }
}

function openContentLookupgrafik(idDiv)
{
    try
    {
        var obj = null;
        var obj2 = null;
        var obj3 = null;
        
        var x = null; var y = null;
        obj = document.getElementById(idDiv);
        //obj.style.width = "0px";
        //obj.style.height = "0px";
        obj.style.position = "fixed";
        obj.style.display = "block";
        obj.style.visibility = "visible";
        
        obj3 = document.getElementById('imgexpand');
        obj3.style.visibility="visible";
        
        obj4 = document.getElementById('imgcollapse');
        obj4.style.visibility="hidden";

//        obj4.style.width="20px";
        obj2 = document.getElementById('lookupgrafik');
        obj2.style.width = "920px";
        obj2.style.height = "510px";
        
        var iprame = document.getElementById('mapFrame');
        //iprame.style.width = "700px";
        //iprame.style.height = "310px";
        
        if (title=="Pipa Gas")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infoPipa.aspx?id="+id;
        else if (title=="Offtake")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infoOfftake.aspx?id="+id;
        else if(title=="Stasiun Pelanggan")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infopelanggan.aspx?id="+id;
        else if(title=="Stasiun Pembagi")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/pelangganiden.aspx?id="+id;
        else if(title=="Manual Valve")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infovalve.aspx?id="+id+"&layer="+title;
        else if(title=="Bak Valve (manhole)")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infobakvalve.aspx?id="+id+"&layer="+title;
        else if(title=="Jembatan Pipa")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infoJembatan.aspx?id="+id+"&layer="+title;
        else if(title=="Tiang Ukur Katodik")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infotestbox.aspx?id="+id+"&layer="+title;
        else if(title=="Patok Gas")
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/infopatokgas.aspx?id="+id+"&layer="+title;
        else
            iprame.src="http://gis.pgn.co.id/gis_dev/pages/chartkondisitestbox.aspx?id="+id;
            
  
    }
    catch(e)
    {
        alert(e.description);
    }
}

function showBackLookupgrafik()
{
    var obj = null;
    var x = null; var y = null;
    obj = document.getElementById('backLookupgrafik');
    obj.setAttribute("background-image","url(../images/backGroundGelap.png)");
    obj.style.width = screen.availWidth + "px";
    obj.style.height = screen.availHeight + "px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "9998";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "visible";
}

function hideBackLookupgrafik()
{
    var obj = null;
    var x = null; var y = null;
    obj = document.getElementById('backLookupgrafik');
    obj.style.width = "0px";
    obj.style.height = "0px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "-1";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "hidden";
}

function goToCentergrafik(idDiv)
{
    var obj = null;
    obj = document.getElementById(idDiv);
    x = (screen.availWidth / 2) - 460;
    y = (screen.height / 2) - 460;
    obj.style.marginLeft = x + "px";
    obj.style.marginTop = y + "px";
    //obj.style.marginLeft = "10px";
    //obj.style.marginTop = "10px";
    
}

function showBackLookupgrafik()
{
    var obj = null;
    var x = null; var y = null;
    obj = document.getElementById('backLookupgrafik');
    obj.style.width = screen.availWidth + "px";
    obj.style.height = screen.availHeight + "px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "9998";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "visible";
}






