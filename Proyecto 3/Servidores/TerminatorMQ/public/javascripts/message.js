$(document).ready(function () {
	setInterval(function() {
		$.ajax({ 
	        url: '/message/refresh',
	        type: 'GET',
	        contentType: 'application/json'
	    }).success(function(data) {
	    	$('#msgTotal').html("<h2>"+data.total+"</h2>");
	    	/*$('#pnlMessages').empty();
	    	
	    	data.data.each(function(message) {
	    		$('#pnlMessages').append('<div class="form-group col-xs-7 text-left">');
		    	if(message.client == 'App 1') {
		    		$('#pnlMessages').append('<div class="panel panel-info">');
		    	} else {
		    		$('#pnlMessages').append('<div class="panel panel-success">');
		    	}
		    	$('#pnlMessages').append('<div class="panel-heading">'+
		    								'<h3 class="panel-title">'+
		    									'<span class="fa fa-line-chart">'+message.client+'</span>'+
		    								'</h3>'+
			    							'<div class="panel-body">'+
			    								'<table class="table table-user-information">'+
			    									'<thead>'+
			    										'<tr>'+
			    											'<td>'+
			    												'<strong>ID</strong>'+
			    											'</td>'+
			    											'<td>'+
			    												'<strong>Hora</strong>'+
			    											'</td>'+
			    										'</tr>'+
			    									'</thead>'+
			    									'<tbody>'+
			    										'<tr>'+
			    											'<td>'+message.num+'</td>'+
			    											'<td>'+message.time+'</td>'+
			    										'</tr>'+
			    									'</tbody>'+
			    								'</table>'+
			    							'</div>'+
		    							'</div>'+
		    						'</div>'+
		    					'</div>');
	    	});
	    	*/
	    });
	}, 1500);
});