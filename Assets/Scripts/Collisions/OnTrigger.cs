using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes events when a collider enters or exits the trigger.
/// </summary>
public class OnTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] public UnityEvent<Collider> _onTriggerEnter = new UnityEvent<Collider>();
    [SerializeField] private UnityEvent<Collider> _onTriggerExit = new UnityEvent<Collider>();

    [Header("Parameters")]

    [SerializeField] public bool _tagFiltering = true;
    [SerializeField, ShowIf(nameof(_tagFiltering)), Tag] public string _tag = "Player";
    
    [Space(2)]
    [SerializeField] private bool _layerFiltering = false;
    [SerializeField, ShowIf(nameof(_layerFiltering))] private LayerMask _layerMask;

    /// <summary>
    /// Invokes the enter event if the collider is valid.
    /// </summary>
    /// <param name="other">the collider which triggered the script</param>
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter trigger");
        // Checks tag and layer, based on what’s enabled
        if (_tagFiltering && !other.CompareTag(_tag))
        {
            Debug.Log($"expected {_tag}, but got {other.tag}");
            return;
        }
        if (_layerFiltering && !(_layerMask == (_layerMask | (1 << other.gameObject.layer))))
        {
            Debug.Log($"layer condition");
            return;
        }

        _onTriggerEnter.Invoke(other);
        Debug.Log("enter trigger verif");
    }

    /// <summary>
    /// Invokes the exit event if the collider is valid.
    /// </summary>
    /// <param name="other">the collider which triggered the script</param>
    private void OnTriggerExit(Collider other)
    {
        // Checks tag and layer, based on what’s enabled
        if (_tagFiltering && !other.CompareTag(_tag)) return;
        if (_layerFiltering && !(_layerMask == (_layerMask | (1 << other.gameObject.layer)))) return;

        _onTriggerExit.Invoke(other);
    }
}
