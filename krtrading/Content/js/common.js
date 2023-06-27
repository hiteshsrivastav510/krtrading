
    function CountryChangeSelection(country) {
       
        try {
            removeMoxCookie('lang', '');
        }
        catch (ex) {
        }
        var x = location.protocol + "//" + window.location.host;

        if (country == "bangladesh") {
            window.location.href = x + "/bangladesh/index.aspx";
        }
        else if (country == "bahrain") {
            window.location.href = x + "/bahrain/index.aspx";
        }
        else if (country == "nepal") {
            window.location.href = "/nepal/index.html";
        }
        else if (country == "uae") {
            window.location.href = x + "/uae/index.aspx";
        }
        else if (country == "india") {
            window.location.href = x + "/index.aspx";
        }
		else if (country == "saudiarabia") {
            window.location.href = x + "/saudi-arabia/index.aspx";
        }
		else if (country == "oman") {
            window.location.href = x + "/oman/index.aspx";
        }
		 else if (country == "ghana") {
            window.location.href = x + "/ghana/index.aspx";
        }
    }
