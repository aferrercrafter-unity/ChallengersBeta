using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {

    //Teleport
    public float teleportCooldown = 5;
    public float teleportTimer = 0;
    public ParticleSystem teleportEffect;
    public Text teleportCooldText;
    public AudioClip teleportSound;    
    public Image teleportMask;

    //Invi
    public float inviCooldown = 5;
    public float inviTimer = 0;
    public ParticleSystem inviEffect;
    public Text inviCooldText;
    public AudioClip inviSound;
    public Image inviMask;
    public WizardLife player;
    public float invi_duration = 3;
    public float invi_active = 0;


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //Teleport

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

        //Invi
        inviTimer -= Time.deltaTime;
        if(player.invi){
            invi_active += Time.deltaTime;
            if (invi_active > invi_duration)
            {
                player.invi = false;
                invi_active = 0;
                inviEffect.Stop();
            }
                
        }
            
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (inviTimer <= 0)
            {
                inviMask.fillAmount = 1.0f;
                inviTimer = inviCooldown;                
                inviEffect.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                player.invi = true;
                AudioSource.PlayClipAtPoint(teleportSound, transform.position);
                inviEffect.Play();
            }
        }
        if (inviTimer > 0)
        {
            inviCooldText.text = ((int)inviTimer).ToString();
            inviMask.fillAmount = inviTimer / inviCooldown;
        }
        else if (inviTimer <= 0)
        {
            inviCooldText.text = "";
            inviMask.fillAmount = 0;
        }



	}
}
