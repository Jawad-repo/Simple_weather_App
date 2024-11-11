using MyClassLib;

namespace MyTests
{
    public class WeatherForcastingTest
    {
        private readonly WeatherForcasting _weather;

        public WeatherForcastingTest()
        {
            _weather = new WeatherForcasting();
        }

        [Fact]
        public void WeatherForcasting_ShouldContainsObjects()
        {
            //Act
            var result = _weather.GetWeatherData();

            //Assert
            Assert.NotNull(result.Data[1].summary);
        }
    }
}
