$(document).ready(function () {
	$('#chkTerminator').click(function() {
		if($('#chkTerminator').val() == 0) {
			//$('#chkTerminator').val(1);
			$('#contentIP').append('<label for="txtIP" >Dirección IP:</label><br>'+
								   '<input id="txtIP" name="txtIP" required>');
		} else {
			//$('#chkTerminator').val(0);
			$('#contentIP').empty();
		}
	});
/*
	$('#chkIron').click(function() {
		if($('#chkIron').val() == 0) {
			$('#chkIron').val(1);
		} else {
			$('#chkIron').val(0);
		}
	});

	$('#btnEnviar').click(function() {
		$.ajax({ 
	        url: '/post',
	        type: 'POST',
	        contentType: 'application/json',
	        data: JSON.stringify({ termiinator: $('#chkTerminator').val(), 
	        					   iron: $('#chkIron').val()
	    });
	});
*/
});