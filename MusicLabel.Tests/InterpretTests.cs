using System;
using System.Collections.Generic;
using System.Text;
using MusicLabel.Domain.Entities;
using Xunit;
namespace MusicLabel.Tests
{
    public class InterpretTests
    {
        [Fact]
        public void InterpretTest()
        {
            string kuenstlername = "Eisvogel";
            string genre = "Pop";
            var interpret = new Interpret(kuenstlername, genre, 1200m);
            Assert.Equal(kuenstlername, interpret.Kuenstlername);
            Assert.Equal(genre, interpret.Genre);
            Assert.Equal(1200m, interpret.Tagesgage);
        }

        [Fact]
        public void BerechneGageTest()
        {
         var interpret = new Interpret("Eisvogel", "Pop", 1200m);
            decimal berechneGage = interpret.BerechneGage(3);
            Assert.Equal(3600m,berechneGage);
        }

        [Fact]
        public void InteretException()
        {
            Assert.Throws<ArgumentException>(() => new Interpret("", "Pop", 1200m));
        }
    }
}
