using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform spawnPoint;
    public float floatSpeed = 20f;
    public float destroyTime = 3f;
    public float gravity = 1f;

    public void ShowFloatingText(Vector3 spawnPos)
    {
        GameObject floatingText = Instantiate(textPrefab, spawnPos + new Vector3(0.5f,0.5f,0.5f), Quaternion.identity);

        Rigidbody rigidbody = floatingText.AddComponent<Rigidbody>();
        rigidbody.useGravity = false; // �������� ��������� ��������

        Destroy(floatingText, destroyTime);
        StartCoroutine(FloatingAnimation(floatingText, rigidbody));
    }

    IEnumerator FloatingAnimation(GameObject floatingText, Rigidbody rigidbody)
    {
        float timer = 0f;

        while (timer < destroyTime)
        {
            // ��� ������ ���� �����
            floatingText.transform.Translate(Vector3.left * floatSpeed * Time.deltaTime);
            floatingText.transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

            // ��������� ���������
            rigidbody.useGravity = true;

            timer += Time.deltaTime;
            yield return null;
        }
    }
}