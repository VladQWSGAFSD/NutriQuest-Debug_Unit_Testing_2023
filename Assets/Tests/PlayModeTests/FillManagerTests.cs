using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

[TestFixture]
public class FillManagerTests
{
    private FillManager _fillManager;
    private Image _mockImage;

    //i know setup here is done for no reason,its just to practice
    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        _mockImage = go.AddComponent<Image>();

        _fillManager = new GameObject().AddComponent<FillManager>();
        _fillManager.GetType().GetField("_fillImage", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_fillManager, _mockImage);
    }

    [Test]
    public void IncreasesFillAmountOfImageByScoreValue()
    {
        // Arrange
        float initialFillAmount = 0.5f;
        int scoreValue = 20;
        _mockImage.fillAmount = initialFillAmount;

        // Act
        _fillManager.AdjustFillAmount(scoreValue);

        // Assert
        Assert.AreEqual(0.7f, _mockImage.fillAmount);
    }

    [Test]
    public void GameOverImageIsActiveWhenFillAmountIsZero()
    {
        GameObject gameOverImageGO = new GameObject();
        _fillManager.GetType().GetField("_gameOverImage", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_fillManager, gameOverImageGO);

        // Arrange 
        float initialFillAmount = 0.2f;
        _mockImage.fillAmount = initialFillAmount;
        int scoreValue = -20;
        _fillManager.Initialize();


        // Act
        //gameOverImageGO.SetActive(false);
        _fillManager.AdjustFillAmount(scoreValue);
        Debug.Log("Actual fill amount: " + _mockImage.fillAmount);


        // Assert
        Assert.IsTrue(gameOverImageGO.activeSelf);
    }
    //test jump
}
