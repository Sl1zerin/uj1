using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{   
    [Header("Переменные для включения лапы")]
    #region Вкл.Выкл лампы
    public bool Stay;
    public GameObject[] lampLight;
    public GameObject Text;
    public bool active;
    public string nameObject;
    public InputCharacter inputCharacter;

    private bool open_closet = false;

    private float timeOut;

    #endregion

    [Header("Переменные для коректного расположения теста объекта")]
    #region 
    public SettingOptionsCamera settingText;

    #endregion

    #region Работа со звуком

    public AudioSource audioOpen;

    #endregion


    #region Определения нахождения объекта в триггере
    public GameObject character;
    private void OnTriggerEnter(Collider other) {
        Stay=true;
        if(other.tag == "Character") 
        {
            character = other.gameObject;
            inputCharacter=character.GetComponent<InputCharacter>();
        }
    }
    private void OnTriggerStay(Collider other) {
        Stay=true;
        if(other.tag == "Character") 
        {
            character = other.gameObject;
            inputCharacter=character.GetComponent<InputCharacter>();
        }
    }
    private void OnTriggerExit(Collider other) {
        Stay=false;
        if(other.tag == "Character") 
        {
            character = null;
            inputCharacter=null;
        }
    }

    #endregion
    void Start() {
        AwakeText();
    }

    void  AwakeText()
    {
        for (int i = 0; i < lampLight.Length; i ++)
        {
            lampLight[i].SetActive(active);
        }
        //Text.transform.rotation= Quaternion.Euler(settingText.RotX,settingText.RotY,settingText.RotZ);
    }
    void Update()
    {
        
    ActionsObject();
    ActiveLight();
    }

    void ActionsObject()
    {
        if (Stay == true ){
            Text.SetActive(true);
            if (inputCharacter.actionEvent && !open_closet){
                open_closet = true;
            
            }
        }
        else Text.SetActive(false);
    }

    void ActiveLight()
    {
        if(open_closet){
            timeOut += Time.deltaTime;
            if(timeOut < 0.3)
            {
                if (active==true){
                    audioOpen.Play();
                    for (int i = 0; i < lampLight.Length; i ++)
                    {
                        lampLight[i].SetActive(false);
                    }   
                    active=false;
                    open_closet = false;
                }
                else if (active==false){
                    audioOpen.Play();
                    for (int i = 0; i < lampLight.Length; i ++)
                    {
                        lampLight[i].SetActive(true);
                    }
                    active=true;
                    open_closet = false;
                }
            }
            else {
                open_closet = false;
                timeOut = 0;
            }
        }
    }
}
