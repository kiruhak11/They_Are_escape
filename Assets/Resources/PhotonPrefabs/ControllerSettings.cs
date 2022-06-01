using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSettings : MonoBehaviour
{
    public Text countSens;
    public Slider sliderSens;
    private PlayerController _playerController;
    private void Start()
    {

        sliderSens.value = _playerController.mouseSensitivity;
    }
    void Update()
    {
        countSens.text = Mathf.Round(_playerController.mouseSensitivity) + "";
        _playerController.mouseSensitivity = sliderSens.value;
    }
}
