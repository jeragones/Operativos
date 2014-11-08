var express = require('express');
var data = require('./data');

var router = express.Router();

/* GET index page*/ 
router.get('/', function(req, res) {
	res.render('message', {title: 'TerminatorMQ Messages'});
});

router.get('/refresh', function(req, res) {
	data.get(function(collection) {
		var list = [];
		var numMessages = collection.length;
		collection.forEach( function(message) {
			list.push({num: message.num, client: message.client, time: message.time});
		}); 
		res.send({total: numMessages, data: list});	
	});
});

/* POST index page*/ 
router.post('/', function(req, res) {
	var remove = req.body.btnRemove;
	removeDB();
	res.render('index', {title: 'Messages', total: 0, data: []});
});

// Elimina los mensajes almacenados en la BD
var removeDB = function() {
	data.remove('App 1');
	data.remove('App 2');
}

module.exports = router;