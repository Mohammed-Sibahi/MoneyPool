using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;


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
        DateTime currentDate = new DateTime(2024, 02, 01);
        foreach(var participant in ParticipantsList)
        {
            RoundsList.Add(new Rounds { Date = currentDate, Participant = participant });
            currentDate = currentDate.AddMonths(1);
        }
        RoundsList = RoundsList.OrderBy(round => round.Next()).ToList();
    }

    public void PrintResults()
    {
        Console.WriteLine($"Total amount for each participant: AED{ParticipantsList.Count * MonthlyAmount}");
        Console.WriteLine("Participants orderd by month (rounds): ");

        foreach(var round in RoundsList)
        {
            Console.WriteLine($"{round.Date:MMM d}: {round.Participant.Name}");
        }
    }


}
