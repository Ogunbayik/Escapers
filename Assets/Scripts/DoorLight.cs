using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour
{
    private PlayerTrigger[] playerTrigger;

    public enum LightActivate
    {
        Active,
        Deactive
    }

    public LightActivate lightActivate;

    private MeshRenderer meshRenderer;
    private void Awake()
    {
        playerTrigger = FindObjectsOfType<PlayerTrigger>();
        meshRenderer = GetComponent<MeshRenderer>();
        lightActivate = LightActivate.Deactive;
    }

    private void OnEnable()
    {
        foreach (var player in playerTrigger)
        {
            player.OnRightFloor += PlayerTrigger_OnRightFloor;
        }
    }

    private void PlayerTrigger_OnRightFloor(object sender, System.EventArgs e)
    {
        lightActivate = LightActivate.Active;
        Debug.Log("Change Light");
    }

    void Update()
    {
        switch(lightActivate)
        {
            case LightActivate.Active:
                meshRenderer.material.color = Color.green;
                break;
            case LightActivate.Deactive:
                meshRenderer.material.color = Color.red;
                break;
        }
    }
}
