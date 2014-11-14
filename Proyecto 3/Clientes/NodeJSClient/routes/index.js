// Modulos de la ruta
var express = require('express');
var iron_mq = require('iron_mq');
var https = require('https');

var router = express.Router();

// Conexion con el servidor de colas
var token = "2aps7Lb4F3hMYwtkaVj9xadlRwo";
var id = "545413c2b72d650009000009";
var imq = new iron_mq.Client({token: token, project_id: id, queue_name: queue});
var queue = imq.queue("inbox");

/* GET home page. */
router.get('/', function(req, res) {
  res.render('index', { title: 'Cliente App 2' });
});

/* POST home page */
router.post('/', function(req, res) {
	var num = req.body.spnMessage;
	var iron = req.body.chkIron;
	var terminator = req.body.terminator;

	if(iron == 1) {
		var producer = new Worker(queue, num);
		producer.process();
	}

  	res.render('index', { title: 'Cliente App 2' });
});

/* Funcion de cada Worker creado 
   queue: la cola de mensajes del servidor
   name: nombre del worker
*/
function Worker(queue, number) {
    var self = this;
    var n = number;

    this.process = function() {
    	var date = new Date();
		var time = date.getTime();
		var message = n+'-App 2-'+getTiempo();
    	queue.post(message, function(error, body) {});
    	n--;

	    if(n > 0) {
	    	setTimeout(self.process, 400);
	    }
    }
}

/* Funcion para obtener el tiempo en que se gestiona cada mensaje */
function getTiempo() {
	var date = new Date();
	var time = date.getHours()+':'+
			   date.getMinutes()+':'+
			   date.getSeconds()+':'+
			   date.getMilliseconds();
	return time;
}

// variable global
module.exports = router;