using UnityEngine;
using UnityEngine.UIElements;
public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    bool isOpen = false;
    int time = 1000;
    bool isColliding = false;

    void Update()
    {
        if (!isColliding && isOpen)
        {
            print("Countdown to close door");
            time -= 1;
            if (time <= 0 && !isColliding)
            {
                print("Closing door");
                Close();
                time = 1000;
            }
        }
    }
    public int Interact()
    {
        var animator = GetComponent<Animator>();
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
        return 0;
    }
    public int Close()
    {
        var animator = GetComponent<Animator>();
        isOpen = false;
        animator.SetBool("IsOpen", isOpen);
        return 0;
    }
    void OnCollisionEnter(Collision collision)
    {
        print($"Collided with {collision.gameObject.name}");
        isColliding = true;
    }
    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
        print($"Stopped colliding with {collision.gameObject.name}");
    }
}
