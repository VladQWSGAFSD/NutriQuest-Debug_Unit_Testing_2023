using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using System.Reflection;
[TestFixture]
public class PlayerAnimationsTests
{
    [Test]
    public void Move_SetsAnimatorSpeedParameterCorrectly()
    {
        // Arrange
        var go = new GameObject();
        var playerAnimations = go.AddComponent<PlayerAnimations>();

        var mockAnimator = Substitute.For<Animator>();
        playerAnimations.GetType().GetField("_animator", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(playerAnimations, mockAnimator);

        var speed = 5f;

        // Act
        playerAnimations.Move(speed);

        // Assert
        mockAnimator.Received().SetFloat(Arg.Is<string>(s => s == "Speed"), Arg.Is<float>(f => f == speed));
    }
}
