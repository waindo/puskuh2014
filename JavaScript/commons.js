var weekday=new Array(7);
weekday[0]="Ahad";
weekday[1]="Senin";
weekday[2]="Selasa";
weekday[3]="Rabu";
weekday[4]="Kamis";
weekday[5]="Jum'at";
weekday[6]="Sabtu";

function tambahTahun(tgl,inc)
{
    var a = new Array();
    var d = null;
    var ret = '';

    a = tgl.split("-");
    d = new Date(a[0],a[1],a[2]);

    year = d.getFullYear() + inc;
    year = year + '-' + a[1] + '-' + a[2];
    return year;
}

function validasiInput(evt,obj,tipe)
{
    if (tipe==1)
    {
        if (obj.value=='')
        {
            obj.value = '0';
        }
        if (!isNumber(obj.value))
        {
            obj.style.borderColor = "#ff6666";
            alert('Isian harus berupa bilangan.');
            //obj.value=obj.value.substring(0, obj.value.length-1);
            obj.value='0';
            obj.style.borderColor = '';
        }
        else
        {
            obj.style.borderColor = "";
        }
    }
    else if (tipe==2)
    {
        if (!isAlphanumeric(obj.value))
        {
            obj.style.borderColor = "#ff6666";
            alert('Isian harus berupa Alfanumerik.');
            obj.value='0';
            obj.style.borderColor = '';
        }
        else
        {
            obj.style.borderColor = "";
        }
    }
    else if (tipe==3)
    {
        if (obj.value=='')
        {
            obj.value = '0';
        }
        if (!isNumber2(obj.value))
        {
            obj.style.borderColor = "#ff6666";
            alert('Isian harus berupa bilangan.');
            obj.value='0';
            obj.style.borderColor = '';
        }
        else
        {
            obj.style.borderColor = "";
        }
    }
}

function isNumber(obj)
{
    var i = 0;
    for (i=0;i<obj.length;i++)
    {
        if (obj.charCodeAt(i) > 46 && (obj.charCodeAt(i) < 48 || obj.charCodeAt(i) > 57))
        {
            return false;
        }
    }
    return true;
}

function isNumber2(obj)
{
    var i = 0;
    for (i=0;i<obj.length;i++)
    {
        if ((obj.charCodeAt(i) < 48 || obj.charCodeAt(i) > 57))
        {
            return false;
        }
    }
    return true;
}

function isAlphanumeric(obj)
{
    var i = 0;
    for (i=0;i<obj.length;i++)
    {
        if ((obj.charCodeAt(i) != 95 && obj.charCodeAt(i) != 59 && obj.charCodeAt(i) != 32) &&(obj.charCodeAt(i) < 44 || obj.charCodeAt(i) > 46) && (obj.charCodeAt(i) < 48 || obj.charCodeAt(i) > 57) && (obj.charCodeAt(i) < 65 || obj.charCodeAt(i) > 90) && (obj.charCodeAt(i) < 97 || obj.charCodeAt(i) > 122))
        {
            return false;
        }
    }
    return true;
}

function enterPressed(evt,obj)
{
    if( evt.keyCode ) 
    {
        keyCode = evt.keyCode;
    }
    if( 13 == keyCode ) 
    {
        eval(obj);
    }
}
function Right(str, n){
    if (n <= 0)
       return "";
    else if (n > String(str).length)
       return str;
    else {
       var iLen = String(str).length;
       return String(str).substring(iLen, iLen - n);
    }
}