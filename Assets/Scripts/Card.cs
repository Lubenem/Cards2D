using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Card : MonoBehaviour
{
    private Image _image;
    private bool _inputBlock;

    [SerializeField] private float _moveDur = 1f;

    public int childIndex;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetCardImg(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void PointerDown()
    {
        if (_inputBlock || GameManager.instance.globalInputBlock)
            return;

        transform.SetParent(CardManager.instance.cardHolder.parent);
        MoveToCenter();
    }

    private void MoveToCenter()
    {
        _inputBlock = true;
        transform.DOMove(CardManager.instance.centerCard.transform.position, _moveDur).OnComplete(() =>
        {
            StartCoroutine(RemoveCard());
        });
    }

    private IEnumerator RemoveCard()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}