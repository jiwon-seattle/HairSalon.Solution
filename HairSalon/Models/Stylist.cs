using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      this.Stylist = new HashSet<Stylist>();
    }
    public int StylistId {get; set;}
    public string StylistName {get; set;}
    public string MainSkill {get; set;}
    public string ExCompany {get; set;}
    public int WorkExperience {get; set;}
    public DateTime HiredDate {get; set;}
    public virtual ICollection<Client> Clients {get; set;}
  }
}