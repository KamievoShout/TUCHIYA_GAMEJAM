using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCloud : MonoBehaviour
{
    [Tooltip("�J�𗎂Ƃ��Ԋu")]
    [SerializeField] float dropInterval = 0.1f;
    float count = 0;// ���Ԍv���p�̕ϐ�
    [Tooltip("�J���̃I�u�W�F�N�g")]
    [SerializeField] GameObject rainObj;
    [Tooltip("�J���𗎂Ƃ��ʒu�𒲐�����p")]
    [Range(-5, 0)]
    [SerializeField] float dropOffSetY;

    void Start()
    {
        
    }

    void Update()
    {
        TimeCount();
    }

    // ���Ԍv��
    void TimeCount()
    {
        // ���Ԃ����Z����
        count += Time.deltaTime;
        // �ݒ莞�Ԃ𒴂����ꍇ
        if (count >= dropInterval)
        {
            // �J����x���Ƀ����_����
            float rx = Random.Range(-0.5f, 0.6f);
            Vector3 offset = new Vector3(rx, dropOffSetY, 0);
            // �J���𐶐�����
            Instantiate(rainObj, transform.position + offset, Quaternion.identity);
            // �J�E���g���Z�b�g
            count = 0;
        }
    }
}
