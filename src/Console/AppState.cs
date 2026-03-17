using System.Globalization;
using Lib;

namespace App;

public class AppState
{
    public Record[] records = null;
    
    public SortStatistics currentStat = new SortStatistics();
    
    public int count => records.Length;

    public void InitCollection()
    {
        records = new Record[0];
        currentStat = new SortStatistics();
        Console.WriteLine("New collection initialized");
    }

    public void AddRecord(Record record)
    {
        if (records == null)
        {
            Console.WriteLine("You need to initialize collection");
            return;
        }
        Record[] newRecords = new Record[count + 1];

        for (int i = 0; i < count; i++)
        {
            newRecords[i] = records[i];
        }

        newRecords[count] = record;

        records = newRecords;

        Console.WriteLine("Record added");
    }

    public void RemoveRecord(string id)
    {
        if (records == null || records.Length == 0)
        {
            Console.WriteLine("Empty collection");
            return;
        }
        Record[] newRecords = new Record[count - 1];
        bool isFound = false;

        for (int i = 0, j = 0; i < count; i++, j++)
        {
            if (id == records[i].athleteId)
            {
                isFound = true;
                j--;
            }

            newRecords[j] = records[i];
        }

        if (isFound)
        {
            records = newRecords;
            Console.WriteLine("Record deleted");
            return;
        }

        Console.WriteLine("Not found");
    }

    public void PrintCollection()
    {
        if (records == null || records.Length == 0)
        {
            Console.WriteLine("Empty collection");
            return;
        }
        foreach (Record record in records)
        {
            Console.WriteLine(record);
        }
    }

    public void GenerateControlData()
    {
        if (records == null)
        {
            Console.WriteLine("You need to initialize collection");
            return;
        }
        
        Record[] newrecords = new[]
        {
            new Record("1", "Name1", "Team1", 11),
            new Record("2", "Name2", "Team2", 8),
            new Record("3", "Name3", "Team3", 13),
            new Record("4", "Name4", "Team4", 13),
            new Record("5", "Name5", "Team5", 18),
            new Record("6", "Name6", "Team6", 3),
            new Record("7", "Name7", "Team7", 5),
            new Record("8", "Name8", "Team8", 11),
            new Record("9", "Name9", "Team9", 9),
            new Record("10", "Name10", "Team10", 21),
            new Record("11", "Name11", "Team11", 18),
            new Record("12", "Name12", "Team12", 10),
            new Record("13", "Name13", "Team13", 8)
        };

        foreach (Record rec in newrecords)
        {
            AddRecord(rec);
        }

        Console.WriteLine("Collection updated");
    }

    public void SortCollection()
    {
        if (records == null || records.Length == 0) 
        {
            Console.WriteLine("Empty collection");
            return;
        }
        currentStat = new SortStatistics();
        Sorter.BucketSort(records, currentStat);

        Console.WriteLine("Collection sorted");
    }

    public void PrintIntermediateSteps()
    {
        if (records == null || records.Length == 0)
        {
            Console.WriteLine("Empty collection");
            return;
        }
        
        currentStat = new SortStatistics();
        Console.WriteLine($"Find max value in the array & create collection of buckets: " +
                          $"max = {Sorter.SearchMax(records, currentStat)}, " +
                          $"size = {Sorter.SearchMax(records, currentStat) / 10 + 1}\n");
        
        Console.WriteLine("Insert values into linked list:"); 
        ListNode[] buckets = DevideInFive();

        Console.WriteLine("\nInsert values into array:");
        Sorter.CopyToArray(records, buckets, currentStat);

        foreach (Record record in records)
        {
            Console.WriteLine(record);
        }
    }

    public void PrintStatistics()
    {
        Console.WriteLine(currentStat);
    }

    public ListNode[] DevideInFive()
    {
        if (records == null || records.Length == 0)
        {
            Console.WriteLine("Empty collection");
            return null;
        }
        
        int k = Sorter.SearchMax(records, currentStat) / 5 + 1;
        ListNode[] buckets = new ListNode[k];
        
        for (int i = 0; i < records.Length; i++)
        {
            int index = records[i].resultSeconds / 5;

            Sorter.InsertInCorrectPos(ref buckets[index], records[i], currentStat);
        }

        int maxOfCount = 0;
        int indexOfMax = 0;
        for (int i = 0; i < buckets.Length; i++)
        {
            Console.WriteLine($"{i*5} -> {(i + 1)*5}:");
            ReadLinkedList(buckets[i]);
            Console.WriteLine($"Аvarage: {AvarageForFifth(buckets[i], out int count)}");
            if (count > maxOfCount)
            {
                maxOfCount = count;
                indexOfMax = i;
            }
        }

        Console.WriteLine($"{indexOfMax*5} -> {(indexOfMax + 1)*5} - maximum of count: {maxOfCount}");
        return  buckets;
    }

    public void FirstToThirdPlace()
    {
        if (records == null || records.Length < 3)
        {
            Console.WriteLine("Not enough records");
            return;
        }
        
        SortCollection();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i+1}. {records[i]}");
        }
    }

    public double AvarageForFifth(ListNode node, out int count)
    {
        double summ = 0;
        count = 0;
        while (node != null)
        {
            summ += node.val.resultSeconds;
            count++;
            node = node.next;
        }
        return  Math.Round(summ / count, 3);
    }

    public void ReadLinkedList(ListNode node)
    {
        while (node != null)
        {
            Console.WriteLine(node.val);
            node = node.next;
        }
    }
}