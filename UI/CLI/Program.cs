using SmhiDataLibrary;


//  Using SmhiDataLibrary
//_______________________
LocationData locationData = new LocationData();
SmhiData smhiData = new SmhiData();

var jsonObject = smhiData.GetSmhiData(locationData.Gbg);
if (jsonObject == null)
{
    Console.WriteLine("the json string was empty!");
}

List<int> listOfTimesToFetch = new List<int>() { 6, 9, 12, 15, 18, 21 };

List<SmhiData.TimeSeries> timeSeries = jsonObject.timeSeries;

foreach (var time in timeSeries)
{
    if ((time.validTime.Day == DateTime.Now.Day || time.validTime.Day == DateTime.Now.Day + 1) && listOfTimesToFetch.Contains(time.validTime.Hour))
    {
        Console.WriteLine($"\nDate: {time.validTime.Day}  |  Time (hour): {time.validTime.Hour}");

        foreach (var p in time.parameters)
        {
            if (p.name == "t")
            {
                Console.WriteLine($"Temperature: {p.values[0]}");
            }
            if (p.name == "ws")
            {
                Console.WriteLine($"Windspeed: {p.values[0]}");
            }
            if (p.name == "gust")
            {
                Console.WriteLine($"Winds can reach: {p.values[0]}");
            }
            if (p.name == "wd")
            {
                double wd = p.values[0];
                string direction = "";

                if (wd >= 0 && wd < 45)
                    direction = "N to NE";
                else if (wd >= 45 && wd < 90)
                    direction = "NE to E";
                else if (wd >= 90 && wd < 135)
                    direction = "E to SE";
                else if (wd >= 135 && wd < 180)
                    direction = "SE to S";
                else if (wd >= 180 && wd < 225)
                    direction = "S to SW";
                else if (wd >= 225 && wd < 270)
                    direction = "SW to W";
                else if (wd >= 270 && wd < 315)
                    direction = "W to NW";
                else if (wd >= 315 && wd < 360)
                    direction = "NW to N";

                Console.WriteLine($"Wind direction is: {direction}");
            }
        }
    }
}


