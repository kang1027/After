using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoding : MonoBehaviour
{
     public Slider progressbar;
    AsyncOperation operation;
    void Start()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        if(SceneMovePotal.currentSceneCount==1)
        {
             operation = SceneManager.LoadSceneAsync(1);
        }
        else if(SceneMovePotal.currentSceneCount==2){
             operation = SceneManager.LoadSceneAsync(2);
        }
        else if(SceneMovePotal.currentSceneCount==3){
             operation = SceneManager.LoadSceneAsync(3);
        }
        else if(SceneMovePotal.currentSceneCount==3){
             operation = SceneManager.LoadSceneAsync(4);
        }
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            yield return null;
            if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            if (operation.progress >= 0.9f)
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
       


            if (progressbar.value >= 1f && operation.progress >= 0.9f)
                operation.allowSceneActivation = true;
        }
    }
}
