using StatePatternExercise_3.Entities.States;

namespace StatePatternExercise_3.Entities;

public class TrafficLight
{
    private ITrafficState _currentLightState;
    internal ITrafficState CurrentLightState { get => _currentLightState; set => _currentLightState = value; }

    public TrafficLight()
    {
        _currentLightState = new RedState();
    }

    public void Change()
    {
        _currentLightState.Change();
    }
}