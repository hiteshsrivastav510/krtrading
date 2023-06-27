		//STICK SOCIAL LINKS
		$footer = $('#socialBox');
		$win = $(window);
		var ipos = $footer.offset().top;
		var wpos, space;

		function stickpoint(e) {
		    wpos = $win.scrollTop();
		    space = $win.height();

		    if (wpos + space < ipos) {
		        $footer.addClass('fixedbox');
		    } else {
		        $footer.removeClass('fixedbox');
		    }
		}


		// this triggers the repositioning of the bar on all relevant events
		$(window).resize(stickpoint).scroll(stickpoint);

		$(document).ready(function() {

		    $('#searchBtn').click(function(e) {
		        e.stopPropagation();
		        $('.navLogin').addClass('showsearch');
		        $('.navigation ').addClass('pushleft');
		    });

		    $('#searchTxtBox').keyup(function() {
		        if ($('#searchTxtBox').val().length == 0) {
		            $('#searchTxtBox').parents('.searchTxt').removeClass('clear');
		        } else {
		            $('#searchTxtBox').parents('.searchTxt').addClass('clear');
		        }
		    });

		    $('#clearBtn').click(function(e) {
		        e.stopPropagation();
		        $('#searchTxtBox').val('');
		        $('#searchTxtBox').parents('.searchTxt').removeClass('clear');
		    });

		    $('#searchTxtBox').click(function(e) {
		        e.stopPropagation();
		    });

		    $('body').click(function(e) {
		        e.stopImmediatePropagation();
		        $('.navLogin').removeClass('showsearch');
		        $('.navigation').removeClass('pushleft');
				$('.languagebox ul').hide();
		    });

		    //@NAVIGATION
		    $('#navigationBtn').click(function(e) {
		       e.stopPropagation();
		        $('.navBar').toggleClass('showhide');
		        this.classList.toggle("active");
		        $('body').toggleClass('noScroll');
		        $('.vestigeOverlay').toggleClass('display');
		        $('header').toggleClass('contentbox hideonclick');
		    });

		    $('.navBar').click(function(e) {
		        e.stopPropagation();
		    });

		    $('body').click(function() {
		        $('.vestigeOverlay').removeClass('display');
		        $('.navBar').removeClass('showhide');
		        $('#navigationBtn').removeClass('active');
		        $('body').removeClass('noScroll');
		        $('header').removeClass('contentbox');
		    });

		    //SUBDROPDOWN MOBILE
    var isMobile = window.matchMedia("only screen and (max-width: 1200px)");
    if (isMobile.matches) {
		        $('.subdropdownbtn').click(function() {
		            $(this).parents('li').toggleClass('mobhighlight');
		            $(this).parents('li').siblings().removeClass('mobhighlight');
		        });

		        $('.dropdownlist h2').click(function() {
		            $(this).parent().siblings('li').find('.subdropdownlist').slideUp();
		            $(this).parent().find('.subdropdownlist').slideToggle();
		        });
		    }

		    //@LOGIN FORM
		    $('#login').click(function() {
		        $('.loginForm').addClass('showhide');
		        $('html, body').animate({
		            scrollTop: 0
		        }, 800);
		        $('body').toggleClass('noScroll');
		        $('.vestigeloginOverlay').toggleClass('display');
		    });
		    $('#loginPopup').click(function() {
		        $('.loginForm').addClass('showhide');
		        $('body').removeClass('noScroll');
		        $('.vestigeOverlay').removeClass('display');
		        $('#navigationBtn').removeClass("active");
		        $('.navBar').removeClass('showhide');
		        $('html, body').animate({
		            scrollTop: 0
		        }, 800);
		        $('body').toggleClass('noScroll');
		        $('.vestigeloginOverlay').toggleClass('display');
		    });

		    $('#closelogin').click(function() {
		        $('.loginForm').removeClass('showhide');
		        $('body').removeClass('noScroll');
		        $('.vestigeloginOverlay').removeClass('display');
		    });

		    $('.vestigeloginOverlay').click(function(e) {
		        $(this).removeClass('display');
		        $('.loginForm').removeClass('showhide');
		        $('body').removeClass('noScroll');
		    });

		    stickpoint();

		});