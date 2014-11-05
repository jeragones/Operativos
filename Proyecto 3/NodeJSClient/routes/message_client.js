var express = require('express');
var worker = require('child_process');
var iron_mq = require('iron_mq');
var data = require('./data');

var token = "2aps7Lb4F3hMYwtkaVj9xadlRwo";
var id = "545413c2b72d650009000009";


var router = express.Router();
var imq = new iron_mq.Client({token: token, project_id: id, queue_name: queue});
var queue = imq.queue("inbox");
/* GET Message page */

router.get('/', function(req, res) {
	
	//data.remove('funciona');

	setInterval(function (){
 		queue.get_n(1, function(error, body) {
			if(body[0] !== undefined) {
				//console.log(body[0].body);
				data.save(body[0].body,'funciona');
				queue.del(body[0].id, function(error, body) {});
			} else {
				data.get();
				//console.log('Sin mensajes');
			}
		});	
	}, 1);

	res.render('message', { title: 'Send Message' });
});

router.get('/app2', function(req, res) {
	for(var i=0; i < 20; i++){
		queue.post('Prueba '+i+' Desde App2', function(error, body) { });	
	}

  	res.render('index', { title: 'View Messages' });
});

module.exports = router;

