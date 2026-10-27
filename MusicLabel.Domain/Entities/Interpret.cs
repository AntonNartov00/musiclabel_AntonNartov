using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain.Entities
{
    public class Interpret
    {
        public int Id { get; set; }

        public string Kuenstlername { get; set; }

        public string Genre { get; set; }

        public decimal Tagesgage { get; set; }

        public Interpret(string kuenstlername, string genre, decimal tagesgage)
        {
            if (string.IsNullOrWhiteSpace(kuenstlername))
            {
                throw new ArgumentException("Der Künstlername darf nicht leer sein.", nameof(kuenstlername));
            }
            if (string.IsNullOrWhiteSpace(genre))
            {
                throw new ArgumentException("Das Genre darf nicht leer sein.", nameof(genre));
            }
            if (tagesgage <= 0)
            {
                throw new ArgumentOutOfRangeException("Die Tagesgage muss größer als 0 sein.", nameof(tagesgage));
            }
            
            Kuenstlername = kuenstlername;
            Genre = genre;
            Tagesgage = tagesgage;
        }

        /// <summary>
        /// Die Methode gibt berechnungenGage.
        /// </summary>
        /// <param name="tage"></param>
        /// <returns></returns>
        public decimal BerechneGage(int tage)
        {
            if (tage <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tage), "Die Anzahl der Tage muss größer als 0 sein.");
            }
            return Tagesgage * tage;
        }
    }
}
