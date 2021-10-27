using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLock : MonoBehaviour
{

    [SerializeField] AudioSource _audioLock;
    [SerializeField] AudioSource _audioKey;
    bool flag = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            flag = true;
            var a = GameObject.FindGameObjectWithTag("Key");
            _audioKey.Play();
            Destroy(a);
            Debug.Log("Key is up");
        }

        if (other.gameObject.CompareTag("FirePlace"))
        {
            if (flag)
            {
                Destroy(other.gameObject);
                _audioLock.Play();
                Debug.Log("Door is down");
            }
        }
    }        
}
