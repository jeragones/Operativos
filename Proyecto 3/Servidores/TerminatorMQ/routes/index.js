var express = require('express');
var Workers = require('paralleljs');
var data = require('./data');
var api = require('./api');

var router = express.Router();
var queue = api.queue;
var sizes = api.sizes;
var average = 0;

/* GET Index Page*/
router.get('/', function(req, res) {
	res.render('index', {title: 'TerminatorMQ'});
});

/* POST Index Page Inicia los workers */
router.post('/', function(req, res) {
	var maxWorkers = req.body.selWorkers;
	console.log(queue.length);
	if(queue.length > 0) {
		var process = new Workers(queue, {maxWorkers: maxWorkers});
		process.map(save/*function(message) {
			//var message = queue.shift();
			
		}*/);
	}
	res.render('index', {title: 'TerminatorMQ'});
});

var save = function(message) {
	console.log(message);
	data.save(message.num, message.client, message.time);
}

/* GET Lleva el estado del servidor de mensajes */
router.get('/refresh', function(req, res) {
	var size = queue.length;
	average = Math.abs(size - average);
	res.send({size:size, average:average, total:sizes});
});

/* Elimina los mensajes almacenados en la BD */
var removeDB = function() {
	data.remove('App 1');
	data.remove('App 2');
}


/*
var quotes = [
  { author : 'Audrey Hepburn', text : "Nothing is impossible, the word itself says 'I'm possible'!"},
  { author : 'Walt Disney', text : "You may not realize it when it happens, but a kick in the teeth may be the best thing in the world for you"},
  { author : 'Unknown', text : "Even the greatest was once a beginner. Don't be afraid to take that first step."},
  { author : 'Neale Donald Walsch', text : "You are afraid to die, and you're afraid to live. What a way to exist."}
];


router.get('/quote/random', function(req, res) {
  var id = Math.floor(Math.random() * quotes.length);
  var q = quotes[id];
  res.json(q);
});


router.get('/quote/:id', function(req, res) {
  if(quotes.length <= req.params.id || req.params.id < 0) {
    res.statusCode = 404;
    return res.send('Error 404: No quote found');
  }  
var q = quotes[req.params.id];
  res.json(q);
});




router.get('/quote', function(req, res) {
	
	console.log('Mierda:      '+query.author);
  if(!req.body.hasOwnProperty('author') || 
     !req.body.hasOwnProperty('text')) {
    res.statusCode = 400;
    return res.send('Error 400: Post syntax incorrect.');
  } 
*/ 




















/*
router.get('/', function(req, res) {
	setInterval(function() {
		saveMessage(removeMessage);
	}, 1000);
	res.render('index', {title: 'Send Message', total: 0, data: []});
});

// POST index page

router.post('/', function(req, res) {
	var refresh = req.body.btnRefresh;
	var remove = req.body.btnRemove;

	if(refresh == 'Refrescar Mensajes') {
		data.get(function(collection) {
			var list = [];
			var numMessages = collection.length;
			collection.forEach( function(message) {
				list.push({id: message.num, client: message.client, time: message.time});
			}); 
			res.render('index', {title: 'Messages', total: numMessages, data: list});
		});
	} else if(remove == 'Eliminar Mensajes') {
		removeDB();
		res.render('index', {title: 'Messages', total: 0, data: []});
	}
});

// Elimina los mensajes del servidor
var removeMessage = function(client) {
	if(client)
		//queue.del(client, function(error, body) { });
}
*/

module.exports = router;