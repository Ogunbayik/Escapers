using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private List<Color> colorList;

    [SerializeField] private SkinnedMeshRenderer[] playersMesh;
    private void Awake()
    {
        colorList = new List<Color>();

        playersMesh = FindObjectsOfType<SkinnedMeshRenderer>();
    }
    void Start()
    {
        StartPlayerColor();
    }

    private void StartPlayerColor()
    {
        colorList.Add(Color.yellow);
        colorList.Add(Color.cyan);
        colorList.Add(Color.magenta);
        colorList.Add(Color.green);

        for (int i = 0; i < playersMesh.Length; i++)
        {
            playersMesh[i].material.color = colorList[i];
        }
    }
}
