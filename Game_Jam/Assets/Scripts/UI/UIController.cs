using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject errorPanel;
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void SaveName()
    {
        if(input.text.Length < 3)
        {
            errorPanel.SetActive(true);
        }
        else
        {
            this.GetComponent<MultiVar>().SetName(input.text);
            SceneManager.LoadScene(1);
        }
    }
}
