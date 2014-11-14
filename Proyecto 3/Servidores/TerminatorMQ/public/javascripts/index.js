$(document).ready(function () {
	$('#chkWorker').click(function() {
		$('#divWorker').val(!$('#chkWorker').val())
		
		if($('#chkWorker').val() == 0) {
			$('#chkWorker').val(1);
			$('#txtCheckbox').text('Stop Workers');
		}
		else {
			$('#chkWorker').val(0);
			$('#txtCheckbox').text('Start Workers');
		}

		$.ajax({ 
	        url: '/',
	        type: 'POST',
	        contentType: 'application/json',
	        data: JSON.stringify({ chkWorker: $('#chkWorker').val() })
	    });
	});

	$('#spnWorker').change(function() {
		if($('#spnWorker').val() > 10)
			$('#spnWorker').val(10);
		else if($('#spnWorker').val() < 1)
			$('#spnWorker').val(1);
	});

	$('#btnMessage').click(function() {
		$.ajax({ 
	        url: '/',
	        type: 'POST',
	        contentType: 'application/json',
	        data: JSON.stringify({ btnMessage: $('#btnMessage').val() })
	    });
	});
});