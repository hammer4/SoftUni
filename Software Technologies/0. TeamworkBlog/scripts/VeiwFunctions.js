function showVeiw() {
	$("#veiwLogin").hide();
	$("#veiwRegister").hide();
	$("#veiwNewPost").hide();
	clearInputs ()
	
}

function clearInputs () {
	$('#confirmPassword').val('');
	$('#registerPass').val('');
	$('#fullName').val('');
	$('#registerUser').val('');
	$('#loginUser').val('');
	$('#loginPass').val('');
	$('#title').val('')
}

function showHideMenuLinks() {
	$('#linkHome').show();
	if (sessionStorage.getItem('authToken')== null){
		$("#linkLogin").show();
		$("#linkRegister").show();
		$("#linkNewPost").hide();
		$("#linkLogout").hide();

	}
	else{
		$("#linkLogin").hide();
		$("#linkRegister").hide();
		if(sessionStorage.getItem('username') == 'admin') {
			$("#linkNewPost").show();
		} else {
			$("#linkNewPost").hide();
		}
		$("#linkLogout").show();
	}

	if(sessionStorage.getItem('username') == 'admin') {
		$(".button-edit-post").show();
	}
}




$(function (){
	showHideMenuLinks();
	showVeiw()
	$("#linkHome").click(function(){$("#veiwHome").show();
									$("#veiwRegister").hide();
									$("#veiwNewPost").hide();
									$("#veiwLogin").hide();
									clearInputs ()
	});
	$("#linkLogin").click(function(){$("#veiwLogin").show();
									$("#veiwHome").hide();
									$("#veiwRegister").hide();
									$("#veiwNewPost").hide();
									clearInputs ()
	});
	$("#linkRegister").click(function(){$("#veiwRegister").show();
									$("#veiwHome").hide();
									$("#veiwLogin").hide();
									$("#veiwNewPost").hide();
									clearInputs ()
	});
	$("#linkNewPost").click(function(){$("#veiwNewPost").show();
									$("#veiwHome").hide();
									clearInputs ()
	});
	$("#linkLogout").click(function(){$("#veiwHome").show();
									$("#veiwNewPost").hide();
									sessionStorage.clear();
									showHideMenuLinks();
									showErrorBox("LOGOUT");
									clearInputs ()
	});
	$("#linkLogin2").click(function(){$("#veiwLogin").show();
									$("#veiwHome").hide();
									$("#veiwRegister").hide();
									$("#veiwNewPost").hide();
									clearInputs ()
	});
	$("#linkRegister2").click(function(){$("#veiwRegister").show();
									$("#veiwHome").hide();
									$("#veiwLogin").hide();
									$("#veiwNewPost").hide();
									clearInputs ()
	});

})
