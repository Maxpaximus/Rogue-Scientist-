using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneManager.LoadScene(2);
    }
}
