$(document).ready(function () {
	$('#btnEnviar').click(function(){
		var msgs = $("#spnMessages").val();
		var i = 0;
		while(i < msgs) {
			$.ajax({ 
		        url: 'http://localhost:3000/api/post?message=1-App 3-12:23:23:123'
		    });
			i++;
		}
	});
});