using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject EndObject;
    public Animator anim;
    public string IsFinish;

    private bool IsGameEnd;
    

    private void Start()
    {
        if(IsGameEnd || anim == null)
        {
            return;
        }
    }

    private void Update()
    {
        IsGameEnd = DialogueLua.GetVariable(IsFinish).asBool;

        if (IsGameEnd == true)
        {
            StartCoroutine(FinishLevel());
        }
    }

    IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(3);
        EndObject.SetActive(true);
        anim.Play("End");

        LoadAndSaveData.instance.SaveData();
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");
    }
}
