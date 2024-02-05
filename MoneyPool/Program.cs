using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using System.Text.Json;


public class Participants
{
    public int Number { get; set; }
    public string Name { get; set; }

    public Participants(string name, int number)
    {
        Number = number;
        Name = name;
    }
}

public class Rounds
{
    public DateTime Date { get; set; }
    public Participants? Participant { get; set; }
}
