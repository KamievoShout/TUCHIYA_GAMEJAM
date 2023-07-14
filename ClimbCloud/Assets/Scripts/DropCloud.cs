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
    [Tooltip("�_���C���[")]
    [SerializeField] LayerMask cloudLayer; // �`�F�b�N�p�̃��C���[
    [SerializeField] bool thunder = false;
    [SerializeField] float rayLength = 1;
    [SerializeField] Vector3 rayOffSet;
    Vector3 thunderPosi;

    BoxCollider2D box;
    SpriteRenderer sr;

    void Start()
    {
        if (thunder)
        {
            box = rainObj.GetComponent<BoxCollider2D>();
            sr = rainObj.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        TimeCount();
    }

    private void FixedUpdate()
    {
        if (thunder)
        {
            Vector3 startPos = transform.position + rayOffSet;
            Vector3 endPos = startPos;
            // �I���n�_�ɐ��̒��������Z
            endPos.y += rayLength;
            // �J�n�n�_�A�I���n�_�A�F���w�肵�Đ���`��
            Debug.DrawLine(startPos, endPos, Color.red);

            // �����΂������ʂ��擾����
            RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, cloudLayer);
            // �����������`�F�b�N
            if (hit.collider != null)
            {
                Vector3 hitPosi = hit.point;
                //Debug.Log(hitPosi);

                thunderPosi = (transform.position - hitPosi) / 2;
                sr.size = new Vector2(1, thunderPosi.y * 2);
                box.size = new Vector2(1, thunderPosi.y * 2);
                thunderPosi.x = 0;
                thunderPosi.z = 0;
            }
        }
    }

    // ���Ԍv��
    void TimeCount()
    {
        // ���Ԃ����Z����
        count += Time.deltaTime;
        // �ݒ莞�Ԃ𒴂����ꍇ
        if (count >= dropInterval)
        {
            if (!thunder)
            {
                // �J����x���Ƀ����_����
                float rx = Random.Range(-0.5f, 0.6f);
                Vector3 offset = new Vector3(rx, dropOffSetY, 0);
            }
            // �J���𐶐�����
            Instantiate(rainObj, transform.position - thunderPosi, Quaternion.identity);
            // �J�E���g���Z�b�g
            count = 0;
        }
    }
}
