var langCodeList = "en-in,hi-in,gu-in,bn-in,mr-in,ta-in,te-in,kn-in,ml-in,pa-in,ar-sa";
$(document).ready(function () {
	SetLanguage();
});
function SetLanguage() {
	
	 //debugger;
	var Lang = getMoxCookie("lang");
	
	//alert(Lang);
	
	var newUrl = '';
	var strSegment = window.location.pathname.substr(1).split("/");
	var checkLang = strSegment[0];

	//alert(strSegment);
		
	if (langCodeList.indexOf(checkLang) > -1 && Lang != 'en-in') {
		
		//alert(Lang);
		if (Lang == 'hi-in')
		{
			$("#languageSelectedByUmesh").html("Hindi(हिंदी)  <img src='../images/arrow-down.png' />");
			//alert($("#languageSelectedByUmesh").html());
		}
		else if (Lang == 'pa-in')
			$("#languageSelectedByUmesh").html("Punjabi(ਪੰਜਾਬੀ) <img src='../images/arrow-down.png' />");
		else if (Lang == 'bn-in')
		    $("#languageSelectedByUmesh").html("Bengali(বাংলা) <img src='../images/arrow-down.png' />");
		else if (Lang == 'gu-in')
		    $("#languageSelectedByUmesh").html("Gujrati (ગુજરાતી) <img src='../images/arrow-down.png' />");
		else if (Lang == 'mr-in')
		    $("#languageSelectedByUmesh").html("Marathi (मराठी) <img src='../images/arrow-down.png' />");
		else if (Lang == 'ta-in')
		    $("#languageSelectedByUmesh").html("Tamil (தமிழ்) <img src='../images/arrow-down.png' />");
		else if (Lang == 'te-in')
		    $("#languageSelectedByUmesh").html("Telgu (తెలుగు) <img src='../images/arrow-down.png' />");
		else if (Lang == 'ml-in')
		    $("#languageSelectedByUmesh").html("Malayalam (മലയാളം) <img src='../images/arrow-down.png' />");
		else if (Lang == 'kn-in')
		    $("#languageSelectedByUmesh").html("Kannada (ಕನ್ನಡ) <img src='../images/arrow-down.png' />");
		else if (Lang == 'ar-sa')
		    $("#languageSelectedByUmesh").html("Arabic (عربى) <img src='../images/arrow-down.png' />");
		
		
	}
	
	
	
	
	var elem = document.getElementById("P9LngDdl");
	if (Lang && window.location.pathname.indexOf(Lang) < 0) {
		//RedurectUrl(Lang);
	}
	if (Lang && elem)
		document.getElementById("P9LngDdl").value = Lang;
}

function ChangeLanguageUmesh(lang) {

	var strLang = lang;
	removeMoxCookie("lang", "");
	if (strLang != 'en-in')
		setMoxCookie("lang", strLang)

	//alert($("#languageSelectedByUmesh").html());
	

	RedurectUrl(strLang);
}

function ChangeLanguage(dropMenu) {

 //debugger;
	var strLang = dropMenu.options[dropMenu.selectedIndex].value;
	removeMoxCookie("lang", "");
	if (strLang != 'en-in')
		setMoxCookie("lang", strLang)
	RedurectUrl(strLang);
}
function RedurectUrl(strLang) {

	var newUrl = '';
	var strSegment = window.location.pathname.substr(1).split("/");
	var checkLang = strSegment[0];

	//alert(strSegment);
	
	if (langCodeList.indexOf(checkLang) > -1) {
		if (strLang == "en-in") {
			strSegment = strSegment.slice(1);
			newUrl = window.location.protocol + "//" + window.location.host + '/' + strSegment.join("/");
		}

		else {
			strSegment[0] = strLang;
			var path = strSegment.join("/");
			if (path == strLang)
				newUrl = window.location.protocol + "//" + window.location.host + '/' + path + '/';
			else
				newUrl = window.location.protocol + "//" + window.location.host + '/' + path;
		}
	}
	else if (strLang == "en-in") {
	        newUrl = window.location.protocol + '//' + window.location.host + window.location.pathname;
	    }
	    else {
	        newUrl = window.location.protocol + '//' + window.location.host + '/' + strLang + window.location.pathname;
	    }
		

	window.location = newUrl;
}
function setMoxCookie(key, value) {
	var cookieExist = getMoxCookie(key)
	var expires = new Date();
	expires.setTime(expires.getTime() + 86400000);
	document.cookie = key + '=' + value + ';expires=' + expires.toUTCString() + ".;path=/";
	getMoxCookie(key);
}
function getMoxCookie(key) {
	var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
	return keyValue ? keyValue[2] : null;
}
function removeMoxCookie(name) {
	document.cookie = "lang=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
	
	//var x = getMoxCookie("lang");
	//alert(x);
}

