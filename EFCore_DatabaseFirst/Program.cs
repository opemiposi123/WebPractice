using EFCore_DatabaseFirst;
using EFCore_DatabaseFirst.Db;

static void Main(string[] args)
{
    DbFirstDemoContext dbFirstDemoContext = new DbFirstDemoContext();
    PersonService person = new PersonService(dbFirstDemoContext);
    person.AddPerson();
    person.UpdateRecord(1);
    var getpersonCount = person.GetPersonCount();
    Console.WriteLine($"Record count: {getpersonCount}");
    var getRecord = person.GetRecord(1);
    if (getRecord != null)
    {
        Console.WriteLine($"FullName: {getRecord.FirstName} { getRecord.LastName}");
        Console.WriteLine($"Birth Date: {getRecord.DateOfBirth.ToShortDateString()}");
    }
    person.DeleteRecord(1);
    Console.WriteLine($"Record count: {getpersonCount}");
 
}


