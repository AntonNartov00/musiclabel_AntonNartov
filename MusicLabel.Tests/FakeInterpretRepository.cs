using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain.Entities;
using MusicLabel.Domain.Interfaces;
using Xunit;
namespace MusicLabel.Tests
{
    public class FakeInterpretRepository:IInterpretRepository
    {
        private readonly List<Interpret> reader = new List<Interpret>();
        public List<Interpret> HoleAlle()
        {
            return new List<Interpret>();
        }
        public Interpret? HoleNachId(int id)
        {
            return reader.FirstOrDefault(r => r.Id == id);
        }
        public void Hinzufuegen(Interpret interpret)
        {
            interpret.Id = reader.Count + 1;
            reader.Add(interpret);
        }
        public bool ExistiertName(string kuenstlername)
        {
            return true;
        }
    }
}
