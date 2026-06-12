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

    public int itemsCollected = 0;

    public int coinsCollected = 0;

    bool isMenuShowing = false;
    public UIManagerScript UIManagerScript;
    void OnMenu()
    {
        UIManagerScript.TogglePanel();
    }

    void OnInteract(InputValue value)
    {
        print("Interacted");
        
        // Cast a ray forward from the player
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        // Check if ray hits something within 5 units
        if (Physics.Raycast(ray, out hit, 5f))
        {
            GameObject hitObject = hit.collider.gameObject;
            print($"Raycasted hit: {hitObject.name}");
            
            if (hitObject.CompareTag("Item"))
            {
                var Collectible = hitObject.GetComponent<Collectible>();
                if (Collectible != null)
                {
                    var collider = Collectible.GetComponent<Collider>();
                    if(collider != null && !collider.enabled)
                    {
                        print($"Already collected {hitObject.name}");
                    }
                    else
                    {
                        print($"Interacted with {hitObject.name}");
                        itemsCollected += 1;
                        Collectible.Collect();
                        UIManagerScript.ItemCollected(itemsCollected);
                    }
                }
            }
            else
            {
                print($"Interacted with {hitObject.name}");
                var Collectible = hitObject.GetComponent<Collectible>();
                if (Collectible != null)
                {   
                    var collider = Collectible.GetComponent<Collider>();
                    if(collider != null && !collider.enabled)
                    {
                        print($"Already collected {hitObject.name}");
                    }
                    else
                    {
                        print($"Interacted with {hitObject.name}");
                        coinsCollected += 1;
                        score += Collectible.score;
                        print($"Score: {score}");
                        Collectible.Collect();
                        UIManagerScript.UpdateScore(score);
                        UIManagerScript.CoinsCollected(coinsCollected);
                    }
                
                }
                var Door = hitObject.GetComponent<Door>();
                if (Door != null)
                {
                    if (hitObject.CompareTag("Locked"))
                    {
                        if (itemsCollected >= 10)
                        {
                            print("Door is now unlocked!");
                        }
                        else
                        {
                            print("Door is locked. Collect all items to unlock.");
                            return; // Exit the method to prevent interaction with the door
                        }
                    }
                    else
                    {
                        print($"Interacted with {hitObject.name}");
                        Door.Interact();
                    }
                }
            }
        }
        else
        {
            print("Nothing in range to interact with");
        }
    }



}
