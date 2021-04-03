using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private List<Sprite> _cardImages;
    [SerializeField] private int _startCardNumber = 4;

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

    }

    private void SpawnCard(int index)
    {
        Card card = Instantiate(_cardPrefab, cardHolder);
        card.SetCardImg(_cardImages[index]);
    }
}