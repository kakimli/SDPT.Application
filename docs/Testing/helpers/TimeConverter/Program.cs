// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, This is the TimeConverter!");
while (true)
{
  Console.WriteLine("Input a time: (e.g. 2001-08-30) - input 'quit' to quit");
  string timestr = Console.ReadLine();
  if (timestr.Equals("quit")) break;
  DateTime date = DateTime.Parse(timestr);
  DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  TimeSpan elapsedTime = date - Epoch;
  long res = (long) elapsedTime.TotalSeconds;
  Console.WriteLine("Timestamp: " + res);
  Console.WriteLine("-----------------------");
}
