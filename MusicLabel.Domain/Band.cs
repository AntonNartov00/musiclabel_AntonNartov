using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public int Gruendungsjahr{ get; set; }
        public List<Musiker> Mitglieder { get; } = new List<Musiker>();
        public Band (string name, int gruendungsjahr)
        {
            Name = name;
            Gruendungsjahr = gruendungsjahr;
        }
        public void FuegeMitgliedHinzu(Musiker musiker)
        {
            Mitglieder.Add(musiker);
        }
    }
}
