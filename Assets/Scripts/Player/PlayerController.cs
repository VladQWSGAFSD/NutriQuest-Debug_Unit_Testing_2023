using UnityEngine;
using NaughtyAttributes;
using TNRD;

public class PlayerController : MonoBehaviour
{
    [Header("Mechanics")]
    [SerializeField, Label("Movement")] private SerializableInterface<IMove> _movementSerialized;
    [SerializeField, Label("Jump")] private SerializableInterface<IJump> _jumpSerialized;

    [Header("Input Parameters")]
    [SerializeField, InputAxis] private string _horizontalAxis;
    [SerializeField, InputAxis] private string _verticalAxis;
    [SerializeField, InputAxis] private string _jumpButton;

    
    // Properties for the interfaces
    private IMove _movement;
    private IJump _jump;

    private void Start()
    {
        _movement = _movementSerialized.Value;
        _jump = _jumpSerialized.Value;
    }
    public void Initialize(IJump jump)
    {
        _jump = jump;
    }
    public void InitializeMove(IMove move)
    {
        _movement = move;
    }
    private void Update()
    {
        // Movement
        MoveControlActivated(new Vector2(Input.GetAxisRaw(_horizontalAxis), Input.GetAxisRaw(_verticalAxis)).normalized);

        // Jump
        if (Input.GetButtonDown(_jumpButton))
        {
            JumpControlActivated();
        }
    }
    public void JumpControlActivated()
    {
        _jump.Jump();
    }
    public void MoveControlActivated(Vector2 movement)
    {
        _movement.Move(movement);
    }
}
