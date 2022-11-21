using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool CheckPoint1 = true;
    public bool CheckPoint2 = false;

    private void OnTriggerEnter(Collider other)
    {
        //�`�F�b�N�|�C���g�ɒʉ߂����^�C�����擾
        if (other.gameObject.CompareTag("Player"))
        {
            if (CheckPoint1 == true)
            {
                SaveScript.ThisCheckPoint1 = SaveScript.GameTime;
                SaveScript.CheckPointPass1 = true;
            }

            if (CheckPoint2 == true)
            {
                SaveScript.ThisCheckPoint2 = SaveScript.GameTime;
                SaveScript.CheckPointPass2 = true;
            }
        }
    }
}
