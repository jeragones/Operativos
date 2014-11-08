$(document).ready(function () {
	setInterval(function() {
		$.ajax({ 
	        url: '/refresh',
	        type: 'GET',
	        contentType: 'application/json'
	    }).success(function(data) {
	    	$('#msgAverage').text(data.average+' msgs/s');
	    	$('#msgSize').text(data.size+' msgs');
	    	$('#msgTotal').text(data.total+' msgs');
	    });
	}, 1500);
});