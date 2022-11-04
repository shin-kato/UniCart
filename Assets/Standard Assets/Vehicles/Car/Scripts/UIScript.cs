using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image SpeedRing;
    public Text SpeedText;
    public Text GearText;
    private float DisplaySpeed;


    // Start is called before the first frame update
    void Start()
    {
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        GearText.text = "1";
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�s�[�h���[�^��UI�\������
        DisplaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedRing.fillAmount = DisplaySpeed;
        SpeedText.text = (Mathf.Round(SaveScript.Speed).ToString());
        GearText.text = (SaveScript.Gear + 1).ToString();
    }
}
