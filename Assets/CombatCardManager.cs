using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCardManager : MonoBehaviour
{
     public GameObject deck;
    public GameObject discard;

    public void Draw()
    {
        Transform cardToPlay = GetRandomCardFromDeck();

        if (cardToPlay != null)
        {
            ICard card = cardToPlay.GetComponent<ICard>();
            if (card != null)
            {
                card.Play();

                // Change the parent of the card to the DISCARD
                cardToPlay.SetParent(discard.transform);
            }
        }
        else
        {
            Shuffle();
        }
    }

    private Transform GetRandomCardFromDeck()
    {
        Transform[] cardArray = deck.GetComponentsInChildren<Transform>();
        int cardCount = cardArray.Length;

        if (cardCount <= 1) // Check if there are no cards in the deck
        {
            return null;
        }

        int randomIndex = Random.Range(1, cardCount); // Exclude index 0 (deck's own transform)
        return cardArray[randomIndex];
    }

    public void Shuffle()
    {
        // Change the parent of everything in the DISCARD to the DECK
        foreach (Transform card in discard.transform)
        {
            card.SetParent(deck.transform);
        }
    }
}