var express = require('express');
var url = require('url');

var router = express.Router();
var queue = [];
var sizes = 0;

/* Recibe los mensajes de los clientes y los almacena en la cola */ 
router.get('/post', function(req, res) {
	var urlParts = url.parse(req.url, true);
	var data = urlParts.query;
	var message = data.message.split('-');
	queue.push({num: message[0], client: message[1], time: message[2]});
	sizes = 1;
	res.send('Mensage Recibido');
});

/* Retorna el primer mensaje de la cola a los clientes */
router.get('/get', function(req, res) {
	if(queue.length > 0)
		res.json(queue.shift());
	else
		res.json({error: 'empty'});
});

module.exports = router;
module.exports.queue =  queue;
module.exports.sizes = sizes;