using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   
    
    
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0;

        while (elapsed < duration)
        {
            float x = Random.Range(originalPos.x + 0.5f, originalPos.x - 0.5f) * magnitude;
            float y = Random.Range(originalPos.y + 0.5f, originalPos.y - 0.5f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;

    }
    

}
