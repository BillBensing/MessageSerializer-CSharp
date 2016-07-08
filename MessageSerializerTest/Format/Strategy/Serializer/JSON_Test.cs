using MessageSerializer;
using MessageSerializer.Format.Strategy.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MessageSerializerTest.Format.Strategy.Serializer
{
    [TestClass]
    public class JSON_Test
    {
        private MyMessage _myMessage;
        private byte[] _buffer;
        private ISerializerStrategy _strategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _myMessage = new MyMessage() { message = "hello" };
            _strategy = new JSON();
        }

        [TestMethod]
        public void Serialize_object()
        {
            _buffer = _strategy.Serialize(_myMessage);
            //MyMessage test = _strategy.Deserialize(_buffer);
            //Assert.AreEqual(test, _myMessage);
        }
    }

    [Serializable]
    public class MyMessage
    {
        public string message { get; set; }
    }
}