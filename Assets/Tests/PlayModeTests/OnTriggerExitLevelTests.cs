using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using System;
[TestFixture]
public class OnTriggerExitLevelTests
{
    [UnityTest]
    public IEnumerator OnTriggerShouldCallExitLevel()
    {
        // Arrange
        var onTriggerGameObject = new GameObject();
        var onTrigger = onTriggerGameObject.AddComponent<OnTrigger>();
        onTrigger._tagFiltering = true;
        onTrigger._tag = "Player";

        var exitLevelGameObject = new GameObject();
        var exitLevel = exitLevelGameObject.AddComponent<ExitLevel>();

    
        onTrigger._onTriggerEnter.AddListener(col => exitLevel.Exit());

        var playerGameObject = new GameObject();
        playerGameObject.tag = "Player";
        //playerGameObject.AddComponent<BoxCollider>().isTrigger = true;
        onTriggerGameObject.AddComponent<BoxCollider>().isTrigger = true;

    
        playerGameObject.transform.position = onTriggerGameObject.transform.position;

        // Act
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.True(exitLevel.IsExitCalled);


    }
}
