// JScript File

function ResizePage(){
		var hHeader = document.getElementById("header").scrollHeight;
		var hContentWrapper = document.getElementById("content_wrapper").scrollHeight;
		var hContent = document.getElementById("content").scrollHeight;
		var hFooter = document.getElementById("footer").scrollHeight;
		
		var hPage = hHeader + hContent + hFooter;
		var hWindow = ((window.innerHeight) ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight) ? document.documentElement.clientHeight : document.body.offsetHeight)-4;
		var hContent = (hWindow >= hPage)?(hWindow-hHeader-hFooter):(hPage-hHeader-hFooter);
		
		document.getElementById("wrapper").style.height=hWindow;
		document.getElementById("content").style.height=hContent;
		document.getElementById("navigation").style.height=hContent;
		document.getElementById("content_wrapper").style.height=hContent;
		document.getElementById("body_shadow").style.height=(hWindow >= hPage)?hWindow:hPage;
		
		var wPage = document.getElementById("header").scrollWidth;
		var wWindows = ((window.innerWidth) ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth) ? document.documentElement.clientWidth : document.body.offsetWidth);
		document.getElementById("body_bg").style.width=wPage>wWindows?wPage+50:wWindows;
		//alert(hContent+","+hPage+","+hWindow);
}

function ResizePageColumn(){
		var hHeader = document.getElementById("header").scrollHeight;
		var hContentWrapper = document.getElementById("content").scrollHeight;
		var hFooter = document.getElementById("footer").scrollHeight;
		var hFooter1 = document.getElementById("footer_1").scrollHeight;
		var hFooter2 = document.getElementById("footer_2").scrollHeight;
		
		var hPage = hHeader + hContentWrapper + hFooter;
		//alert(hHeader +':'+ hContentWrapper +':'+ hFooter+"("+hFooter1+":"+hFooter2+")");
		var hWindow = ((window.innerHeight) ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight) ? document.documentElement.clientHeight : document.body.offsetHeight)-4;
		var hContent = (hWindow >= hPage)?(hWindow-hHeader-hFooter):(hPage-hHeader-hFooter);
		//alert(hPage+':'+hWindow);
		//document.getElementById("wrapper").style.height=hWindow;
		//document.getElementById("content").style.height=hContent;
		//document.getElementById("navigation").style.height=hContent;
		document.getElementById("content").style.height=hContent;
		document.getElementById("content_wrapper").style.height=hContent;
		//document.getElementById("body_shadow").style.height=(hWindow >= hPage)?hWindow:hPage;
		//alert(hContent+","+hPage+","+hWindow);
		//alert(document.getElementById("content").clientHeight);
		
		var wPage = document.getElementById("header").scrollWidth;
		var wWindows = ((window.innerWidth) ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth) ? document.documentElement.clientWidth : document.body.offsetWidth);
		document.getElementById("body_bg").style.width=wPage>wWindows?wPage+50:wWindows;
}

function ResizePageManagement(){
		//var wDivPhoto = document.getElementById("divPhoto").scrollWidth;
		//var wDivESLIntranet = document.getElementById("divESLIntranet").scrollWidth;
		var wDivLogo = 172;
		var wWindow = ((window.innerWidth) ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth) ? document.documentElement.clientWidth : document.body.offsetWidth)-10;
		var hWindow = ((window.innerHeight) ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight) ? document.documentElement.clientHeight : document.body.offsetHeight)-10;
		document.getElementById("header").style.width = wWindow;
		
		var divPhoto2 =wWindow-wDivLogo-18;//-wDivPhoto-wDivESLIntranet
		var divNavigation = document.getElementById("navigation").clientHeight;
		var divNavi_shadow = hWindow-document.getElementById("navigation_shadow").offsetTop;
		//document.getElementById("divPhoto2").style.width=(divPhoto2 >= 10)?divPhoto2:10;
		document.getElementById("navigation_shadow").style.height=(divNavi_shadow>divNavigation)?divNavi_shadow:divNavigation;
}

function GetWindowHeight()
{
	var hWindow = ((window.innerHeight) ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight) ? document.documentElement.clientHeight : document.body.offsetHeight)-4;
	return hWindow;
}

function GetWindowWidth()
{
	var wWindow = ((window.innerWidth) ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth) ? document.documentElement.clientWidth : document.body.offsetWidth)-10;
	return wWindow;
}

function GetPageHeight()
{
	var hHeader = document.getElementById("header").scrollHeight;
	var hContentWrapper = document.getElementById("content_wrapper").scrollHeight;
	var hFooter = document.getElementById("footer").scrollHeight;
	
	var hPage = hHeader + hContentWrapper + hFooter;
	return hPage;
}

function GetPageWidth()
{
	var wHeader = document.getElementById("header").scrollWidth;
	return wHeader;
}

function GetPageHeightForManage()
{
	var hHeader = document.getElementById("header").scrollHeight;
	var hContent = document.getElementById("content").scrollHeight;

	var hPage = hHeader + hContent + 100;
	return hPage;
}

function GetPageWidthForManage()
{
	var wHeader = document.getElementById("header").scrollWidth;
	return wHeader;
}

//get location on x-axis
function getX(obj) {
    var x = obj.offsetLeft;
    while (obj = obj.offsetParent) {
        x += obj.offsetLeft;
    }
    return x;
}

//get location on y-axis
function getY(obj) {
    var y = obj.offsetTop;
    while (obj = obj.offsetParent) {
        y += obj.offsetTop;
    }
    return y;
}

