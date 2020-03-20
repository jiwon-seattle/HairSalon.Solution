using System;

namespace HairSalon.Models
{
  public class Client
  {
    public int ClientId {get; set;}
    public int StylistId {get; set;}
    public virtual Stylist Stylist {get; set;}
    public string ClientName {get; set;}
    public string ClientAddress {get; set;}
    public DateTime LastVisitDate {get; set;}
    public DateTime Birthday {get; set;}

  }
}