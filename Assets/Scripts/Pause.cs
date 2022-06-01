using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour{
    [HideInInspector]
    public static bool isPaused;
    [SerializeField]
    private KeyCode pauseButton;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject player;

    PlayerCam playerCam;
    private MouseLook _mouseLook;
    public GameObject model;
    public GameObject Options;
    public GameObject hud;
    public GameObject PlayerObj;

    void Start(){
        isPaused = false;
        playerCam = player.GetComponent<PlayerCam>();
        _mouseLook = model.GetComponent<MouseLook>();
    }

    public void unpause(){
        isPaused = !isPaused;
    }

    void Update(){
        if(Input.GetKeyDown(pauseButton)){
            isPaused = !isPaused;
        }

            // if(isPaused){
            //     pausePanel.SetActive(true);
            //     hud.SetActive(false);
            //     player.GetComponent<PlayerCam>().enabled = false;
            //     model.GetComponent<MouseLook>().enabled = false;
            //     Cursor.visible = true;
            //     Cursor.lockState = CursorLockMode.None;
            //
            // } else {
            //     pausePanel.SetActive(false);
            //     hud.SetActive(true);
            //     player.GetComponent<PlayerCam>().enabled = true;
            //     model.GetComponent<MouseLook>().enabled = true;
            //     Cursor.visible = false;
            //     Cursor.lockState = CursorLockMode.Locked;
            // }
    }

    //buttons 

    public void buttonOptionsIn(){
        Options.SetActive(true);
    }
    public void buttonOptionsOut(){
        Options.SetActive(false);
    }

    public void Exit()
    {
        PhotonNetwork.LoadLevel(0);
    }
}
