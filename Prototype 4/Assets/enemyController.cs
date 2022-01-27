using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed=0;
    private Vector3 lookDirection;
    public bool isDead = false;
    private GameObject lastcol=null;
    private MeshRenderer meshRenderer;
    public Texture[] texture;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection= (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
        if (transform.position.y < -1 && lastcol != null)
        {
            isDead = true;
            lastcol.transform.localScale += transform.localScale;
            lastcol.gameObject.GetComponent<Rigidbody>().mass += 2;
            meshRenderer = lastcol.gameObject.GetComponent<MeshRenderer>();

            meshRenderer.material.EnableKeyword("_NORMALMAP");
            int ran = Random.Range(0, texture.Length);
            Debug.Log(ran);
            meshRenderer.material.SetTexture("_MainTex", texture[ran]);
            Destroy(gameObject);
        }
           
        
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        lastcol = collision.gameObject;
    }
}
