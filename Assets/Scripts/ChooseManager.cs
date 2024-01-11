using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseManager : MonoBehaviour
{
    [SerializeField] private PlayerController[] allPlayers;

    private List<PlayerController> playerList;

    private int randomIndex;
    private void Awake()
    {
        allPlayers = FindObjectsOfType<PlayerController>();
    }
    void Start()
    {
        playerList = new List<PlayerController>();
        ChooseStartingRandomPlayer();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPlayer();
        }
    }

    private void ChooseStartingRandomPlayer()
    {
        randomIndex = Random.Range(0, allPlayers.Length);

        for (int i = 0; i < allPlayers.Length; i++)
        {
            if(i == randomIndex)
            {
                var randomPlayer = allPlayers[randomIndex];
                playerList.Add(randomPlayer);
                randomPlayer.GetComponent<PlayerController>().IsChoosedPlayer(true);
            }
            else
            {
                var otherPlayer = allPlayers[i];
                playerList.Add(otherPlayer);
                otherPlayer.gameObject.GetComponent<PlayerController>().IsChoosedPlayer(false);
            }
        }
    }

    private void SwitchPlayer()
    {
        int lastPlayerIndex = playerList.Count - 1;

        if(randomIndex >= lastPlayerIndex)
        {
            randomIndex = 0;
        }
        else
        {
            randomIndex++;
        }

        for (int i = 0; i < playerList.Count; i++)
        {
            if (i == randomIndex)
                playerList[randomIndex].gameObject.GetComponent<PlayerController>().IsChoosedPlayer(true);
            else
                playerList[i].gameObject.GetComponent<PlayerController>().IsChoosedPlayer(false);
        }

    }
}
