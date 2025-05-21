using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] enemySpawnPoints;
    public GameObject[] mapChanges;

    private bool triggered = false;
    public GameObject ceiling;         
    public float ceilingSpeed = 2f;    

    private bool moveCeiling = false;

    private void Update()
    {
        if (moveCeiling && ceiling != null)
        {
            ceiling.transform.position += Vector3.down * ceilingSpeed * Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;

            
            foreach (Transform spawnPoint in enemySpawnPoints)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            }

            
            foreach (GameObject obj in mapChanges)
            {
                obj.SetActive(true);
            }

            moveCeiling = true;
        }
    }
    //Stoppa taket när den träffar marken
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (moveCeiling && collision.gameObject.CompareTag("Ground"))
        {
            moveCeiling = false;
        }
    }

}
