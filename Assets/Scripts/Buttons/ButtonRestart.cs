using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonRestart : MonoBehaviour
{
    public void ButtonClickR()
    {
        SceneManager.LoadScene(0);
    }
}

