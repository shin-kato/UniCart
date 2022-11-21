using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image SpeedRing;
    public Text SpeedText;
    public Text GearText;
    public Text LapNumberText;
    public Text TotalLapsText;
    public Text LapTimeMinutesText;
    public Text LapTimeSecondsText;
    public Text RaceTimeMinutesText;
    public Text RaceTimeSecondsText;
    public Text BestLapTimeMinutes;
    public Text BestLapTimeSeconds;
    public Text CheckPointTime;
    public GameObject CheckPointDisplay;
    public GameObject NewLapRecord;
    private float DisplaySpeed;
    public int TotalLaps = 3;


    // Start is called before the first frame update
    void Start()
    {
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        GearText.text = "1";
        LapNumberText.text = "0";
        TotalLapsText.text = "/" + TotalLaps.ToString();

        //�Q�[���J�n���ɔ�\��
        CheckPointDisplay.SetActive(false);
        NewLapRecord.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�s�[�h���[�^��UI�\������
        DisplaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedRing.fillAmount = DisplaySpeed;
        SpeedText.text = (Mathf.Round(SaveScript.Speed).ToString());
        GearText.text = (SaveScript.Gear + 1).ToString();

        //���b�v��UI�\������
        LapNumberText.text = SaveScript.LapNumber.ToString();

        //���b�v�^�C���̕\��
        if (SaveScript.LapTimeMinutes <= 9) 
        {
            LapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + " : ";
        }
        else if (SaveScript.LapTimeMinutes >= 10)
        {
            LapTimeMinutesText.text =  (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + " : ";
        }

        if (SaveScript.LapTimeSeconds <= 9)
        {
            LapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
        }
        else if (SaveScript.LapTimeSeconds >= 10)
        {
            LapTimeSecondsText.text = (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
        }

        //���[�X�^�C���̕\��
        if (SaveScript.RaceTimeMinutes <= 9)
        {
            RaceTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + " : ";
        }
        else if (SaveScript.LapTimeMinutes >= 10)
        {
            RaceTimeMinutesText.text = (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + " : ";
        }

        if (SaveScript.RaceTimeSeconds <= 9)
        {
            RaceTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
        }
        else if (SaveScript.RaceTimeSeconds >= 10)
        {
            RaceTimeSecondsText.text = (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
        }

        //�x�X�g�^�C���̍X�V
        if (SaveScript.LapChange == true)
        {
            if (SaveScript.LastLapM == SaveScript.BestLapTimeM)
            {
                if (SaveScript.LastLapS < SaveScript.BestLapTimeS)
                {
                    SaveScript.BestLapTimeS = SaveScript.LastLapS;
                    SaveScript.NewRecord = true;
                }
            }

            if (SaveScript.LastLapM < SaveScript.BestLapTimeM)
            {
                SaveScript.BestLapTimeM = SaveScript.LastLapM;
                SaveScript.BestLapTimeS = SaveScript.LastLapS;
                SaveScript.NewRecord = true;
            }

        }

        //�x�X�g�^�C���̕\��
        if (SaveScript.BestLapTimeM <= 9)
        {
            BestLapTimeMinutes.text = "0" + (Mathf.Round(SaveScript.BestLapTimeM).ToString()) + " : ";
        }
        else if (SaveScript.BestLapTimeM >= 10)
        {
            BestLapTimeMinutes.text = (Mathf.Round(SaveScript.BestLapTimeM).ToString()) + " : ";
        }

        if (SaveScript.BestLapTimeS <= 9)
        {
            BestLapTimeSeconds.text = "0" + (Mathf.Round(SaveScript.BestLapTimeS).ToString());
        }
        else if (SaveScript.BestLapTimeS >= 10)
        {
            BestLapTimeSeconds.text = (Mathf.Round(SaveScript.BestLapTimeS).ToString());
        }

        if (SaveScript.NewRecord == true)
        {
            NewLapRecord.SetActive(true);
            StartCoroutine(LapRecordOff());
        }


        //�`�F�b�N�|�C���g1�̍X�V
        if (SaveScript.CheckPointPass1 == true)
        {
            SaveScript.CheckPointPass1 = false;
            if (SaveScript.LapNumber > 1)
            {
                CheckPointDisplay.SetActive(true);

                if (SaveScript.ThisCheckPoint1 > SaveScript.LastCheckPoint1)
                {
                    //�X�V����UI�ύX
                    CheckPointTime.color = Color.red;

                    //�X�V�^�C���̕\��
                    CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint1 - SaveScript.LastCheckPoint1).ToString();
                    StartCoroutine(CheckPointOff());
                }

                if (SaveScript.ThisCheckPoint1 < SaveScript.LastCheckPoint1)
                {
                    //�X�V����UI�ύX
                    CheckPointTime.color = Color.green;

                    //�X�V�^�C���̕\��
                    CheckPointTime.text = "+" + (SaveScript.LastCheckPoint1 - SaveScript.ThisCheckPoint1).ToString();
                    StartCoroutine(CheckPointOff());
                }
            }
        
        }

        //�`�F�b�N�|�C���g2�̍X�V
        if (SaveScript.CheckPointPass2 == true)
        {
            SaveScript.CheckPointPass2 = false;
            if (SaveScript.LapNumber > 1)
            {
                CheckPointDisplay.SetActive(true);

                if (SaveScript.ThisCheckPoint2 > SaveScript.LastCheckPoint2)
                {
                    //�X�V����UI�ύX
                    CheckPointTime.color = Color.red;

                    //�X�V�^�C���̕\��
                    CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint2 - SaveScript.LastCheckPoint2).ToString();
                    StartCoroutine(CheckPointOff());
                }

                if (SaveScript.ThisCheckPoint2 < SaveScript.LastCheckPoint2)
                {
                    //�X�V����UI�ύX
                    CheckPointTime.color = Color.green;

                    //�X�V�^�C���̕\��
                    CheckPointTime.text = "+" + (SaveScript.LastCheckPoint2 - SaveScript.ThisCheckPoint2).ToString();
                    StartCoroutine(CheckPointOff());
                }
            }
        }
    }

    IEnumerator CheckPointOff()
    {
        yield return new WaitForSeconds(2);
        CheckPointDisplay.SetActive(false);

    }

    IEnumerator LapRecordOff()
    {
        yield return new WaitForSeconds(2);
        SaveScript.NewRecord = false;
        NewLapRecord.SetActive(false);
    }
}
