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
var inputPlateauSettings = new Plateau();
inputPlateauSettings.PlateauSettings(Console.ReadLine());
var inputRoverSettings = new Rover();
inputRoverSettings.RoverSettings(Console.ReadLine());
var control = new Controller();
control.SetCommands(Console.ReadLine());

var result = control.Execute(inputPlateauSettings, inputRoverSettings);
Console.WriteLine(result);

//var initialRoverPosition2 = new Rover();
//initialRoverPosition2.RoverSettings(Console.ReadLine());

//var commands2 = new Controller();
//commands.SetCommands(Console.ReadLine());




