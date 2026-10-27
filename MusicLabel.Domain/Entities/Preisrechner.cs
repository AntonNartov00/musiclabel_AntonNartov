using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain.Entities
{

    public static class Preisrechner
    {
        private static decimal mitgliederRabatt = 15m;
        private static decimal rabattkeinmitglied = 0m;
        public static bool isFanclubMitglied { get; set; }

        /// <summary>
        ///  Die Methode berechnet den Ticketpreis basierend auf dem Grundpreis und der Anzahl der Tickets.
        /// </summary>
        /// <param name="grundpreis"></param>
        /// <param name="anzahl"></param>
        /// <returns></returns>
        public static decimal BerechneTicketPreis(decimal grundpreis, int anzahl)
        {
            if(grundpreis <= 0 || anzahl <= 0)
            {
                throw new ArgumentOutOfRangeException("Der Grundpreis oder die Anzahl ist zu niedrig.");
            }
            return grundpreis * anzahl;
        }

        /// <summary>
        ///  Die Methode berechnet den Ticketpreis basierend auf dem Grundpreis, der Anzahl der Tickets und einem Rabatt in Prozent.
        /// </summary>
        /// <param name="grundpreis"></param>
        /// <param name="anzahl"></param>
        /// <param name="rabattInProzent"></param>
        /// <returns></returns>
        public static decimal BerechneTicketPreis(decimal grundpreis, int anzahl, decimal rabattInProzent)
        {
           

            decimal ticketpreis = BerechneTicketPreis(grundpreis, anzahl);
            if(rabattInProzent < 0 || rabattInProzent >= 100)
            {
                throw new ArgumentOutOfRangeException("Der Rabatt ist zu niedrig oder zu hoch.");
            }
            decimal preis = ticketpreis * rabattInProzent / 100m;
            return ticketpreis - preis;
        }

        /// <summary>
        /// Die Methode berechnet den Ticketpreis basierend auf dem Grundpreis, der Anzahl der Tickets und ob der Käufer ein Fanclub-Mitglied ist.
        /// </summary>
        /// <param name="grundpreis"></param>
        /// <param name="anzahl"></param>
        /// <param name="istFanclubMitglied"></param>
        /// <returns></returns>
        public static decimal BerechneTicketPreis(decimal grundpreis, int anzahl, bool istFanclubMitglied)
        {

            decimal rabatt = 0m;

            if (istFanclubMitglied == true)
            {
                rabatt = mitgliederRabatt;
            }
            else
            {
                rabatt = rabattkeinmitglied;
            }
            decimal ticketpreis = BerechneTicketPreis(grundpreis, anzahl, rabatt);
            return ticketpreis;
        }

         /// <summary>
         /// Die Methode berechnet den Preis eines Albums basierend auf der Anzahl der Titel, dem Preis pro Titel und einem optionalen Rabatt in Prozent.
         /// </summary>
         /// <param name="anzahlTitel"></param>
         /// <param name="preisProTitel"></param>
         /// <param name="rabattInProzent"></param>
         /// <returns></returns>
        public static decimal BerechneAlbumPreis(int anzahlTitel, decimal preisProTitel, decimal? rabattInProzent = 0m)
        {
            if(anzahlTitel <= 0 || preisProTitel <= 0 || rabattInProzent < 0 || rabattInProzent > 100)
            {
                throw new ArgumentOutOfRangeException("Die Anzahl der Titel, der Preis pro Titel oder der Rabatt ist zu niedrig oder zu hoch.");
            }
            return anzahlTitel * preisProTitel * rabattInProzent ?? 0m;
        }

        /// <summary>
        /// Die Methode versucht, den Ticketpreis basierend auf dem Grundpreis, der Anzahl der Tickets und einem Rabatt in Prozent zu berechnen.
        /// </summary>
        /// <param name="grundpreis"></param>
        /// <param name="anzahl"></param>
        /// <param name="rabattInProzent"></param>
        /// <param name="preis">.</param>
        /// <returns></returns
        public static bool TryBerechneTicketPreis(decimal grundpreis, int anzahl, decimal rabattInProzent, out decimal preis)
        {

            if (anzahl <= 0 || grundpreis < 0 || rabattInProzent < 0 || rabattInProzent >= 100)
            {
                preis = 0m;
                return false;
            }

            preis = BerechneTicketPreis(grundpreis, anzahl,rabattInProzent);
            return true;
        }
    }

}
