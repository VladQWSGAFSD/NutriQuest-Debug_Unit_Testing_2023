using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefManager : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private FillManager _fillManager; 
    [SerializeField] private Image _fillableImage; 

     public void ResetPlayerPrefs()
    {
       // PlayerPrefs.DeleteAll();

        _score.Reset(); 

        _fillableImage.fillAmount = 1f; 
        _fillManager.AdjustFillAmount(0);
    }
}
