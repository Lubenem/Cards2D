using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;

    [SerializeField] private int[] startHand;
    [SerializeField] private float _spawnWait = 0.2f;
    [SerializeField] private float _centerCardMoveDur = 0.2f;

    public Transform centerCard;
    public static CardManager instance;
    public Transform cardHolder;

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
    }

    private void SpawnCard(int cardType)
    {
        Transform newCenterCard = Instantiate(centerCard, centerCard.parent);
        newCenterCard.DOMove(cardHolder.position, _centerCardMoveDur).OnComplete(() =>
        {
            Destroy(newCenterCard.gameObject);
            Card card = Instantiate(_cardPrefab, cardHolder);
            card.SetCardType(cardType);
        });
    }
}