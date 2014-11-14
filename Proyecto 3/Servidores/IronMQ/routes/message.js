// Modulos de la ruta
var express = require('express');
var iron_mq = require('iron_mq');
var data = require('./data');

var router = express.Router();

// Conexion con el servidor de colas IronMQ
var token = "2aps7Lb4F3hMYwtkaVj9xadlRwo";
var id = "545413c2b72d650009000009";
var imq = new iron_mq.Client({token: token, project_id: id, queue_name: queue});
var queue = imq.queue("inbox");

/* GET Message page */
router.get('/', function(req, res) {
	setInterval(function() {
		saveMessage(removeMessage);
	}, 1000);
	res.render('message', { title: 'Send Message' });
});

/* POST Message Page */
router.post('/', function(req, res) {
	data.get(function(data) {
		var numMessages = data.length;
		data.forEach( function(message) {
			console.log(message);
		});
	});
});

// Variable global
module.exports = router;