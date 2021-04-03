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
    [SerializeField] private Color _inputBlockColor = Color.gray;

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

    public void UpdateInputBlock(bool forceInputBlock = false)
    {
        if (!forceInputBlock)
            _inputBlock = !(type == CardManager.instance.currCardType);
        else
            _inputBlock = true;

        _image.color = _inputBlock ? _inputBlockColor : Color.white;
    }

    public void PointerDown()
    {
        if (_inputBlock || GameManager.instance.globalInputBlock)
            return;

        transform.SetParent(CardManager.instance.cardHolder.parent);
        CardManager.instance.SetInputBlock();
        MoveToCenter();
    }

    private void MoveToCenter()
    {
        _inputBlock = true;
        _image.color = Color.white;
        transform.DOMove(CardManager.instance.centerCard.transform.position, _moveDur).OnComplete(() =>
        {
            StartCoroutine(RemoveCard());
        });
    }

    private IEnumerator RemoveCard()
    {
        yield return new WaitForSeconds(1f);
        CardManager.instance.cards.Remove(this);
        Destroy(gameObject);
        CardManager.instance.UpdateCurrCardType();
        CardManager.instance.UpdateCounter();
    }
}