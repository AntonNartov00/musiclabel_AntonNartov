using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain;
using Xunit;
namespace MusicLabel.Tests
{
    public class PreisrechnerAlbumTests
    {
        [Theory]
        [InlineData(10,1.50,0)]
        [InlineData(10,1.50,20)]
        public void BerechneAlbumPreis(int anzahlTitel, double preisprotitel, double rabatt)
        {
            decimal preis = Preisrechner.BerechneAlbumPreis(anzahlTitel, (decimal)preisprotitel, (decimal)rabatt );
            Assert.Equal(anzahlTitel * (decimal)preisprotitel * (decimal)rabatt, preis);
        }
        [Fact]
        public void BerechneAlubmPreisMitRabatt()
        {
            decimal preisproTitel = 1.50m;
            decimal rabatt = 0.50m;
            decimal preis = Preisrechner.BerechneAlbumPreis(10, preisproTitel, rabatt);
            Assert.Equal(7.5m, preis);
        }
    }
}
