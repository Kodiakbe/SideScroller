using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (collision.gameObject.CompareTag("Enemy"))

        {
            Destroy(collision.gameObject);
        }
    }
}
