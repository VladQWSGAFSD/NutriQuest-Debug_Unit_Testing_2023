
using UnityEngine;
using UnityEngine.UI;

public class FillManager : MonoBehaviour, IFillManager
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private GameObject _gameOverImage;
    //public Image fillImage { get { return this._fillImage; } }
    public Image FillImage => _fillImage;

    public void Initialize()
    {
        _gameOverImage.SetActive(false);
    }

    private void Awake()
    {
        //putting playerprefs in awake affects unit tests so comment out when doing a test
        //_fillImage.fillAmount = PlayerPrefs.GetFloat("FillAmount", _fillImage.fillAmount);

    }
    private void Start()
    {
        _gameOverImage.SetActive(false);

    }

    public void AdjustFillAmount(int scoreValue)
    {
        float adjustment = scoreValue / 100f;
        _fillImage.fillAmount = Mathf.Clamp(_fillImage.fillAmount + adjustment, 0f, 1f);

        if (_fillImage.fillAmount == 1f && adjustment > 0) return;

        if (_fillImage.fillAmount == 0f) _gameOverImage.SetActive(true);
    }
}
