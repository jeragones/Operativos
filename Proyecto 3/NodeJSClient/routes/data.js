var mongojs = require('mongojs');
var databaseUrl = 'mongodb://AdminDB:Admin123@ds051110.mongolab.com:51110/messagesdb';
var collection = ['Message'];
var db = mongojs.connect(databaseUrl, collection);

function getMessages() {
	db.Message.find({}, function(err, message) {
	  	if( err || !message) 
	  		console.log('No messages founded');
		else 
			message.forEach( function(messages) {
				console.log(messages);
			});
			console.log(message.length);
	});
}

function saveMessage(client, message) {
	db.Message.save({client: client, message: message}, function(err, saved) {
		if( err || !saved ) 
			console.log('Message not saved');
		else 
			console.log('Message saved');
	});
}

function removeMessage(client) {
	db.Message.remove({message: client}, function(err, removed) {
		if( err || !removed ) 
			console.log('Message not removed');
		else 
			console.log('Message removed');
	});	
}

module.exports = { get : getMessages, save: saveMessage, remove : removeMessage };