const getWeather = function() {
    const zipCode = $("#zipCode").val();
    const validZipCode = (/^\d{5}$/).test(zipCode);
    if(validZipCode) {
        $.get(
            `https://api.openweathermap.org/data/2.5/weather?zip=${zipCode},US&appid=e6f7e1277c9ef82b57c0545fc4cc14f6&units=imperial`,
            function(data, textStatus, jqXHR) {
                $("#reportHeader").text(`Weather Report for ${data.name}`);
                $("#description").text(data.weather[0].description);
                $("#weatherIcon").attr("src", `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`);
                $("#currentTemp").text(`${data.main.temp} degrees Fahrenheit`);
            }
        );
    }
}