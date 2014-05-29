function getXMLHTTPRequest()
{
    var ajax;
    if (window.XMLHttpRequest)
    {
        ajax = new XMLHttpRequest();
    }
    else
    {
        ajax = new ActiveXObject("Microsoft.XMLHTTP");
    }
    return ajax;
}

function sendRequest(url,method,parameters,func,continued)
{
    var ajax = getXMLHTTPRequest();
    var params = url + "?" + Math() + "&" + parameters;
    
    ajax.onreadystatechange = func;
    ajax.open(method,params,continued);
    ajax.send(null);
}