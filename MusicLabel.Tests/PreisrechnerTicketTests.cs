using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain.Entities;
using Xunit;
namespace MusicLabel.Tests
{
    public class PreisrechnerTicketTests
    {
        [Fact]
        public void BerechneTicketPreis()
        {
            decimal grundpreis = 25m;
            decimal preis = Preisrechner.BerechneTicketPreis(grundpreis, 4);
            Assert.Equal(100m, preis);
        }
        [Fact]
        public void BerechneTicketPreisMitRabatt()
        {
            decimal grundpreis = 25m;
            decimal rabatt = 10m;
            decimal preis = Preisrechner.BerechneTicketPreis(grundpreis, 4, rabatt);
            Assert.Equal(90m, preis);
        }
        [Fact]
        public void BerechneTicketPreisMitFanclubMitglied()
        {
            decimal grundpreis = 20m;
            bool istFanclubMitglied = true;
            decimal preis = Preisrechner.BerechneTicketPreis(grundpreis, 2, istFanclubMitglied);
            Assert.Equal(34, preis);
        }
        [Fact]
        public void BerechneTicketPreisMitKeinFanclubMitglied()
        {
            decimal grundpreis = 20;
            bool istFanclubMitglied = false;
            decimal preis = Preisrechner.BerechneTicketPreis(grundpreis, 2, istFanclubMitglied);
            Assert.Equal(40, preis);
        }

    }
}
