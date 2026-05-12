using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionDetector : MonoBehaviour
{
    /// <summary>
    /// Increment score by this value when a coin is collected.
    /// </summary>
    public int scoreIncrement = 1; //unity overights this value
    int score = 0;

    GameObject currentCollider;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            currentCollider = collision.gameObject;
            print($"Collided with {currentCollider.name}");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            print($"Stopped colliding with {currentCollider.name}");
            currentCollider = null;

        }

    }

    void OnInteract(InputValue value)
    {
        print("Interacted");
        if (currentCollider != null)
        {
            print($"Interacted with {currentCollider.name}");
            var Collectible = currentCollider.GetComponent<Collectible>();
            if (Collectible != null)
            {
                print($"Interacted with {currentCollider.name}");
                score += Collectible.score;
                print($"Score: {score}");
                Collectible.Collect();
            }
            var Door = currentCollider.GetComponent<Door>();
            if (Door != null)
            {
                print($"Interacted with {currentCollider.name}");
                Door.Interact();
            }
        }
    }



}
