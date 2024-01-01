using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cut"))
        {
            Debug.Log("剪刀");

            //
            var copy = GameObject.Instantiate(gameObject);
            var rigid = copy.GetComponent<Rigidbody>();
            rigid.useGravity = true;
            rigid.isKinematic = false;
            copy.GetComponent<Collider>().isTrigger = false;
            copy.transform.position = transform.position;
            Destroy(copy.GetComponent<CutObject>());
            rigid.AddForce(Vector3.forward, ForceMode.Impulse);

            //
            gameObject.SetActive(false);
        }
    }
}