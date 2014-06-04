using System;
using System.Net;

namespace HabitRPG.Client
{
  public class HabitRpgConfiguration
  {
    public Guid ApiToken { get; set; }

    public Guid UserId { get; set; }

    public Uri ServiceUri { get; set; }
  }
}
