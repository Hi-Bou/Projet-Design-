using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShadow : MonoBehaviour
{
    public SpriteRenderer shadow;
    
    [SerializeField]
    private SpriteRenderer itemRender;

    private bool show;

    private void Awake()
    {
        shadow.enabled = true;
        show = false;

        StartCoroutine(HideAtStart());

        if (itemRender == null)
        {
            return;
        }

        itemRender.enabled = false;
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
        yield return new WaitForSeconds(0.01f);

        shadow.enabled = true;
        show = false;

        if (itemRender == null)
        {
            yield break;
        }

        itemRender.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        show = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        show = false;
    }

    private void Activate()
    {
        shadow.enabled = false;

        if (itemRender == null)
        {
            return;
        }

        itemRender.enabled = true;
    }

    private void Desactivate()
    {
        shadow.enabled = true;

        if (itemRender == null)
        {
            return;
        }

        itemRender.enabled = false;
    }
}
