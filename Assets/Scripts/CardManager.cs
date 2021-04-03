using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    private int _moveCounter;

    [SerializeField] private Card _cardPrefab;
    [SerializeField] private int[] startHand;
    [SerializeField] private float _spawnWait = 0.2f;
    [SerializeField] private float _centerCardMoveDur = 0.2f;
    [SerializeField] private Text _counterText;

    public Transform centerCard;
    public static CardManager instance;
    public Transform cardHolder;
    public int currCardType;
    public List<Card> cards;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnStartHand());
    }

    private IEnumerator SpawnStartHand()
    {
        GameManager.instance.globalInputBlock = true;

        for (int i = 0; i < startHand.Length; i++)
        {
            int cardType = startHand[i];
            SpawnCard(cardType);
            yield return new WaitForSeconds(_spawnWait);

            if (i == startHand.Length - 1)
                centerCard.gameObject.SetActive(false);
        }

        GameManager.instance.globalInputBlock = false;
        UpdateCurrCardType();
    }

    public void UpdateCurrCardType()
    {
        if (cardHolder.childCount <= 0)
            return;

        int randomIndex = UnityEngine.Random.Range(0, cardHolder.childCount);
        currCardType = cardHolder.GetChild(randomIndex).GetComponent<Card>().type;

        foreach (Card card in cards)
            card.UpdateInputBlock();
    }

    public void UpdateCounter()
    {
        _moveCounter++;
        _counterText.text = _moveCounter.ToString();
    }

    public void SetInputBlock()
    {
        foreach (Card card in cards)
            card.UpdateInputBlock(true);
    }

    private void SpawnCard(int cardType)
    {
        Transform newCenterCard = Instantiate(centerCard, centerCard.parent);
        newCenterCard.DOMove(cardHolder.position, _centerCardMoveDur).OnComplete(() =>
        {
            Destroy(newCenterCard.gameObject);
            Card card = Instantiate(_cardPrefab, cardHolder);
            cards.Add(card);
            card.SetCardType(cardType);
        });
    }
}