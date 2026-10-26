using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain;
using Xunit;
namespace MusicLabel.Tests
{
    public class PreisrechnerTryTests
    {
        [Fact]
        public void BerechneTryTicketPreis()
        {
            decimal grundpreis = 25m;
            decimal rabatt = 10m;
            decimal preis;

            bool ticketpreis = Preisrechner.TryBerechneTicketPreis(grundpreis, 4,rabatt, out preis);
            Assert.True(ticketpreis);
            Assert.Equal(90m,preis);
        }
        [Fact]
        public void BerechneTryTicketPreis2()
        {
            decimal grundpreis = 25m;
            decimal preis;

            bool ticketpreis = Preisrechner.TryBerechneTicketPreis(grundpreis, 0, 0, out preis);
            Assert.False(ticketpreis);
            Assert.Equal(0m, preis);
        }
        [Fact]
        public void BerechneTryTicketPreisMitFehler()
        {
            decimal grundpreis = 25m;
            decimal rabattInProzent = 101m;
            bool preis = Preisrechner.TryBerechneTicketPreis(grundpreis, 2, rabattInProzent, out _);
            Assert.False(preis);
        }
    }
}
