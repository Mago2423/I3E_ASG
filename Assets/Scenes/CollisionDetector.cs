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
    public int health = 100;

    public int ItemsCollected = 0;

    public int CoinsCollected = 0;

    GameObject currentCollider;
    
    bool isMenuShowing = false;
    public UIManagerScript UIManagerScript;
    void OnMenu()
    {
        UIManagerScript.TogglePanel();
    }
    void OnCollisionEnter(Collision collision)
    {
        currentCollider = collision.gameObject;
        print($"Collided with {currentCollider.name}");
    }

    void OnCollisionExit(Collision collision)
    {
        print($"Stopped colliding with {currentCollider.name}");
        currentCollider = null;
    }

    void OnInteract(InputValue value)
    {
        print("Interacted");
        if (currentCollider != null && currentCollider.CompareTag("Item"))
        {
            var Collectible = currentCollider.GetComponent<Collectible>();
            if (Collectible != null)
            {
                var collider = Collectible.GetComponent<Collider>();
                if(collider != null && !collider.enabled)
                {
                    print($"Already collected {currentCollider.name}");
                }
                else
                {
                    print($"Interacted with {currentCollider.name}");
                    ItemsCollected += 1;
                    Collectible.Collect();
                    UIManagerScript.ItemCollected(ItemsCollected);
                }
            }
        }
        else if (currentCollider != null)
        {
            print($"Interacted with {currentCollider.name}");
            var Collectible = currentCollider.GetComponent<Collectible>();
            if (Collectible != null)
            {   
                var collider = Collectible.GetComponent<Collider>();
                if(collider != null && !collider.enabled)
                {
                    print($"Already collected {currentCollider.name}");
                }
                else
                {
                    print($"Interacted with {currentCollider.name}");
                    CoinsCollected += 1;
                    score += Collectible.score;
                    print($"Score: {score}");
                    Collectible.Collect();
                    UIManagerScript.UpdateScore(score);
                    UIManagerScript.CoinsCollected(CoinsCollected);
                }
            
            }
            var Door = currentCollider.GetComponent<Door>();
            if (Door != null)
            {
                print($"Interacted with {currentCollider.name}");
                Door.Interact();
            }
            else
            {
                print($"Stopped interacting with {currentCollider.name}");
                Door.Close();
            }
        }
    }



}
