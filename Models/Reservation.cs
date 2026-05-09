namespace S25842_ZAD4.Models;

public class Reservation
{
    public int Id{get;set;}
    public int RoomId{get;set;}
    public string OrganizerName{get;set;}
    public string Topic{get;set;}
    public DateTime StartTime{get;set;}
    public DateTime EndTime{get;set;}
    public string Status{get;set;}

    public Reservation(){}
    
    
    public Reservation(int id, int roomId,
        string OrganizerName, string topic,
        DateTime startTime, DateTime endTime,
        string status) 
    {
        this.Id = id;
        this.RoomId = roomId;
        this.OrganizerName = OrganizerName;
        this.Topic = topic;
        this.StartTime = startTime;
        this.EndTime = endTime;
        this.Status = status;
    }
}