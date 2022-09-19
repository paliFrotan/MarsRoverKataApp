using FluentAssertions;

namespace MarsRoverKataService.Tests;

public class Tests
{
    private Rover _rover;
    private Controller _input;  

    [SetUp]
    public void Setup()
    {
        _rover  = new Rover();
        _input = new Controller();
    }

    [Test]
    public void RoverShouldFaceWest()
    {
        char position = 'W';
        _rover.RoverFacingDirection('L').Should().Be(position);
        _rover.RoverFacingDirection('R').Should().Be('E');
    }
    [Test]
    public void InputReturnsSizeOfPlateau()
    {
        List<int> resultList = new List<int>();
        resultList.Add(6);
        resultList.Add(6);
        List<int> resultList2 = new List<int>();
        resultList2.Add(4);
        resultList2.Add(7);
        _input.ControlSizePlateau("5 5").Should().ContainInOrder(resultList);
        _input.ControlSizePlateau("3 6").Should().ContainInOrder(resultList2);
    }
}