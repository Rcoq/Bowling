// See https://aka.ms/new-console-template for more information

using Bowling.Business;
using Bowling.Models;
using Bowling.Services;


//args = new string[] { "1", "2", "10", "0", "10", "4" };

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

    var gameService = new GameService();
    var game = gameService.Create(frameList);

    var scoringComputeSystem = new ScoringComputeSystem();
    scoringComputeSystem.ComputeGame(game);
}





