using NaughtyAttributes;
using TNRD;
using UnityEngine;

/// <summary>
/// Makes the player jump with the physics engine.
/// </summary>
public class PlayerJump : MonoBehaviour, IJump
{
    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField, Label("Ground Detector")] private SerializableInterface<IGrounded> _groundedSerialized;

    [Header("Parameters")]
    [SerializeField] private float _jumpForce = 5f;

    // Properties for the interfaces
    private IGrounded _grounded => _groundedSerialized.Value;

    public void Initialize(Rigidbody rb)
    {
        _rb = rb;
    }

    public void SetGrounded(IGrounded grounded)
    {
        if (_groundedSerialized == null)
        {
            _groundedSerialized = new SerializableInterface<IGrounded>();
        }
        _groundedSerialized.Value = grounded;
    }

    /// <summary>
    /// Makes the player jump with the physics engine based on the jump force.
    /// </summary>
    public void Jump()
    {
        if (!_grounded.Grounded)
        {
            Debug.Log("Jump called. player is NOT grounded.");
            return;
        }
        Debug.Log("Jump. player is grounded.");
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

}
