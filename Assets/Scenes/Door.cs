using UnityEngine;
using UnityEngine.UIElements;
public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    bool isOpen = false;
    public int Interact()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("IsOpen", isOpen);
        isOpen = !isOpen;
        return 0;
    }
}
