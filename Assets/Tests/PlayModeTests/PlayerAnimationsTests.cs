//using NUnit.Framework;
//using System.Reflection;
//using UnityEngine;

//public class PlayerAnimationsTests
//{
//    public class MockAnimator : MonoBehaviour,Animator
//    {
//        public string LastParamName { get; private set; }
//        public float LastValue { get; private set; }

//        public override void SetFloat(string name, float value)
//        {
//            LastParamName = name;
//            LastValue = value;
//        }
//    }

//    [Test]
//    public void PlayerAnimationsCallsMoveAnim()
//    {
//        // Arrange
//        var go = new GameObject();
//        var playerAnimations = go.AddComponent<PlayerAnimations>();

//        var mockAnimator = new MockAnimator();
//        typeof(PlayerAnimations).GetField("_animator", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(playerAnimations, mockAnimator);

//        float testSpeed = 5f;

//        // Act
//        playerAnimations.Move(testSpeed);

//        // Assert
//        Assert.AreEqual("_speedParam", mockAnimator.LastParamName);
//        Assert.AreEqual(testSpeed, mockAnimator.LastValue);
//    }

 
//}
