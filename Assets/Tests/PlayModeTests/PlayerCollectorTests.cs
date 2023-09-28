using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using System.Reflection;
using UnityEngine.TestTools;
using System.Collections;

[TestFixture]
public class PlayerCollectorTests
{

    class DummyCollectible : MonoBehaviour, ICollect
    {
        public bool isCalled;
        public void Collect()
        {
            isCalled = true;
        }
    }


    [UnityTest]
    public IEnumerator ActiveCollectShouldCallCollectOnICollectObjects()
    {
        // Arrange
        var playerCollectorGameObject = new GameObject();
        var playerCollector = playerCollectorGameObject.AddComponent<PlayerCollector>();
        playerCollector._detectorLength = 5f; 

        var foodCollectibleGameObject = new GameObject();
        foodCollectibleGameObject.AddComponent<BoxCollider>();
        //mock icollect?
        var foodCollectible = foodCollectibleGameObject.AddComponent<DummyCollectible>();
 
        foodCollectibleGameObject.transform.position = playerCollectorGameObject.transform.position + playerCollectorGameObject.transform.forward * 1f;

        // Act
       // playerCollector.ActiveCollectActivated();
        yield return new WaitForSeconds(0.5f);

        // Assert
        Assert.True(foodCollectible.isCalled);
    }

}
