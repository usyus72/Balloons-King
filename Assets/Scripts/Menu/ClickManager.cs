using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ClickManager : MonoBehaviourPunCallbacks
{

    public GameObject clickSound;
    public GameObject loading;
    public GameObject options;
    public GameObject rooms;
    public GameObject menu;
    public GameObject menuMusic;
    public GameObject enterNick;
    public GameObject backGround;
    public GameObject longControl;
    public Text nickInput;
    public Text welcome;

    

    public void OnClick_ClkSound()
    {
        Instantiate(clickSound);
    }
    public void OnClick_EnterNick()
    {
        if (nickInput.text.Length>=17)
        {
            longControl.SetActive(true);

        }
        else if(nickInput.text != "")
        {
            PhotonNetwork.NickName = nickInput.text + Random.Range(100, 999).ToString();
            longControl.SetActive(false);
            menuMusic.SetActive(true);
            menu.SetActive(true);
            backGround.SetActive(true);
            enterNick.SetActive(false);
            welcome.text = "Welcome " + PhotonNetwork.NickName.Substring(0, PhotonNetwork.NickName.Length-3);
        }
    }
    public void OnClick_Play()
    {
        menu.SetActive(false);
        backGround.SetActive(false);
        rooms.SetActive(true);
        
    }
    
    
    public void OnClick_PlayBack()
    {
        menu.SetActive(true);
        backGround.SetActive(true);
        rooms.SetActive(false);
    }
    public void OnClick_Options()
    {
        menu.SetActive(false);
        backGround.SetActive(false);
        options.SetActive(true);
    }
    public void OnClick_OptionsBack()
    {
        menu.SetActive(true);
        backGround.SetActive(true);
        options.SetActive(false);
    }
    public void OnClick_Exit()
    {
        Application.Quit();
    }
    
}
