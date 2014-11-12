var express = require('express');
var iron_mq = require('iron_mq');
var data = require('./data');

var router = express.Router();

// Conexion con el servidor de colas IronMQ
var token = "2aps7Lb4F3hMYwtkaVj9xadlRwo";
var id = "545413c2b72d650009000009";
var imq = new iron_mq.Client({token: token, project_id: id, queue_name: queue});
var queue = imq.queue("inbox");


/* GET index page*/ 
router.get('/', function(req, res) {
	var consumer = new Worker();
	consumer.process();
	res.render('index', {title: 'Send Message', total: 0, data: []});
});

/* POST index page*/ 
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

function Worker() {
    var self = this;
    
    this.process = function() {
	    saveMessage(removeMessage);
        setTimeout(self.process, 500);
    }
}

// Elimina los mensajes del servidor
var removeMessage = function(client) {
	if(client)
		queue.del(client, function(error, body) { });
}

// Obtiene los mensajes del servidor
var saveMessage = function(callback) {
	queue.get_n(100, function(error, body) {
		if(body[0] !== undefined) {
			var tmp = body[0].body.split('-');
			data.save(tmp[0], tmp[1], tmp[2]);
			callback(body[0].id);
		} else { 
			callback(null);
		}
	});
}

// Elimina los mensajes almacenados en la BD
var removeDB = function() {
	data.remove('App 1');
	data.remove('App 2');
}

module.exports = router;