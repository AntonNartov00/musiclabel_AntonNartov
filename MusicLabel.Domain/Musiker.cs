using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain
{
    public class Musiker
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Instrument { get; set; }
        public int? BandId { get; set; }
        public Band? Band { get; set; }
        public Musiker(string vorname, string nachname, string instrument)
        {
            if(string.IsNullOrWhiteSpace(vorname))
            {
                throw new ArgumentException("Vorname darf nicht leer sein.", nameof(vorname));
            }
            if (string.IsNullOrWhiteSpace(nachname))
            {
                throw new ArgumentException("Nachname darf nicht leer sein.", nameof(nachname));
            }
            if (string.IsNullOrWhiteSpace(instrument))
            {
                throw new ArgumentException("Instrument darf nicht leer sein.", nameof(instrument));
            }

            Vorname = vorname;
            Nachname = nachname;
            Instrument = instrument;
        }

        /// <summary>
        /// Die Methode gibt Vorname und Nachname des Musikers zurück.
        /// </summary>
        /// <returns></returns>
        public string GibVollenNamen()
        {
            if(string.IsNullOrWhiteSpace(Vorname) || string.IsNullOrWhiteSpace(Nachname))
            {
                throw new InvalidOperationException("Vorname oder Nachname darf nicht leer sein.");
            }
            return $"{Vorname} {Nachname}";
        }
    }
}
