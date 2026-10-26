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
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name darf nicht leer sein.", nameof(name));
            }
            if(gruendungsjahr < 1900 || gruendungsjahr > DateTime.Now.Year)
            {
                throw new ArgumentException("Das Gruendungsjahr ist ungültig.", nameof(gruendungsjahr));
            }

            Name = name;
            Gruendungsjahr = gruendungsjahr;
        }

        /// <summary>
        /// Die Methode fügt musiker hinzu.
        /// </summary>
        /// <param name="musiker"></param>
        public void FuegeMitgliedHinzu(Musiker musiker)
        {
            if(musiker == null)
            {
                throw new ArgumentNullException(nameof(musiker), "Musiker darf nicht null sein.");
            }
            Mitglieder.Add(musiker);
        }
    }
}
