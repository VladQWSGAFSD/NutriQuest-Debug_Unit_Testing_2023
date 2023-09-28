using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

[TestFixture]
public class OnTriggerExitLevelTests
{
    GameObject onTriggerGameObject;
    GameObject playerGameObject;
    OnTrigger onTrigger;
    ExitLevel exitLevel;

    [SetUp] 
    public void Initialize()
    {

        onTriggerGameObject = new GameObject();
        playerGameObject = new GameObject();
        
        onTriggerGameObject.AddComponent<BoxCollider>().isTrigger = true;
        onTrigger = onTriggerGameObject.AddComponent<OnTrigger>();
        exitLevel = onTriggerGameObject.AddComponent<ExitLevel>();

        playerGameObject.AddComponent<BoxCollider>();
        playerGameObject.AddComponent<Rigidbody>();
        playerGameObject.tag = "Player";

        // onTrigger._tagFiltering = true;
        // onTrigger._tag = "Player";
    }

    [UnityTest]
    public IEnumerator OnTriggerShouldCallExitLevel()
    {
        // Arrange
        playerGameObject.transform.position = onTriggerGameObject.transform.position + new Vector3(0, 1, 0);

        // Act
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.IsTrue(exitLevel.IsExitCalled);
    }
}
