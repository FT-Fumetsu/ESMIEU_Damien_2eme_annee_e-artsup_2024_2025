using UnityEngine;

[CreateAssetMenu(fileName = "NewCards", menuName = "Cards/CardsDetail")]
public class Card : ScriptableObject
{
    [SerializeField] private CardValue _cardValue;
    [SerializeField] private CardColor _cardColor;
}
