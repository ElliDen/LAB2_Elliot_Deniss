using UnityEngine;
using System.Collections;


public class TransformFunctions : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;



    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(transform.position.z <= 20f)
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
        if(transform.position.z <= 5f)
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
   
    }

}

