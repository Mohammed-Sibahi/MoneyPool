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

public class Pool
{
    public List<Participants> ParticipantsList { get; set; }
    public List<Rounds> RoundsList { get; set; }

    public int MonthlyAmount { get; set; }

    public Pool(List<Participants> participantsList, int monthlyAmount)
    {
        ParticipantsList = participantsList;
        MonthlyAmount = monthlyAmount;
        RoundsList = new List<Rounds>();
    }
    public void CalculateRounds()
    {
        Random random = new Random();

    }
}
