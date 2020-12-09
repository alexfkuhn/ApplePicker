using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleEasy : MonoBehaviour
{
    [HideInInspector] new public Rigidbody rigidbody;
    public bool useGravity = true;
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.useGravity = false;
        if (useGravity){
            rigidbody.AddForce(Physics.gravity * (rigidbody.mass*3));
        }
    }
}
