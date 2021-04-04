using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Vector3 _startPos;
    private CardManager _cardManager;

    [SerializeField] private Transform _centerCard;
    [SerializeField] private float _moveDur = 0.6f;
    [SerializeField] private AudioClip _clickSound;

    private void Start()
    {
        _startPos = transform.localPosition;
    }

    public void ShowMenu()
    {
        if (GameManager.instance.globalInputBlock)
            return;

        transform.DOMove(_centerCard.position, _moveDur);
        SoundManager.instance.PlaySound(_clickSound, 0.5f);
    }

    public void HideMenu()
    {
        transform.DOLocalMove(_startPos, _moveDur);
        SoundManager.instance.PlaySound(_clickSound, 0.5f);
    }

    public void SetBackgroundColor(Image image)
    {
        GameManager.instance.SetBackgroundColor(image.color);
        SoundManager.instance.PlaySound(_clickSound, 0.5f);
    }

    public void Restart()
    {
        GameManager.instance.LoadScene(0);
        SoundManager.instance.PlaySound(_clickSound, 0.5f);
    }
}