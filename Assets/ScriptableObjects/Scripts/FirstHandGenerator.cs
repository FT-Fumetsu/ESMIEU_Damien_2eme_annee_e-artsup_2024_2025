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

        for (int i = 0; i < numberOfCards; i++)
        {
            int randomIndex = Random.Range(0, availableCards.Count);
            Card selectedCard = availableCards[randomIndex];
            Debug.Log("You drawn: " + selectedCard.name);
            availableCards.RemoveAt(randomIndex);
        }
    }
}
