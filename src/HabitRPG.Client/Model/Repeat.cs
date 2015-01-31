using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
  public class Repeat
  {
    public Repeat()
    {
      Monday = true;
      Tuesday = true;
      Wednesday = true;
      Thursday = true;
      Friday = true;
      Saturday = true;
      Sunday = true;
    }

    [JsonProperty("m")]
    public bool Monday { get; set; }

    [JsonProperty("t")]
    public bool Tuesday { get; set; }

    [JsonProperty("w")]
    public bool Wednesday { get; set; }

    [JsonProperty("th")]
    public bool Thursday { get; set; }

    [JsonProperty("f")]
    public bool Friday { get; set; }

    [JsonProperty("s")]
    public bool Saturday { get; set; }

    [JsonProperty("su")]
    public bool Sunday { get; set; }
  }
}


