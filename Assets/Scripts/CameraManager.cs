using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private PlayerController[] players;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        players = FindObjectsOfType<PlayerController>();
    }
    void Start()
    {
        

    }

    void Update()
    {
        
    }
}
