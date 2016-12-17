using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {

    //
    public float teleportCooldown = 5;
    public float teleportTimer = 0;
    public ParticleSystem teleportEffect;
    public Text teleportCooldText;
    public AudioClip teleportSound;
    //public GameObject teleporMask;
    public Image teleportMask;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        teleportTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {            
            if(teleportTimer <= 0)
            {
                teleportMask.fillAmount = 1.0f;
                teleportTimer = teleportCooldown;
                transform.position = transform.position += transform.forward*3;
                teleportEffect.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                AudioSource.PlayClipAtPoint(teleportSound, transform.position);
                teleportEffect.Play();
            }
        }

        if(teleportTimer > 0)
        {
            teleportCooldText.text = ((int)teleportTimer).ToString();
            teleportMask.fillAmount = teleportTimer / teleportCooldown;
        }
        else if(teleportTimer <= 0)
        {
            teleportCooldText.text = "";
            teleportMask.fillAmount = 0;
        }


	}
}
