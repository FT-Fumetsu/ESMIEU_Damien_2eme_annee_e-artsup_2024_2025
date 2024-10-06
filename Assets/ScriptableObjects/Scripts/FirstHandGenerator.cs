using System.Collections.Generic;
using UnityEngine;

public class FirstHandGenerator : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;

    private void Start()
    {
        DrawRandomCards(7);
    }

    private void DrawRandomCards(int numberOfCards)
    {
        List<Card> availableCards = new List<Card>(_cards);

        List<Card> drawnedCards = new List<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            int randomIndex = Random.Range(0, availableCards.Count);
            Card selectedCard = availableCards[randomIndex];
            drawnedCards.Add(selectedCard);
            Debug.Log("You drawn: " + selectedCard.name);
            availableCards.RemoveAt(randomIndex);
        }
    }
}
