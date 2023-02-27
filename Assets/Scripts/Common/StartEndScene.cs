using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndScene : MonoBehaviour
{

    public void OpenEndScene()
    {
        SceneManager.LoadScene(2);
    }
    
}
