using System.Collections;

public abstract class State
{
    protected GameManager GameManager;
    protected State(GameManager _gameManager)
    {
        GameManager = _gameManager;
    }
    public virtual IEnumerator OnEnter()
    {
        yield break;
    }
}