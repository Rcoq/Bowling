// See https://aka.ms/new-console-template for more information

using Bowling.Business;
using Bowling.Models;
using Bowling.Services;

//var parameters = new string[] { "1", "2", "10", "5", "10", "5" };
//var parameters = new string[] { "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10" };
//var parameters = new string[] { };
//var parameters = new string[] { "1","2","10","0","10","4","2","0","10","6","2","0","10","6","4","8","2","2","8","8"};
//var parameters = new string[] { "1", "2", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "2", "8", "8" };
//var parameters = new string[] { "1", "2", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "2", "10" };
//var parameters = new string[] { "2", "1", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "9", "10", "10" };
//var parameters = new string[] {"1", "1" , "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"};
var parameters = new string[] {"1","2","3","4","2","8", "1","2" };



if (args == null || args.Length < 1 || args.Length > 21)
{
    Console.WriteLine($"The number of parameters must be beteween 1 and 21. Actual value {args?.Length}");
}
else
{
    var shotService = new ShotService();
    var shotsList = shotService.CreateList(args);

    var frameService = new FrameService();
    var frameList = frameService.CreateList(shotsList);


    //scoringComputeSystem.Compute(game);
}





