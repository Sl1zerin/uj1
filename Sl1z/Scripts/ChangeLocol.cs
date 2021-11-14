using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLocol : MonoBehaviour
{
    
    public bool stay;
    public Transform point;
    public GameObject nextRoom;
    public GameObject lastRoom;

    public GameObject character;
    public InputCharacter inputCharacter;

    public AudioSource audioDoor;

    public bool changeroom = false;

    public SettingOptionsCamera settingText;

    public GameObject Text;

    private void OnTriggerEnter(Collider other) {
        stay = true;
        if(other.tag == "Character")
        {
            character = other.gameObject;
            inputCharacter=character.GetComponent<InputCharacter>();
        }
    }
    private void OnTriggerStay(Collider other) {
        stay = true;
        if(other.tag == "Character")
        {
            character = other.gameObject;
            inputCharacter=character.GetComponent<InputCharacter>();
        }
    }

    private void OnTriggerExit(Collider other) {
        stay = false;
        if(other.tag == "Character")
        {
            character = null;
            inputCharacter= null;
        }
    }

    void Update()
    {
        UpdateInput();
        UpdateChange();
    }

    void UpdateInput()
    {
        if(stay){
            Text.SetActive(true);    
            if(inputCharacter != null && inputCharacter.actionEvent){
                changeroom = true;
            }
        }
        else Text.SetActive(false);
    }

    void UpdateChange()
    {
            if(changeroom){
                audioDoor.Play();
                nextRoom.SetActive(true);
                character.transform.position = point.position;
                lastRoom.SetActive(false);
                character = null;
                inputCharacter = null;
                stay = false;
                changeroom = false;
                Debug.Log("change");
            }
    }
}
