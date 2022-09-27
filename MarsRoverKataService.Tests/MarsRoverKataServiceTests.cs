using FluentAssertions;

namespace MarsRoverKataService.Tests;

public class Tests
{
    private Rover _rover;
    private Plateau _sizePlateau;
    private Controller _commands;

    [SetUp]
    public void Setup()
    {
        _rover  = new Rover(0);
        _sizePlateau = new Plateau();
        _commands = new Controller();
    }
    [Test]
    public void RoverFacesNorthinitially()
    {
        var _orientation = Direction.N;
        _orientation.Should().Be(_rover.Orientation);
    }

    [Test]
    public void RoverIsAt00()
    {
        var expectedLocation = new Coordinate { X=0, Y=0 };
        expectedLocation.Should().Be(_rover.Location);
    }

    [Test]
    public void RoverMoveFacingNorthThenYIncreasesByOne()
    {
        _rover.MoveForward();
        var expectedLocation = new Coordinate { X = 0, Y = 1 };
        expectedLocation.Should().Be(_rover.Location);
        var _orientation = Direction.N;
        _orientation.Should().Be(_rover.Orientation);
        
    }

    [Test]
    public void RoverFacingSouthThenYDecreasesByOne()
    {
        // Arrange
        _rover.Orientation = Direction.S;
        var initialLocation = _rover.Location; // capturing the inital location

        // Act
        _rover.MoveForward();

        // Assert
        var expectedLocation = new Coordinate { X = initialLocation.X, Y = initialLocation.Y - 1 };
        expectedLocation.Should().Be( _rover.Location);
        _rover.Orientation.Should().Be(Direction.S);
         
    }

    [Test]
    public void RoverFacingEastThenXIncreasesByOne()
    {
        // Arrange
        _rover.Orientation = Direction.E;
        var initialLocation = _rover.Location;

        // Act
        _rover.MoveForward();

        // Assert
        var expectedLocation = new Coordinate { X = initialLocation.X + 1, Y = initialLocation.Y };

        expectedLocation.Should().Be(_rover.Location);

        _rover.Orientation.Should().Be(Direction.E);
    }

    [Test]
    public void RoverFacingWestThenXDecreasesByOne()
    {
        // Arrange
        _rover.Orientation = Direction.W;
        var initialLocation = _rover.Location;

        // Act
        _rover.MoveForward();

        // Assert
        var expectedLocation = new Coordinate { X = initialLocation.X - 1, Y = initialLocation.Y };
        expectedLocation.Should().Be(_rover.Location);
        _rover.Orientation.Should().Be(Direction.W);
    }

    [Test]
    public void RoverFacingNorthThenTheRoverFacesWest()
    {
        _rover.Orientation = Direction.N;
        var initialLocation = _rover.Location;

        _rover.TurnLeft();

        initialLocation.Should().Be(_rover.Location);
        _rover.Orientation.Should().Be(Direction.W);
    }
    [Test]
    public void RoverFacingWestThenTheRoverFacesSouth()
    {
        _rover.Orientation = Direction.W;
        var initialLocation = _rover.Location;

        _rover.TurnLeft();

        initialLocation.Should().Be(_rover.Location);
        _rover.Orientation.Should().Be(Direction.S);
    }
    [Test]
    public void RoverFacingSouthThenTheRoverFacesEast()
    {
        _rover.Orientation = Direction.S;
        var initialLocation = _rover.Location;

        _rover.TurnLeft();

        initialLocation.Should().Be(_rover.Location);
        _rover.Orientation.Should().Be(Direction.E);
    }

    [Test]
    public void RoverFacingEastThenTheRoverFacesNorth()
    {
        _rover.Orientation = Direction.E;
        var initialLocation = _rover.Location;

        _rover.TurnLeft();

        initialLocation.Should().Be(_rover.Location);
        _rover.Orientation.Should().Be(Direction.N);
    }
    [Test]
    public void InputReturnsSizeOfPlateau()
    {
        
        var expectedMaxX = 6;
        var expectedMaxY = 6;
        _sizePlateau.PlateauSettings("5 5");
        _sizePlateau.MaxX.Should().Be(expectedMaxX);
        _sizePlateau.MaxY.Should().Be(expectedMaxY);
    }
    [Test]
    public void IsRoverSettingWithinPlateau()
    {
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("1 2 N",_sizePlateau, _rover);
        var _location = _rover.Location;
        
        _sizePlateau.IsCoordinateWithin(_location).Should().Be(true);
    }
    [Test]
    public void RoverCommandsSet()
    {
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E",_sizePlateau, _rover);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover,_sizePlateau).Should().Be("4 4 E");
    }
    [Test]
    public void RoverCommandsSetRoverLeft()
    {
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E",_sizePlateau, _rover);
        _commands.SetCommands("L");
        _commands.Execute(_rover,_sizePlateau).Should().Be("3 3 N");
    }
    [Test]
    public void RoverCommandsCollision()
    {
        var _rover1 = new Rover(1);
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E",_sizePlateau, _rover);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover,_sizePlateau).Should().Be("4 4 E");
        _rover1.RoverSettings("3 3 E", _sizePlateau, _rover1);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover1,_sizePlateau).Should().Be("RoverModel1: Move aborted for rover @(4,3), Facing Direction N");
    }
    [Test]
    public void RoverCommandsNoCollision()
    {
        var _rover1 = new Rover(1);
        var _rover2 = new Rover(2);
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E", _sizePlateau, _rover);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover,_sizePlateau).Should().Be("4 4 E");
        _rover1.RoverSettings("4 4 E",_sizePlateau, _rover1);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover1,_sizePlateau).Should().Be("5 5 E");
        _rover2.RoverSettings("0 0 E", _sizePlateau,_rover2);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover2,_sizePlateau).Should().Be("1 1 E");
    }
    [Test]
    public void RoverCommandsCollisionAndContinue()
    {
        var _rover1 = new Rover(1);
        var _rover2 = new Rover(2);
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E", _sizePlateau, _rover);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover,_sizePlateau).Should().Be("4 4 E");
        _rover1.RoverSettings("3 3 E", _sizePlateau, _rover1);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover1,_sizePlateau).Should().Be("RoverModel1: Move aborted for rover @(4,3), Facing Direction N");
        _rover2.RoverSettings("0 0 E", _sizePlateau, _rover2);
        _commands.SetCommands("MLMR");
        _commands.Execute(_rover2,_sizePlateau).Should().Be("1 1 E");
    }
}