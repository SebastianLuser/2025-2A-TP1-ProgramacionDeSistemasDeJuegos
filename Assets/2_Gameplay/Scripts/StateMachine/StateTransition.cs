namespace Gameplay._2_Gameplay.Scripts.StateMachine
{
    public class StateTransition
    {
        public StateType ToState { get; }
        public object Data { get; }

        public StateTransition(StateType toState, object data = null)
        {
            ToState = toState;
            Data = data;
        }
    }
}