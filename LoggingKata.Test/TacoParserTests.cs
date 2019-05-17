using System;
using System.Collections.Generic;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {


        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("")]
        [InlineData("8,6,TacoBell")]
        [InlineData("8,0,tacoBell")]
        [InlineData("75356,879345,cheese")]
        [InlineData("5.5,6.6,fred")]
        public void ShouldParse(string str)
        {
            // arrange
            TacoParser tacoParser = new TacoParser();



            //act
            ITrackable actual = tacoParser.Parse(str);



            //assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("0,abc,TacoBell")]
        [InlineData("abc,0,TacoBell")]
        [InlineData("abc,abc,TacoBell")]
        [InlineData("0,0,")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            // arrange
            TacoParser tacoParser = new TacoParser();



            //act
            ITrackable actual = tacoParser.Parse(str);



            //assert
            Assert.Null(actual);

        }
    }
}
