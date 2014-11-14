// Modulos de la ruta
var express = require('express');
var url = require('url');
var sq = require('simplequeue');

// Variables globales del modulo
var router = express.Router();
var queue = sq.createQueue();

/* Recibe los mensajes de los clientes y los almacena en la cola */ 
router.get('/post', function(req, res) {
	var urlParts = url.parse(req.url, true);
	var data = urlParts.query;
	var message = data.message.split('-');
	queue.putMessage({num: message[0], client: message[1], time: message[2], server: 'TerminatorMQ'});
	
	res.send('Mensage Recibido');
});

/* Retorna el primer mensaje de la cola a los clientes */
router.get('/get', function(req, res) {
	if(queue.length > 0)
		res.json(queue.getMessageSync());
	else
		res.send({error: 'empty'});
}); 

// Variables globales
module.exports = router;
module.exports.queue =  queue;