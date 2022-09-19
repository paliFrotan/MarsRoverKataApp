// See https://aka.ms/new-console-template for more information

//  Mission Object
//  Rover: Position and Location (x,y, z) where Z N,S,E,W
//  Plateau: Grid of positions (x,y, Z)
//  FIrst Message: gridsize   MaxCoordinates maxx, maxy
//  CommandMessage: String of Chars L R M where L= left R=Right M=Move
//  1. Plateau SIze(5 5)
//  2. Array RoverInstructions Objects where  2lines
//          roverinstruction => roverPostion
//          roverCommand   =>   set  of LRM
//   expected behaviours
//  turnleft, turnright, moveForward
using MarsRoverKataService;

Console.WriteLine("Hello, World!");
Controller input = new ();
input.ControlSizePlateau(Console.ReadLine());

string initialPositionInput = Console.ReadLine();

string commandSetInput = Console.ReadLine();
string initialPosition2Input = Console.ReadLine();

string commandSet2Input = Console.ReadLine();




