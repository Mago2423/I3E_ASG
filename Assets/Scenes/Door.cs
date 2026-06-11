using UnityEngine;
using UnityEngine.UIElements;
public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    bool isOpen = false;
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
}
