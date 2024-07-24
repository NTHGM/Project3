using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Enemy")]
    public int[] numEnemy;
    public GameObject[] enemy;
    [Header("SpawnType")]
    public SpawnType spawnType = SpawnType.Wait;
    public enum SpawnType
    {
        Trigger,
        Wait
    }
    float CD;
    public float SpawnTime = 1f;
    public float trigger;
    // Start is called before the first frame update
    void Start()
    {
        CD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnType == SpawnType.Wait)
        {
            if (CD < SpawnTime)
            {
                CD += Time.deltaTime;
            }
            else
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        for (int i = 0; i < enemy.LongLength; i++)
            while (numEnemy[i] > 0)
            {
                Vector2 pos = new Vector2(Random.Range(transform.position.x - gameObject.GetComponent<BoxCollider2D>().bounds.size.x / 2 + 1f,
                 transform.position.x + gameObject.GetComponent<BoxCollider2D>().bounds.size.x / 2 - 1f),
                 transform.position.y + 0.5f);
                SpawnManager.instance.SpawnMonster(enemy[i], pos);
                numEnemy[i]--;
            }
        this.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && spawnType == SpawnType.Trigger)
        {
            Spawn();
        }
    }
}
