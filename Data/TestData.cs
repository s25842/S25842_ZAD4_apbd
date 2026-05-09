using S25842_ZAD4.Models;

namespace S25842_ZAD4.Data;

public class TestData
{
    public static List<Room> Rooms=new List<Room>();
    public static List<Reservation> Reservations=new List<Reservation>();

    public static void createTestData()
    {
        Rooms.Add(new Room(1,"Room 1","1",1,129,true));
        Rooms.Add(new Room(2,"Room 2","1",1,128,false));
        Rooms.Add(new Room(3,"Room 3","2",1,127,false));
        Rooms.Add(new Room(4,"Room 4","1",1,126,true));
        Rooms.Add(new Room(5,"Room 5","2",1,125,true));
        Rooms.Add(new Room(6,"Room 6","1",1,122,true));
        Rooms.Add(new Room(7,"Room 7","2",1,124,true));
        Rooms.Add(new Room(8,"Room 8","1",1,123,true));
        
        Reservations.Add(new Reservation(1,1,"abc",
            "temat1",new DateTime(2020,01,01),
            new DateTime(2020,01,02),"planned"));
        Reservations.Add(new Reservation(2,2,"abcd",
            "temat2",new DateTime(2020,01,03),
            new DateTime(2020,01,07),"confirmed"));
        Reservations.Add(new Reservation(3,3,"abce",
            "temat1",new DateTime(2020,01,01),
            new DateTime(2020,01,02),"planned"));
        Reservations.Add(new Reservation(4,4,"abcf",
            "temat1",new DateTime(2020,01,01),
            new DateTime(2020,01,02),"planned"));
        Reservations.Add(new Reservation(5,5,"abcg",
            "temat1",new DateTime(2020,01,01),
            new DateTime(2020,01,02),"planned"));
        Reservations.Add(new Reservation(6,6,"abch",
            "temat1",new DateTime(2020,01,01),
            new DateTime(2020,01,02),"cancelled"));
    }
}