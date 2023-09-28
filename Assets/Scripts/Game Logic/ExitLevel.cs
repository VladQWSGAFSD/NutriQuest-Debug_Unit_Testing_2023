using UnityEngine;
/// <summary>
/// Exits the level when the player reaches the end.
/// </summary>s
public class ExitLevel : MonoBehaviour
{
    public bool IsExitCalled { get; private set; }

    private OnTrigger onTrigger;

    private void Start()
    {
        onTrigger = FindObjectOfType<OnTrigger>();

        if (onTrigger != null)
            onTrigger._onTriggerEnter.AddListener(Exit);
        else
            Debug.Log("no ontrigger found");
    }

    public void Exit(Collider other)
    {
        // TODO : Exit the level
        Debug.Log("Exit level");
        IsExitCalled = true;

        if (onTrigger != null)
            onTrigger._onTriggerEnter.RemoveListener(Exit);

    }
    private void OnDisable()
    {
        
    }


}
