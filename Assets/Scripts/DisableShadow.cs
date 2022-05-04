using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShadow : MonoBehaviour
{
    public SpriteRenderer shadow;
    public SpriteRenderer itemRender;

    private bool show;

    private void Start()
    {
        show = false;

        shadow.GetComponent<SpriteRenderer>();
        itemRender.GetComponentInChildren<SpriteRenderer>();

        shadow.enabled = true;
        itemRender.enabled = false;

        StartCoroutine(HideAtStart());
    }

    private void FixedUpdate()
    {
        if(show == false)
        {
            Desactivate();
        }
        else if(show == true)
        {
            Activate();
        }
    }

    IEnumerator HideAtStart()
    {
        yield return new WaitForSeconds(5);

        shadow.enabled = true;
        itemRender.enabled = false;
        show = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        show = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        show = true;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        show = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        show = true;
    }

    private void Activate()
    {
        shadow.enabled = false;
        itemRender.enabled = true;
        Debug.Log("bruh");
    }

    private void Desactivate()
    {
        shadow.enabled = true;
        itemRender.enabled = false;
    }
}
