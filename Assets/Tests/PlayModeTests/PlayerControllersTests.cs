using NUnit.Framework;
using UnityEngine;
using NSubstitute;

public class PlayerControllersTests
{
    private PlayerController controller;
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        controller = go.AddComponent<PlayerController>();
    }
    [Test]
    public void PlayerControllerCanCallJumpTest()
    {
        //GameObject go = new GameObject();
        // PlayerController controller = go.AddComponent<PlayerController>();

        IJump jump = Substitute.For<IJump>();
        controller.Initialize(jump);

        controller.JumpControlActivated();

        jump.Received().Jump();
    }

    [Test]
    public void PlayerControllerCanCallMoveTest()
    {
        //GameObject go = new GameObject();
        // PlayerController controller = go.AddComponent<PlayerController>();

        IMove move = Substitute.For<IMove>();
        controller.InitializeMove(move);

        Vector2 testVector = new Vector2(1, 0);
        controller.MoveControlActivated(testVector);

        move.Received().Move(testVector);
    }
}
