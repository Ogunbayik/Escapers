using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;
    private ChooseManager chooseManager;

    private PlayerController currentPlayer;
    private PlayerController[] allPlayers;
    private void Awake()
    {
        mainCamera = Camera.main;
        currentPlayer = null;
        chooseManager = FindObjectOfType<ChooseManager>();
        allPlayers = FindObjectsOfType<PlayerController>();
    }
    void Start()
    {
        CheckChoosedPlayer();
    }

    private void OnEnable()
    {
        chooseManager.OnSwitchPlayer += ChooseManager_OnSwitchPlayer;
    }

    private void OnDestroy()
    {
        chooseManager.OnSwitchPlayer -= ChooseManager_OnSwitchPlayer;
    }

    private void ChooseManager_OnSwitchPlayer(object sender, System.EventArgs e)
    {
        CheckChoosedPlayer();
    }

    private void CheckChoosedPlayer()
    {
        foreach (var player in allPlayers)
        {
            if (player.IsChoosed())
                currentPlayer = player;
        }
    }

    private void Update()
    {
        if (currentPlayer != null)
        {
            var cameraSpeed = 0.1f;
            var offsetCameraPosition = new Vector3(0f, 10f, -7f);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, currentPlayer.transform.position + offsetCameraPosition, cameraSpeed);
        }
    }


    
}
