using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UIManager uiManager;
    // These have all been passed in using the Unity UI, they don't need to be constructed
    public List<Card> deck;
    public List<PlayerTurn> moves;
    public List<Location> hallways;

    public int gameID;
    public int playerID;
    public int character;
    public Location lastTurnLocation = null;

    public Player player;

    Dictionary<int, Player> players = new Dictionary<int, Player>();

    // Populate the player's hand with cards based on their ID, and mark them disproven
    public void SetHand(List<int> cards)
    {
        player.AddToHand(GetCardsById(cards));
        foreach (int card_id in cards)
        {
            Card card = GetCard(card_id);
            player.AddToHand(card);
            card.disproven = true;
        }
    }

    public void WaitForStart()
    {
        uiManager.WaitingForStart();
    }

    // Initiate the action and options when it becomes this player's turn
    public void StartTurn(Character character)
    {
        if (character = this.player.character)
        {
            // Enable controls to take a turn
        } else
        {
            // Show that we are waiting for another player
            uiManager.WaitingForTurn(character);
        }
    }

    public void StartDisprove(List<Card> cards)
    {
        // Remove any cards that aren't in the player's hand
        foreach (Card card in cards)
        {
            if (!player.hand.Contains(card))
            {
                cards.Remove(card);
            }
        }
        // Enable the disprove UI with the correct cards
        uiManager.Disprove(cards);
    }

    // Move all characters and weapons to a location based on a player turn game update
    public void UpdatePositions(GameUpdate update)
    {
        Character character = (Character)GetCard(update.PlayerID);
    }

    public void HandleUpdate(GameUpdate update)
    {
        if (update.Type == GameUpdate.Types.Type.Initiate)
        {
            // Set up the players and characters
            foreach (PlayerCharacter pc in update.Initiate.Characters)
            {
                Player newPlayer =  new Player(pc.PlayerID, pc.Name, (Character)GetCard(pc.Character));
                players.Add(pc.PlayerID, newPlayer);

                // Save a special reference to our own player
                if (pc.PlayerID == this.playerID)
                {
                    this.player = newPlayer;
                }
            }

            // Start the first player's turn
            StartTurn((Character)GetCard(1));

        } else if (update.Type == GameUpdate.Types.Type.Prompt)
        {
            List<Card> cards = GetCardsById(update.Prompt.Cards);
            StartDisprove(cards);

        } else if (update.Type == GameUpdate.Types.Type.Turn)
        {
            // Update locations of characters and weapons
            UpdatePositions(update);
        } else if (update.Type == GameUpdate.Types.Type.Connect)
        {
            // Should receive this as first request on the stream after connecting
            // Use to save the player ID
            player.id = update.PlayerID;
        }
    }

    private List<Card> GetCardsById(ICollection<int> ids)
    {
        List<Card> cards = new List<Card>();
        foreach (int i in ids)
        {
            cards.Add(GetCard(i));
        }
        return cards;
    }

    private Card GetCard(int id)
    {
        return deck.Find(c => c.id == id);
    }

}
