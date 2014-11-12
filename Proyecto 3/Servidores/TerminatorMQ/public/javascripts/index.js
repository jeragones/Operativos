$(document).ready(function () {
	/*setInterval(function() {
		$.ajax({ 
	        url: '/refresh',
	        type: 'GET',
	        contentType: 'application/json'
	    }).success(function(data) {
	    	$('#msgAverage').text(data.average+' msgs/s');
	    	$('#msgSize').text(data.size+' msgs');
	    	$('#msgTotal').text(data.total+' msgs');
	    });
	}, 1500);*/
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
	        url: '/worker',
	        type: 'POST',
	        contentType: 'application/json',
	        data: JSON.stringify({ chkWorker: $('#chkWorker').val(), 
	        					   numWorker: $('#spnWorker').val() })
	    });
	});

	$('#spnWorker').change(function() {
		if($('#spnWorker').val() > 10)
			$('#spnWorker').val(10);
		else if($('#spnWorker').val() < 1)
			$('#spnWorker').val(1);
	});
});