namespace Lib;

public class Record
{
    public string athleteId { get; set; }
    public string fullName { get; set; }
    public string team { get; set; }
    public int resultSeconds { get; set; }
    
    public Record(){}

    public Record(string id, string fullName, string team, int resultSeconds)
    {
        athleteId = id;
        this.fullName = fullName;
        this.team = team;
        this.resultSeconds = resultSeconds;
    }

    public override string ToString()
    {
        return $"{athleteId} - {fullName} - {team} -  {resultSeconds}";
    }
}