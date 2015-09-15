$(document).ready(function() { 
	var helpButton = document.getElementById("topNavbarButtons8");
	var topDDL = document.getElementById("topDropDown");
	var loginBtn = document.getElementById("loginButton");
	var loginDDL = document.getElementById("loginDropdown");

	helpButton.addEventListener("mouseover", helpHover);
	helpButton.addEventListener("click", helpClick);
	helpButton.addEventListener("mouseout", helpMouseOut);	
	topDDL.addEventListener("mouseover", topDDLover);
	topDDL.addEventListener("mouseout", topDDLoverOut);
	loginBtn.addEventListener("mouseover", loginHover);
	loginBtn.addEventListener("mouseout", loginMouseOut);
	loginDDL.addEventListener("mouseover", loginDDLover);
	loginDDL.addEventListener("mouseout", loginDDLoverOut);

	function helpHover() {	
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
	}

	function helpClick() {
		location.href = "help.html";		
	}

	setTimeout(helpMouseOut, 4000);

	function helpMouseOut() {			
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(500).fadeOut(0);		
	}

	function topDDLover() {	
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);	
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(0).fadeIn(0);			
	}

	function topDDLoverOut() {
		$("#topNavbar").find('.dropdown-menu').stop(false, false).delay(500).fadeOut(0);
	}

	//Login dropdown

	function loginHover() {
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
	}

	function loginMouseOut() {			
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(500).fadeOut(0);		
	}

	function loginDDLover() {
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(0).fadeIn(0);
	}

	function loginDDLoverOut() {
		$("#bigOne").find('#loginDropdown').stop(false, false).delay(500).fadeOut(0);
	}
});







