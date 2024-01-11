using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private enum FloorType
    {
        One,
        Two,
        Fourth
    }
    [Header(" Settings ")]
    [SerializeField] private FloorType floorType;
    [SerializeField] private GameObject[] floors;

    [SerializeField] private List<MeshRenderer> floorsRendererList;
    private List<Color> colorList;

    private int randomIndex2;
    private void Awake()
    {
        colorList = new List<Color>();
    }
    void Start()
    {
        AddColors();

        StartFloorColor();

        StartRandomRotation();
    }
    private void AddColors()
    {
        colorList.Add(Color.yellow);
        colorList.Add(Color.cyan);
        colorList.Add(Color.magenta);
        colorList.Add(Color.green);
    }

    private void StartFloorColor()
    {
        switch (floorType)
        {
            case FloorType.One:
                var randomColorIndex = Random.Range(0, colorList.Count);
                var floorMesh = floors[0].GetComponent<MeshRenderer>();
                floorMesh.material.color = colorList[randomColorIndex];
                break;
            case FloorType.Two:
                var randomIndex = Random.Range(0, colorList.Count);
                floorsRendererList.Add(floors[0].GetComponent<MeshRenderer>());
                floorsRendererList.Add(floors[1].GetComponent<MeshRenderer>());

                if (randomIndex >= colorList.Count - 1)
                {
                    randomIndex2 = 0;

                    floorsRendererList[0].material.color = colorList[randomIndex];
                    floorsRendererList[1].material.color = colorList[randomIndex2];
                }
                else
                {
                    randomIndex2 = randomIndex++;

                    floorsRendererList[0].material.color = colorList[randomIndex];
                    floorsRendererList[1].material.color = colorList[randomIndex2];
                }
                break;
            case FloorType.Fourth:
                floorsRendererList.Add(floors[0].GetComponent<MeshRenderer>());
                floorsRendererList.Add(floors[1].GetComponent<MeshRenderer>());
                floorsRendererList.Add(floors[2].GetComponent<MeshRenderer>());
                floorsRendererList.Add(floors[3].GetComponent<MeshRenderer>());

                for (int i = 0; i < floors.Length; i++)
                {
                    floorsRendererList[i].material.color = colorList[i];
                }

                break;
        }
    }

    private void StartRandomRotation()
    {
        var randomRoteteIndex = Random.Range(0, 4);

        switch(randomRoteteIndex)
        {
            case 0:
                transform.rotation = Quaternion.Euler(Vector3.zero);
                break;
            case 1:
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;
            case 2:
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                break;
            case 3:
                transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
                break;
        }

    }
}
