using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private float _moveDur = 0.6f;

    public void ShowMenu()
    {
        transform.DOMove(CardManager.instance.centerCard.position, _moveDur);
    }

    public void SetBackgroundColor(Image image)
    {
        GameManager.instance.SetBackgroundColor(image.color);
    }
}