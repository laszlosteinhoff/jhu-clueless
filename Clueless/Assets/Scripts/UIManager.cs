using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Call back to NetworkManager to send requests from buttons
    public NetworkManager nm;

    // UI on startup
    public GameObject startupUI;

    // UI when waiting for a game to begin
    public GameObject waitingUI;

    // UI when waiting for another player to take a turn
    public GameObject waitForTurnUI;
    public TextMeshProUGUI currentTurnText;

    // UI when prompted to disprove a suggestion
    public GameObject disproveUI;
    public Button disproveOptionOne;
    public Button disproveOptionTwo;
    public Button disproveOptionThree;

    // Start is called before the first frame update
    void Start()
    {
        startupUI.SetActive(true);
    }

    public void WaitingForStart()
    {
        startupUI.SetActive(false);
        waitingUI.SetActive(true);
    }

    public void WaitingForTurn(Character character)
    {
        waitForTurnUI.SetActive(true);
        currentTurnText.SetText("Waiting for: " + character.cardName);
    }

    public void Disprove(List<Card> cards)
    {
        waitingUI.SetActive(false);
        disproveUI.SetActive(true);

        if (cards.Count > 0)
        {
            disproveOptionOne.GetComponentInChildren<Text>().text = cards[0].cardName;
            disproveOptionOne.onClick.AddListener(() => nm.Disprove(cards[0]));
            disproveOptionOne.gameObject.SetActive(true);
        }
        if (cards.Count > 1)
        {
            disproveOptionTwo.GetComponentInChildren<Text>().text = cards[1].cardName;
            disproveOptionTwo.onClick.AddListener(() => nm.Disprove(cards[1]));
            disproveOptionTwo.gameObject.SetActive(true);
        } else
        {
            disproveOptionTwo.gameObject.SetActive(false);
        }
        if (cards.Count > 2)
        {
            disproveOptionThree.GetComponentInChildren<Text>().text = cards[2].cardName;
            disproveOptionThree.onClick.AddListener(() => nm.Disprove(cards[2]));
            disproveOptionThree.gameObject.SetActive(true);
        } else
        {
            disproveOptionThree.gameObject.SetActive(false);
        }
    }

}
