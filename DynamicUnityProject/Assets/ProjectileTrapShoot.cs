using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrapShoot : MonoBehaviour
{
    //Public Variables
    public GameObject projectile;
    
    public int maxNumberProjectiles;
    public Transform firingLocal,destroyLocal;

    //Private Variables
    private int numberProj;
    
    // Start is called before the first frame update
    void Start()
    {
        numberProj = 0;        
    }


    // Update is called once per frame
    void Update()
    {
        if (numberProj != maxNumberProjectiles)
        {
            projectile.name = "Proj" + numberProj.ToString();
            Instantiate(projectile,firingLocal.position,projectile.transform.rotation);
            numberProj += 1; 
        }
        if (GameObject.Find("Proj0(Clone)") == null)
        {
            numberProj -= 1;
        }

    }
}
