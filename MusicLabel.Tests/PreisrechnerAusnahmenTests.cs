using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain.Entities;
using Xunit;

namespace MusicLabel.Tests
{
    public class PreisrechnerAusnahmenTests
    {

        [Theory]
        [InlineData(25.0,0)]
        [InlineData(-1,2)]
        public void BerechneTicketPreis(double grundpreis, int anzahl)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Preisrechner.BerechneTicketPreis((decimal)grundpreis, anzahl));
        }

        [Fact]
        public void BerechneTicketPreis_Test2()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Preisrechner.BerechneTicketPreis(25m, 2, 120m));
        }

        [Fact]
        public void BerechneAlbumPreis_Test1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Preisrechner.BerechneAlbumPreis(0, 1.50m));
        }

        [Fact]
        public void BerechneAlbumPreis_Test2()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Preisrechner.BerechneAlbumPreis(5, 1m, -5m));
        } 


    }
}
