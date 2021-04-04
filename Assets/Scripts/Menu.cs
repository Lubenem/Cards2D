using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Vector3 _startPos;

    [SerializeField] private float _moveDur = 0.6f;

    private void Start()
    {
        _startPos = transform.localPosition;
    }

    public void ShowMenu()
    {
        if (GameManager.instance.globalInputBlock)
            return;

        transform.DOMove(CardManager.instance.centerCard.position, _moveDur);
    }

    public void HideMenu()
    {
        transform.DOLocalMove(_startPos, _moveDur);
    }

    public void SetBackgroundColor(Image image)
    {
        GameManager.instance.SetBackgroundColor(image.color);
    }
}