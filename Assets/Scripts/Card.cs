using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour
{
    private Image _image;
    private bool _inputBlock;

    [SerializeField] private float _moveDur = 1f;
    [SerializeField] private List<Sprite> _cardImages;

    public int type;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetCardType(int cardType)
    {
        type = cardType;
        _image.sprite = _cardImages[cardType];
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