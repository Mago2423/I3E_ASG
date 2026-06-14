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
    public int healAmount = 20;

    public bool HaveInjector = false;

    GameObject currentCollider;
    
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
        if (currentCollider == null)
        {
            return;
        }
        print("Interacted");
        var Collectible = currentCollider.GetComponent<Collectible>();
        var collider = Collectible.GetComponent<Collider>();
        if (currentCollider != null && currentCollider.CompareTag("Item"))
        {
            if (Collectible != null)
            {
                if(collider != null && !collider.enabled)
                {
                    print($"Already collected {currentCollider.name}");
                }
                else
                {
                    print($"Interacted with {currentCollider.name}");
                    itemsCollected += 1;
                    Collectible.Collect();
                    UIManagerScript.ItemCollected(itemsCollected);
                }
            }
        }
        else if (currentCollider.CompareTag("Injector"))
        {
            HaveInjector = true;
            UIManagerScript.InjectorCollected();
            if (Collectible != null)
            {
                Collectible.Collect();
            }
        }
        else if (currentCollider.CompareTag("KeyCard"))
        {
            UIManagerScript.KeyCardCollected();
            if (Collectible != null)
            {
                Collectible.Collect();
            }
        }
        else if (currentCollider.CompareTag("JointPlug"))
        {
            UIManagerScript.JointPlugCollected();
            if (Collectible != null)
            {
                Collectible.Collect();
            }
        }

        else if (currentCollider != null)
        {
            print($"Interacted with {currentCollider.name}");
            if (Collectible != null)
            {   
                if(collider != null && !collider.enabled)
                {
                    print($"Already collected {currentCollider.name}");
                }
                else
                {
                    print($"Interacted with {currentCollider.name}");
                    coinsCollected += 1;
                    score += Collectible.score;
                    print($"Score: {score}");
                    Collectible.Collect();
                    UIManagerScript.UpdateScore(score);
                    UIManagerScript.CoinsCollected(coinsCollected);
                }
            
            }
            var Door = currentCollider.GetComponent<Door>();
            if (Door != null)
            {
                if (currentCollider.CompareTag("Locked"))
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
                    print($"Interacted with {currentCollider.name}");
                    Door.Interact();
                }
            }
        }
    }

    void OnHeal(InputValue value)
    {
        if (HaveInjector == true)
        {
            print($"Healed for {healAmount} health");
            health += healAmount;
            if (health > 100) health = 100;
            UIManagerScript.UpdateHealth(health);
            UIManagerScript.InjectorUsed();
            HaveInjector = false;
        }
    }


}