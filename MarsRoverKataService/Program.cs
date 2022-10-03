// See https://aka.ms/new-console-template for more information

//  Mission Object
//  Rover: Position and Location (x,y, z) where Z N,S,E,W
//  Plateau: Grid of positions (x,y, Z)
//  FIrst Message: gridsize   MaxCoordinates maxx, maxy
//  CommandMessage: String of Chars L R M where L= left R=Right M=Move
//  1. Plateau SIze(5 5)   ---------------------->
//  2. Array RoverInstructions Objects where  2lines
//          roverinstruction => roverPostion
//          roverCommand   =>   set  of LRM
//   expected behaviours
//  turnleft, turnright, moveForward
using MarsRoverKataService;

Console.WriteLine("Welcome to Mars Mission, please provide inputs!");
Console.WriteLine("Press Enter when completed all Rover Commands");
List<string> listResults = new List<string>();
var inputPlateauSettings = new Plateau();
var _control = new Controller();

var plateauInput = Console.ReadLine();

if (!(plateauInput == "" || plateauInput == null))
{
    inputPlateauSettings.PlateauSettings(plateauInput);
    for (int i = 0; i <= inputPlateauSettings.MaxRoversAllowed(); i++)
    {
        var _rover = new Rover(i + 1);

        var input = Console.ReadLine();

        if (input == "" || input == null) { break; }

        string message = _rover.RoverSettings(input, inputPlateauSettings);

        var setInput = Console.ReadLine();
        if (setInput == "" || setInput == null)
        {
            message = "No command set for " + _rover.RoverName;
        }
        else
        {
            _control.SetCommands(setInput);
        }
        if (message == "Settings Applied Successfully")
        {
            listResults.Add(_control.Execute(_rover, inputPlateauSettings));
        }
        else
        {
            listResults.Add(message);
        }
    }
    foreach (string output in listResults)
        Console.WriteLine(output);
}


