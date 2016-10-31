let Record = (() => {
    let counter = 0;

    class Record{
        constructor(temperature, humidity, pressure, windSpeed){
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.windSpeed = windSpeed;
            this.id = counter++;
        }

        get weatherStatus(){
            return (this.temperature < 20 && (this.pressure < 700 || this.pressure > 900) && this.windSpeed > 25) ? "Stormy" : "Not stormy";
        }

        toString(){
            return `Reading ID: ${this.id}\n` + `Temperature: ${this.temperature}*C\n` + `Relative Humidity: ${this.humidity}%\n` + `Pressure: ${this.pressure}hpa\n` + `Wind Speed: ${this.windSpeed}m/s\n` + `Weather: ${this.weatherStatus}`
        }
    }
    return Record;
})();

let record1 = new Record(32, 66, 760, 12);
console.log(record1.toString());
let record2 = new Record(10, 40, 680, 30);
console.log(record2.toString());

