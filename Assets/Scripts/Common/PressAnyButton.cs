using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyButton : MonoBehaviour
{
    private bool enable;


    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        enable = true;
    }
    
    private void Update()
    {
        if(!enable)
            return;
            
        if (Input.anyKey)
            SceneManager.LoadScene(1);
    }
}
