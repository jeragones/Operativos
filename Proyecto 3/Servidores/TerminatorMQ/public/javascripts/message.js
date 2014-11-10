$(document).ready(function () {
	setInterval(function() {
		$.ajax({ 
	        url: '/messages/refresh',
	        type: 'GET',
	        contentType: 'application/json'
	    }).success(function(data) {
	    	//alert(data);

	    	$('#pnlMessages').append('<div class="form-group col-xs-7 text-left">');
	    	if(data.client == 'App 1') {
	    		$('#pnlMessages').append('<div class="panel panel-info">');
	    	} else {
	    		$('#pnlMessages').append('<div class="panel panel-success">');
	    	}
	    	$('#pnlMessages').append('<div class="panel-heading">'+
	    								'<h3 class="panel-title">'+
	    									'<span class="fa fa-line-chart">'+data.client+'</span>'+
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
		    											'<td>'+data.num+'</td>'+
		    											'<td>'+data.time+'</td>'+
		    										'</tr>'+
		    									'</tbody>'+
		    								'</table>'+
		    							'</div>'+
	    							'</div>'+
	    						'</div>'+
	    					'</div>');
	    });
	}, 1500);
});