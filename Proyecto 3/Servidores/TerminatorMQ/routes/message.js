// Modulos de la ruta
var express = require('express');
var data = require('./data');

var router = express.Router();

/* GET index page */ 
router.get('/', function(req, res) {
	data.get(function(collection) {
		var list = [];
		var numMessages = collection.length;
		collection.forEach( function(message) {
			list.push({id: message.num, client: message.client, time: message.time, server: message.server});
		}); 
		res.render('message', {title: 'Messages', total: numMessages, data: list});
	});
});

/* POST index page */
router.post('/', function(req, res) {
	var remove = req.body.btnRemove;
	removeDB();
	res.render('message', {title: 'Messages', total: 0, data: []});
});

/* Refresca la pagina de mensajes cada cierto tiempo */
router.get('/refresh', function(req, res) {
	data.get(function(collection) {
		var list = [];
		var numMessages = collection.length;
		collection.forEach( function(message) {
			list.push({num: message.num, client: message.client, time: message.time, server: message.server});
		}); 
		res.send({total: numMessages, data: list});	
	});
});

// Elimina los mensajes almacenados en la BD
var removeDB = function() {
	data.remove('App 1');
	data.remove('App 2');
}

// Variable global
module.exports = router;