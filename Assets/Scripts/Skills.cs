using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {

    //
    public float teleportCooldown = 5;
    public float teleportTimer = 0;
    public ParticleSystem teleportEffect;
    public Text teleportCooldText;
    public GameObject teleporMask;

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
                teleporMask.SetActive(true);
                teleportTimer = teleportCooldown;
                transform.position = transform.position += transform.forward*3;
                teleportEffect.Simulate(1);
            }
        }

        if(teleportTimer > 0)
        {
            teleportCooldText.text = ((int)teleportTimer).ToString();
        }
        else if(teleportTimer <= 0 && teleporMask.activeInHierarchy)
        {
            teleportCooldText.text = "";
            teleporMask.SetActive(false);
        }


	}
}
