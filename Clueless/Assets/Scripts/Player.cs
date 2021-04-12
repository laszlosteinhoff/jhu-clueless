using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int id;
    public string name;
    public Character character;
    public List<Card> hand;
    
    public Player(int id, string name, Character character)
    {
        this.id = id;
        this.name = name;
        this.character = character;
    }

    public void AddToHand(Card card)
    {
        this.hand.Add(card);
        card.disproven = true;
    }

    public void AddToHand(ICollection<Card> cards)
    {
        foreach (Card card in cards)
        {
            AddToHand(card);
        }
    }
}
