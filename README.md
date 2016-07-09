# MessageSerializer-CSharp
This is a Message Serializer built for Serializing/Deserializing messing into by arrays.  Use this library to prepare JSON, XML or Binary(.NET only) message formats for sending and receiving over the wire.  I built this to help with my RabbitMQ projects.

This library was inspired by the RabbitMQ tutorials [Michael Stephenson](http://app.pluralsight.com/author/michael-stephenson) created on [Pluralsight](https://app.pluralsight.com/library/courses/rabbitmq-dotnet-developers-pt2).

Download from Nuget [MessageSerializer](https://www.nuget.org/packages/MessageSerializer/)

## How To Use
You can serialize or deserialize based on provided a supplied enumerable value (MessageType) or a Content-Type string.

Current supported MIME types are:
* application/json
* application/octet-stream
* text/xml

### Serialize
You can select the type of message format you'd like to transport your object as.

Using the supplied MessageType enumerator:
````C#
var serializeMe = new SomeImportantObject();
byte[] messageBuffer = new Serializer().UseObject(serializeMe).SerializeAs(MessageType.JSON);
YourMethodForTransportingMessage(messageBuffer);
```
Using a Content-Type string:
````C#
var serializeMe = new SomeImportantObject();
byte[] messageBuffer = new Serializer().UseObject(serializeMe).SerializeAs("application/josn");
YourMethodForTransportingMessage(messageBuffer);
```

### Deserialize
When you receive a message, you can deserialize based on the format is was sent to you as.

Using the supplied MessageType enumerator:
````C#
byte[] deserializeMe = SomeReceivedMessage;
var usableObject = new SomeImportantObject();
useableObject = new Deserializer<SomeImportantObject>().UseBuffer(deserializeMe).DeserializeAs(MessageType.JSON);
DoSomethingImportant(useableObject);
```
Using a Content-Type string:
````C#
byte[] deserializeMe = SomeReceivedMessage;
var usableObject = new SomeImportantObject();
useableObject = new Deserializer<SomeImportantObject>().UseBuffer(deserializeMe).DeserializeAs("application/josn");
DoSomethingImportant(useableObject);
```

