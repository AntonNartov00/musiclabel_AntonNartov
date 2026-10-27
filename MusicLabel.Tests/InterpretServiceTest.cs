using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain.BaseClasses;
using MusicLabel.Domain.Entities;
using MusicLabel.Domain.Interfaces;
using MusicLabel.Domain.Services;
using Xunit;
namespace MusicLabel.Tests
{
    public class InterpretServiceTest
    {
        private readonly IInterpretRepository _interpretrepository;
      
        [Fact]
        public void InterpretServiceAnlegen()
        {
            InterpretService interpret = new InterpretService(new FakeInterpretRepository(), new List<Interpret>());
            var interprets = interpret.Anlegen("Jonas", "klassik", 1201m);
            var idholen = interpret.HoleAlle();
            Assert.Equal(1,idholen.Count);
        }
        [Fact ]
        public void InterpretInvalidOperationException()
        {
            InterpretService service = new InterpretService(new FakeInterpretRepository(), new List<Interpret>());
            var interpret = service.Anlegen("Jonas", "Pop", 1201m);
            Assert.Throws<InvalidOperationException>(() => service.Anlegen("Jonas", "klassik", 1201m));
        }
        [Fact]
        public void InterpretNotFoundException()
        {
            InterpretService service = new InterpretService(new FakeInterpretRepository(), new List<Interpret>());
            Assert.Throws<InterpretNotFoundException>(() => service.HoleNachId(42));
        }
        [Fact]
        public void InterpretTagesgage()
        {
            InterpretService service = new InterpretService(new FakeInterpretRepository(), new List<Interpret>());
            var interprets = service.Anlegen("Anne", "rock", 1200m);
            var interpret = service.Anlegen("Luna", "schlager", 1231m);
            var tagesgage = service.BerechneGage(1, 3);
            Assert.Equal(3600m, tagesgage);
        }
        [Fact]
        public void InterpretZweiEinträge()
        {
            InterpretService service = new InterpretService(new FakeInterpretRepository(), new List<Interpret>());
            var interprets = service.Anlegen("Lukas", "blues", 1301m);
            var interpret = service.Anlegen("Lena", "jazz", 1231m);
            var einträge = service.HoleAlle();

            Assert.Equal(2, einträge.Count);
        }
    }
}
