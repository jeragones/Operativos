var express = require('express');
//var worker = require('child_process');
var iron_mq = require('iron_mq');
var data = require('./data');

var token = "2aps7Lb4F3hMYwtkaVj9xadlRwo";
var id = "545413c2b72d650009000009";

var router = express.Router();
var imq = new iron_mq.Client({token: token, project_id: id, queue_name: queue});
var queue = imq.queue("inbox");

/* GET Message page */
router.get('/', function(req, res) {
	setInterval(function() {
		saveMessage(removeMessage);
	}, 1000);
	res.render('message', { title: 'Send Message' });
});

router.post('/', function(req, res) {
	data.get(function(data) {
		var numMessages = data.length;
		data.forEach( function(message) {
			console.log(message);
		});
	});
});

var removeMessage = function(id) {
	if(id)
		queue.del(id, function(error, body) { });
}

var saveMessage = function(callback) {
	queue.get_n(100, function(error, body) {
		if(body[0] !== undefined) {
			data.save(body[0].body,'funciona');
			callback(body[0].id);
		} else { 
			callback(null);
		}
	});
}

module.exports = router;