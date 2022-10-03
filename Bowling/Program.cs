// See https://aka.ms/new-console-template for more information

////var i = 0;
////var score = 0;
////while (i < shotsList.Count-2)
////{

////    if (shotsList[i] != 10 )
////    {
////        if (i + 1 < shotsList.Count && shotsList[i] > 0 && shotsList[i + 1] == 10 )
////        {
////            Console.WriteLine($"Error : bad paramater {shotsList[i]} + {shotsList[i + 1]} = {shotsList[i] + shotsList[i + 1]}, value is more than 10");
////            Environment.Exit(1);
////        }
////        else if(i + 1 < shotsList.Count && (shotsList[i] + shotsList[i + 1] > 10))
////        {
////            Console.WriteLine($"Error : bad paramater {shotsList[i]} + {shotsList[i + 1]} = {shotsList[i] + shotsList[i + 1]}, value is more than 10");
////            Environment.Exit(1);
////        }
////        else if (i + 1 < shotsList.Count && (shotsList[i] + shotsList[i + 1] == 10))
////        {
////            score += shotsList[i] + shotsList[i + 1];
////            if (i + 2 < shotsList.Count) score += shotsList[i + 2];
////        }
////        else
////        {
////            score += shotsList[i];
////            if (i + 1 < shotsList.Count) score += shotsList[i + 1];
////        }

////        i +=2;
////    }
////    else
////    {
////        score += 10;
////        if (i+1 < shotsList.Count) score += shotsList[i + 1];
////        if (i+2 < shotsList.Count) score += shotsList[i + 2];

////        i++;
////    }
////    Console.WriteLine($"score {score} ");

////}

////Console.WriteLine("good");


////Console.WriteLine(scoringComputeSystem.ValidateGame(args));


//using Bowling;
//using Bowling.Services;
//using System.Diagnostics.Metrics;

////var shootArray = new int[] { 2, 4, 10, 5, 3 };
////var shootArray = new int[] { 0,10,2, 4, 10, 0, 9,0,0,10 };
////var shootArray = new int[] { 10,7,9,0, 10, 2, 4, 10, 0, 9, 0, 0, 10,9,10 };
////var shootArray = new int[] { 10,2,3,7,3,10,0,10,5 };




//var validateGameService = new ValidateGameService();
//var scoringComputeSystem = new ScoringComputeSystem(validateGameService);

//Console.WriteLine(scoringComputeSystem.GameIsValid(args));





using Bowling.Business;
using Bowling.Services;

//var parameters = new string[] { "1", "2", "10", "5", "10", "5" };
//var parameters = new string[] { "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10" };
//var parameters = new string[] { };
//var parameters = new string[] { "1","2","10","0","10","4","2","0","10","6","2","0","10","6","4","8","2","2","8","8"};
//var parameters = new string[] { "1", "2", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "2", "8", "8" };
//var parameters = new string[] { "1", "2", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "2", "10" };
var parameters = new string[] { "2", "1", "10", "0", "10", "4", "2", "0", "10", "6", "2", "0", "10", "6", "4", "8", "2", "9", "10", "10" };

var validateGameService = new ValidateGameService();
var gameBuilder = new GameBuilder(validateGameService);

try
{
    var game = gameBuilder.Build(parameters);
    var scoringComputeSystem = new ScoringComputeSystem();


}
catch (ArgumentNullException e)
{
    Console.WriteLine("Invalid game : {0} ", e.Message);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Invalid game : {0} {1}", e.GetType().Name, e.Message);
}
catch (FormatException e)
{
    Console.WriteLine("Invalid game : {0} ", e.Message);
}


