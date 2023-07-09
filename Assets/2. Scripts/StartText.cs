using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Text");
    }
    IEnumerator Text(){
        text.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        while(true){
            text.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            text.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
