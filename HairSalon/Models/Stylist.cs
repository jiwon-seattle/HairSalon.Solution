using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      this.Clients = new HashSet<Client>();
    }
    public int StylistId {get; set;}
    public string StylistName {get; set;}
    public string MainSkill {get; set;}
    public string ExCompany {get; set;}
    public int WorkExperience {get; set;}
    public DateTime HiredDate {get; set;}
<<<<<<< HEAD
=======
//     public DateTime Appointment {get; set;}
//     public bool AppointmentSelect {get; set;}
>>>>>>> fd310b93d2bdc0b5828f02d50277fd79f1d002b2
    public virtual ICollection<Client> Clients {get; set;}
  }
}
