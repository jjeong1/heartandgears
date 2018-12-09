using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using UnityEngine.SceneManagement;

public class ParticleSize : MonoBehaviour {

    [SerializeField]
    Transform particleAspects;
    [SerializeField]
    Light lightRadius;

    public Animator birdDies;
    public Animator gearAppearance;

    public GameObject bird;
    public GameObject spher;

    public float particleCurrSize;
    public float lightCurrRadius;
    private Rigidbody rb;
    private float particleYchange;

    void changeParticleSize()
    {
        particleAspects.localScale = new Vector3(particleCurrSize, particleCurrSize, particleCurrSize);
        lightRadius.range = lightCurrRadius;

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
        if ((OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.UpArrow)) && particleCurrSize < 3)
        {
            particleCurrSize += (float)0.05;
            lightCurrRadius += (float)0.08;
        }

        changeParticleSize();
        if (particleCurrSize >= 3)
        {
            particleYchange += 0.0001f;
            particleAspects.localPosition -= new Vector3(0.1f, 0, 0);
            particleAspects.localPosition += new Vector3(0, particleYchange, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        if (other.gameObject.CompareTag("birdColDetector"))
        {
            Debug.Log("it collided!");
            birdDies.SetTrigger("KillBird");
            

            spher.SetActive(false);
            gearAppearance.SetTrigger("GetGear");
            bird.SetActive(false);            
        }

    }
}
