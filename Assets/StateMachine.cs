using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State State;

    protected void SetState(State state) 
    {
        State = state;
        StartCoroutine(State.OnEnter());
    }

}