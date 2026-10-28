using System.IO;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 2f;
    public float travelDistance = 4f;

    private Vector3 initialPosition;
    private float timeCounter = 0f;
    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float progress = (Mathf.Sin(timeCounter - Mathf.PI / 2f) + 1f) / 2f;

        Vector3 localOffset = transform.right * (progress * travelDistance);

        transform.localPosition = initialPosition + localOffset;
    }
}
