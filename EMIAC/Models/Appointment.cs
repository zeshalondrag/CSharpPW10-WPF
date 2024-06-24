using System;

public class Appointment
{
    public int ID_Appointments { get; set; }
    public int? Patient_ID { get; set; }
    public int Doctor_ID { get; set; }
    public DateTime AppoitmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public int? Statuses_ID { get; set; }
}
