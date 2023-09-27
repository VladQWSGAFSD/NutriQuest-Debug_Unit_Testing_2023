using UnityEngine;

/// <summary>
/// Exits the level when the player reaches the end.
/// </summary>
public class ExitLevel : MonoBehaviour
{
    public bool IsExitCalled { get; private set; }

    public void Exit()
    {
        // TODO : Exit the level
        Debug.Log("Exit level");
        IsExitCalled = true;
    }
}

