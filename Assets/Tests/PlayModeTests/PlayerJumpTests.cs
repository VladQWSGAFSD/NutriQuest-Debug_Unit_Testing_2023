using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerJumpTests 
{
    [UnityTest]
    public IEnumerator PlayerGoesUpWhenGroundedAndJumpCalled()
    {
        // Arrange
        var playerGO = new GameObject();
        var jump = playerGO.AddComponent<PlayerJump>();
        var rb = playerGO.AddComponent<Rigidbody>();
        jump.Initialize(rb);

        var groundedSubstitute = Substitute.For<IGrounded>();
        groundedSubstitute.Grounded.Returns(true); 

        jump.SetGrounded(groundedSubstitute);

        // Act
        jump.Jump();
        yield return new WaitForSeconds(0.2f);

        // Assert
        Assert.IsTrue(rb.position.y > 0.5f);
        Debug.Log(rb.position.y);
    }
    class DummyJump : MonoBehaviour, IJump
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _jumpForce = 5f;

        public void Initialize(Rigidbody rigidbody)
        {
            _rb = rigidbody;
        }

        public void Jump()
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            Debug.Log("Jumped");
        }
    }
    [UnityTest]
    public IEnumerator PlayerGoesUpWhenJumpingNoGroundCheck()
    {
        //Arrange
        GameObject playerGO = new GameObject();
        DummyJump jump = playerGO.AddComponent<DummyJump>();
        Rigidbody rb = playerGO.AddComponent<Rigidbody>();
        jump.Initialize(rb);

        //Act
        jump.Jump();
        yield return new WaitForSeconds(0.2f);

        //Assert
        Debug.Log(rb.position.y);
        Assert.IsTrue(rb.position.y > 0.5f);
        
    }
}
