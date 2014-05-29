var lookupgrid = null;
var lt = "";
var lps = "";
var lts = "";
var ls = "";
function lookupOpen(lookupType,lookupParams,lookupTargets,lookupSearch)
{
    var url = ''; var params = '';
    
    lt = lookupType; lps = lookupParams; lts = lookupTargets; ls = lookupSearch;
    url = '../Commons/Lookup.aspx';
    params = 'rnd=' + Math.random()*4
           + '&lt=' + lt
           + '&lps=' + lps
           + '&lts=' + lts
           + '&ls=' + ls
           + '';

    showDiv('lookup');
	initLookupGrid();
    //alert(params);
	lookupgrid.clearAll();
    //lookupgrid.loadXML(url+'?'+params);
	// lookupgrid.clearAll();
	// lookupgrid.loadXML('test.xml');
    //dhtmlxAjax.post('../Commons/Lookup.aspx', params, outputResponse);
}

function lookupSearch(lookupSearch)
{
    ls = lookupSearch;
    url = '../Commons/Lookup.aspx';
    params = 'rnd=' + Math.random()*4
           + '&lt=' + lt
           + '&lps=' + lps
           + '&lts=' + lts
           + '&ls=' + ls
           + '';
    lookupgrid.clearAll();
    centerLoadingImage();
    lookupgrid.loadXML(url+'?'+params ,function()
			{
				hideLoadingImageLookUp();
				});
}

function bindToTarget(id)
{
    var controls = new Array();
    controls = lts.split(",");
    try
    {
        for (var i=0;i<controls.length - 1;i++)
        {
            var element = document.getElementById(controls[i]);

            if(element.type=="text" || element.type=="hidden")
			{
				element.value = lookupgrid.cells(id, 1 + i).getValue();
				if(element.type=="text")
				element.focus();
			}
//			else if(element.type=="select-one")
//				this.setDropDownList(element,this.Grid.cells(id, i+1).getValue());
//			else
//			    element.value = lookupgrid.cells(id, i + 1).getValue();
        }
    }
    catch(ex)
    {
        alert(ex.description);
    }
}

function outputResponse(loader)
{
    if (loader.xmlDoc.responseText != null)
        alert('We Got Response\n\n' + loader.doSerialization() + ' ' + loader.xmlDoc.responseText);
    else
        alert('Response contains no XML');
}

function showDiv(idDiv)
{
    try
    {
        var obj = null;
        var x = null; var y = null;
		document.getElementById('lookupKey').value = '';
        obj = document.getElementById(idDiv);
        obj.style.width = "500px";
        obj.style.height = "300px";
        obj.style.backgroundColor = "#dfdfdf";
        obj.style.border = "solid 1 #000000";
        obj.style.zIndex = "9999";
        obj.style.position = "fixed";
        obj.style.display = "block";
        obj.style.visibility = "visible";
        goToCenter(idDiv);
        showBackLookup();
        //initLookupGrid(url);
    }
    catch(e)
    {
        alert(e.description);
    }
}

function initLookupGrid()
{
    lookupgrid = new dhtmlXGridObject('gridLookup');
    lookupgrid.setImagePath("../JavaScript/codebase/imgs/");
    lookupgrid.setHeader("No,ID,Deskripsi");
    lookupgrid.setInitWidths("50,80,*");
    lookupgrid.setColAlign("center,left,left");
    lookupgrid.setColTypes("ro,ro,ro");
    lookupgrid.setColSorting("str,str,str");
    lookupgrid.setSkin("dhx_skyblue");
    lookupgrid.attachEvent("onRowSelect",onRowSelected);
    lookupgrid.init();
//    if (url=='') url = '../Commons/Lookup.aspx';
//    lookupgrid.loadXML(url);
}

function onRowSelected(rowId,cellIndex)
{
    bindToTarget(rowId);
    hideLookup('lookup');
}

function goToCenter(idDiv)
{
    var obj = null;
    obj = document.getElementById(idDiv);
    x = (screen.availWidth / 2) - 250;
    y = (screen.height / 2) - 300;
    obj.style.marginLeft = x + "px";
    obj.style.marginTop = y + "px";
}

function goImgToCenter(idDiv)
{
    var obj = null;
    obj = document.getElementById(idDiv);
    x = (screen.availWidth / 2) - 150;
    y = (screen.height / 2) - 200;
    obj.style.marginLeft = x + "px";
    obj.style.marginTop = y + "px";
   // alert(x);
}

function hideLookup(idDiv)
{
    try
    {
        var obj = null;
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
        hideBackLookup();
    }
    catch(e)
    {
        alert(e.description);
    }
}

function showBackLookup()
{
    var obj = null;
    var x = null; var y = null;
    obj = document.getElementById('backLookup');
    obj.style.width = screen.availWidth + "px";
    obj.style.height = screen.availHeight + "px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "9998";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "visible";
}

function centerLoadingImage()
{
    var obj = null;
    obj = document.getElementById('loadDiv');
    obj.style.width = "100px";
    obj.style.height = "100px";
    obj.style.backgroundColor = "#dfdfdf";
    obj.style.border = "solid 1 #000000";
    obj.style.zIndex = "9999";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "visible";
    goImgToCenter('loadDiv');
    showBackLookup();
//    goToCenter("loadDiv");
//    obj.style.zIndex = "9999";
}

function hideLoadingImage()
{
    var obj = null;
    obj = document.getElementById('loadDiv');
    obj.style.width = "0px";
    obj.style.height = "0px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "-1";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "hidden";
    hideBackLookup();
}


function hideBackLookup()
{
    var obj = null;
    var x = null; var y = null;
    obj = document.getElementById('backLookup');
    obj.style.width = "0px";
    obj.style.height = "0px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "-1";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "hidden";
}
function hideLoadingImageLookUp()
{
    var obj = null;
    obj = document.getElementById('loadDiv');
    obj.style.width = "0px";
    obj.style.height = "0px";
    obj.style.left = "0px";
    obj.style.top = "0px";
    obj.style.zIndex = "-1";
    obj.style.position = "fixed";
    obj.style.display = "block";
    obj.style.visibility = "hidden";
    showBackLookup();
}