using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelType
    {
        Normal, MiniBoss, Boss
    }
    [SerializeField] LevelType type;
    GameObject mainCam;
    Collider2D mainBound;
    public List<Transform> chestSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        mainBound = GetComponent<PolygonCollider2D>();
        SpawnChest();
        mainCam = GameObject.FindWithTag("MainCamera");
        mainCam.GetComponent<CinemachineVirtualCamera>().m_Follow = PlayerStats.instance.transform;
        mainCam.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = mainBound;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isBossFight)
        {

        }
        else
        {
            if (mainCam.GetComponent<CinemachineVirtualCamera>().m_Follow != PlayerStats.instance.transform)
                mainCam.GetComponent<CinemachineVirtualCamera>().m_Follow = PlayerStats.instance.transform;
        }
    }

    void SpawnChest()
    {
        var cPos = GameObject.FindGameObjectsWithTag("ChestPos");
        foreach (var i in cPos)
        {
            SpawnManager.instance.SpawnChest(i.transform);
        }
    }
}
