using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain
{

    public static class Preisrechner
    {
        private static decimal mitgliederRabatt = 15m;
        private static decimal rabattkeinmitglied = 0m;
        public static bool isFanclubMitglied { get; set; }
        public static decimal BerechneTicketPreis(decimal grundpreis, int anzahl)
        {
            return grundpreis * anzahl;
        }

        public static decimal BerechneTicketPreis(decimal grundpreis, int anzahl, decimal rabattInProzent)
        {
            decimal ticketpreis = BerechneTicketPreis(grundpreis, anzahl);
            decimal preis = ticketpreis * rabattInProzent / 100m;
            return ticketpreis - preis;
        }

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

        public static decimal BerechneAlbumPreis(int anzahlTitel, decimal preisProTitel, decimal? rabattInProzent = 0m)
        {
            return anzahlTitel * preisProTitel * rabattInProzent ?? 0m;
        }

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
