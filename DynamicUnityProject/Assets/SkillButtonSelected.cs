using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonSelected : MonoBehaviour
{
    public Image MeleeSkill, ProjSkill, MoveSkill;
    private bool Move_selected, Melee_selected, Proj_selected;
    public Color PC, MC, MeC;
    public GameObject[] Links;
    public Image[] Glows;
    // Start is called before the first frame update
    void Start()
    {
        Move_selected = false;
        Melee_selected = false;
        Proj_selected = false;

         /*PC = ProjSkill.color;
         MC = MoveSkill.color;
         MeC = MeleeSkill.color;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MeleeSelected()
    {
        if (Melee_selected)
        {
            Glows[0].color = Color.white;
            Melee_selected = false;
            MeleeSkill.color = MeC;
        }
        else
        {
            Melee_selected = true;
            //MeleeSkill.color = Color.red;
            Glows[0].color = Color.red;
        }
    }
    public void ProjectileSelected()
    {

        if (Proj_selected)
        {
            Proj_selected = false;
            ProjSkill.color = PC;
            Glows[1].color = Color.white;
            
        }
        else
        {
            Proj_selected = true;
            //ProjSkill.color = Color.red;
            Glows[1].color = Color.red;
            var main = Links[1].GetComponent<ParticleSystem>().main;
            main.startColor = new Color(1, 0, 0);
        }
    }

    public void MoveSelected()
    {
        if (Move_selected)
        {
            Move_selected = false;
            MoveSkill.color = MC;
            Glows[2].color = Color.white;
        }
        else
        {
            Move_selected = true;
           //MoveSkill.color = Color.red;
            Glows[2].color = Color.red;
        }
    }
}
