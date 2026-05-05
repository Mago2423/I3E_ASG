using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int score = 0;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.StartsWith("Coin"))
        {
            score++;
            collision.gameObject.SetActive(false);
            if (score == 5)
            {
            print("You collected all the coins! go to the flag!");
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (score==5 && other.gameObject.name.StartsWith("flag"))
        {
            print("You win!");
        }
    }
}
