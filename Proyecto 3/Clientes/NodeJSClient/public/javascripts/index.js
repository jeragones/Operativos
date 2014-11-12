$(document).ready(function () {
	$('#chkTerminator').click(function() {
		if($('#chkTerminator').val() == 0) {
			$('#chkTerminator').val(1);
			$('#contentIP').append('<label for="txtIP" >Dirección IP:</label><br>'+
								   '<input id="txtIP" name="txtIP" required>');
		} else {
			$('#chkTerminator').val(0);
			$('#contentIP').empty();
		}
	});

	$('#chkIron').click(function() {
		if($('#chkIron').val() == 0) {
			$('#chkIron').val(1);
		} else {
			$('#chkIron').val(0);
		}
	});

	$('#btnEnviar').click(function() {
		if($('#chkTerminator').val() == 1) {
			
			var msgs = $("#spnMessage").val();
			var i = 1;
			while(i <= msgs) {
				var date = new Date();
				var time = date.getHours()+':'+
						   date.getMinutes()+':'+
						   date.getSeconds()+':'+
						   date.getMilliseconds();
				$.ajax({ 
			        url: 'http://'+$('#txtIP').val()+':3000/api/post?message='+i+'-App 2-'+time
			    });
				i++;
			}
		}
		$.ajax({ 
	        url: '/',
	        type: 'POST'/*,
	        ontentType: 'application/json',
	        data: JSON.stringify({ num: $('#spnMessage').val(),
	        					   iron: $('#chkIron').val()
	    	});*/
	    });
	});
});