using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

    private Text interactUI;
    private bool isInRange;
    private bool isDoorOpen;

    public Animator animator;
    public Collider2D col;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent­<Text>();
        isDoorOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange && isDoorOpen == false)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        animator.SetTrigger("IsDoorOpen");
        col.enabled = false;
        isDoorOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDoorOpen == false)
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
