using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Ground ground;
    [SerializeField] private GameObject[] activityLigths;
    private enum DoorType
    {
        Light1,
        Light2,
        Light3,
        Light4
    }

    [SerializeField] private DoorType doorType;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        switch(doorType)
        {
            case DoorType.Light1:
                SetDoorLight(1);
                break;
            case DoorType.Light2:
                SetDoorLight(2);
                break;
            case DoorType.Light3:
                SetDoorLight(3);
                break;
            case DoorType.Light4:
                SetDoorLight(4);
                break;
        }
    }

    private void Update()
    {
        CheckLightActivate();
    }
    public void SetDoorLight(int lightCount)
    {
        for (int i = 0; i < activityLigths.Length; i++)
        {
            if (i <= lightCount - 1)
                activityLigths[i].gameObject.SetActive(true);
            else
            {
                activityLigths[i].gameObject.SetActive(false);
                activityLigths[i].GetComponent<DoorLight>().enabled = false;
            }
        }

    }

    private void CheckLightActivate()
    {
        for (int i = 0; i < activityLigths.Length; i++)
        {
            if(activityLigths[i].GetComponent<DoorLight>().lightActivate == DoorLight.LightActivate.Active)
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

    private void CloseDoor()
    {
        animator.SetBool("isOpen", false);
        animator.SetBool("iSClose", false);
    }
}
