using RestSharp;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Collections;


namespace WeatherAPITests{

    public class WeatherAPIImplemenntation{
        private const string latitide = "26.20";
        private const string longitude ="28.04";
        private const string BasePath = "https://api.open-meteo.com/v1/";
        private RestClient client =  new RestClient(BasePath);
        private RestRequest request = new RestRequest("forecast?latitude=" + latitide+"&longitude="+longitude+"&hourly=temperature_2m");
        WeatherObject result;



        [Step("call the weather api for johannesburg using the latidue and logitude location")]
        public void CallWeatherAPI(){
            // result = client.GetAsync<Dictionary<string, Object> >(request).GetAwaiter().GetResult();
            result = client.GetAsync<WeatherObject>(request).GetAwaiter().GetResult();

        }


        [Step("verify that the correction loaction is called.")]
        public void verifyCorrectLocation(){

            // result.GetValueOrDefault("latitude").ToString().Should().Be("26.2");
            // result.GetValueOrDefault("longitude").ToString().Should().Be("28.0");

            result.latitude.Should().Be(26.2);
            result.longitude.Should().Be(28.0);
        }


        [Step("verify the correct time zone")]
        public void VerifyCorrectTimeZone(){

            // result.GetValueOrDefault("timezone").ToString().Should().Be("GMT");
            result.timezone.Should().Be("GMT");

            
 
       }

        [Step("verify the elevation")]    
        public void VerifyElevation(){

            // result.GetValueOrDefault("elevation").ToString().Should().Be("413.0");
            result.elevation.Should().Be(413.0);


        }    

        [Step("verify that the 24 hour weather prediction is returned by the api call")]
        public void Verify24WeatherPreditoins(){
            // result.GetValueOrDefault("hourly").GetValueOrDefault().Should().Be(413.0);
            
            result.hourly.GetValueOrDefault("time").Should().BeOfType<ArrayList>();
            result.hourly.GetValueOrDefault("temperature_2m").Should().BeOfType<ArrayList>();


        }

    }




}