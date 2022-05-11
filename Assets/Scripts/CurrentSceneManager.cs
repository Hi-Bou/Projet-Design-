using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int levelToUnlock;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Il y a plus d'une instance de CurrentSceneManager dans la scene");
            return;
        }

        instance = this;
    }
}
