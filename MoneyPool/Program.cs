using System;
using System.Collections.Generic;
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
    public Participants Participant { get; set; }
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
        DateTime currentDate = new DateTime(2024, 2, 1);

        List<Participants> shuffledParticipants = ParticipantsList.OrderBy(_ => random.Next()).ToList();

        foreach (var participant in shuffledParticipants)
        {
            RoundsList.Add(new Rounds { Date = currentDate, Participant = participant });
            currentDate = currentDate.AddMonths(1);
        }
    }

    public void PrintResults()
    {
        Console.WriteLine($"Total amount for each participant: AED{ParticipantsList.Count * MonthlyAmount}");
        Console.WriteLine("Participants ordered by month (rounds): ");

        foreach (var round in RoundsList)
        {
            Console.WriteLine($"{round.Date:MMM d}: {round.Participant.Name}");
        }
    }

    public string Serialize()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of pool participants:");
        int Number = int.Parse(Console.ReadLine());

        List<Participants> participantsList = new List<Participants>();

        for (int i = 1; i <= Number; i++)
        {
            Console.WriteLine($"Enter the name of participant {i}");
            string participantName = Console.ReadLine();
            participantsList.Add(new Participants(participantName, i));
        }

        Console.WriteLine("Enter the monthly amount for the pool:");
        int monthlyAmount = int.Parse(Console.ReadLine());

        Pool moneyPool = new Pool(participantsList, monthlyAmount);
        moneyPool.CalculateRounds();
        moneyPool.PrintResults();

        string serializedData = moneyPool.Serialize();
        Console.WriteLine("\nSerialized Data: \n");
        Console.WriteLine(serializedData);
    }
}
