using FluentAssertions;

namespace MarsRoverKataService.Tests;

public class Tests
{
    private Rover _rover;

    [SetUp]
    public void Setup()
    {
        _rover  = new Rover();
    }

    [Test]
    public void RoverShouldFaceWest()
    {
        char position = 'W';
        _rover.RoverFacingDirection('L').Should().Be(position);
        _rover.RoverFacingDirection('R').Should().Be('E');
    }
}