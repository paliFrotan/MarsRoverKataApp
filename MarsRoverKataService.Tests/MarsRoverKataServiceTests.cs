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
        _rover  = new Rover();
        _sizePlateau = new Plateau();
        _commands = new Controller();
    }
    /*[Test]
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
        /*
        _rover.MoveForward();

        var expectedLocation = new Coordinate { X = 0, Y = 1 };
        expectedLocation.Should().Be(_rover.Location);
        var _orientation = Direction.N;
        _orientation.Should().Be(_rover.Orientation);
        */
    /*}
    [Test]
    public void RoverFacingSouthThenYDecreasesByOne()
    {
        // Arrange
        var rover = new Rover { Orientation = Direction.S };
        var initialLocation = rover.Location; // capturing the inital location

        // Act
        rover.MoveForward();

        // Assert
        var expectedLocation = new Coordinate { X = initialLocation.X, Y = initialLocation.Y - 1 };
        Assert.AreEqual(expectedLocation, rover.Location);
        Assert.AreEqual(Direction.S, rover.Orientation);
    }
    [Test]
    public void RoverFacingEastThenXIncreasesByOne()
    {
        // Arrange
        var rover = new Rover { Orientation = Direction.E };
        var initialLocation = rover.Location;

        // Act
        rover.MoveForward();

        // Assert
        var expectedLocation = new Coordinate { X = initialLocation.X + 1, Y = initialLocation.Y };
        Assert.AreEqual(expectedLocation, rover.Location);
        Assert.AreEqual(Direction.E, rover.Orientation);
    }
    [Test]
    public void RoverFacingWestThenXDecreasesByOne()
    {
        // Arrange
        var rover = new Rover { Orientation = Direction.W };
        var initialLocation = rover.Location;

        // Act
        rover.MoveForward();

        // Assert
        var expectedLocation = new Coordinate { X = initialLocation.X - 1, Y = initialLocation.Y };
        Assert.AreEqual(expectedLocation, rover.Location);
        Assert.AreEqual(Direction.W, rover.Orientation);
    }
    [Test]
    public void RoverFacingNorthThenTheRoverFacesWest()
    {
        var rover = new Rover { Orientation = Direction.N };
        var initialLocation = rover.Location;

        rover.TurnLeft();

        Assert.AreEqual(initialLocation, rover.Location);
        Assert.AreEqual(Direction.W, rover.Orientation);
    }
    [Test]
    public void RoverFacingWestThenTheRoverFacesSouth()
    {
        var rover = new Rover { Orientation = Direction.W };
        var initialLocation = rover.Location;

        rover.TurnLeft();

        Assert.AreEqual(initialLocation, rover.Location);
        Assert.AreEqual(Direction.S, rover.Orientation);
    }
    [Test]
    public void RoverFacingSouthThenTheRoverFacesEast()
    {
        var rover = new Rover { Orientation = Direction.S };
        var initialLocation = rover.Location;

        rover.TurnLeft();

        Assert.AreEqual(initialLocation, rover.Location);
        Assert.AreEqual(Direction.E, rover.Orientation);
    }
    [Test]
    public void RoverFacingEastThenTheRoverFacesNorth()
    {
        var rover = new Rover { Orientation = Direction.E };
        var initialLocation = rover.Location;

        rover.TurnLeft();

        Assert.AreEqual(initialLocation, rover.Location);
        Assert.AreEqual(Direction.N, rover.Orientation);
    }*/
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
        _rover.RoverSettings("1 2 N");
        var _location = _rover.Location;
        _sizePlateau.PlateauSettings("5 5");
        _sizePlateau.IsCoordinateWithin(_location).Should().Be(true);
    }
    /*[Test]
    public void RoverCommandsSet()
    {
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E");
        _commands.SetCommands("MLMR");
        _commands.Execute(_sizePlateau,_rover).Should().Be("4 4 E");
    }*/
    [Test]
    public void RoverCommandsSet()
    {
        _sizePlateau.PlateauSettings("5 5");
        _rover.RoverSettings("3 3 E");
        _commands.SetCommands("L");
        _commands.Execute(_sizePlateau, _rover).Should().Be("3 3 N");
    }
    /*
    
    
  [TestCase(Direction.East, Direction.North, TestName = "AndFacingEastThenTheRoverFacesNorth")]
  public void RoverTurningLeft(Direction start, Direction expected)
  {
    var rover = new Rover { Orientation = start };
    var initialLocation = rover.Location;

    rover.TurnLeft();

    Assert.AreEqual(expected, rover.Orientation);
    Assert.AreEqual(initialLocation, rover.Location);
  }*/
}