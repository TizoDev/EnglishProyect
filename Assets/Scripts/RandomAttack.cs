using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttack : MonoBehaviour
{
    public GameObject[] ataques;
    public bool[] usados;
    public bool completado, wait = false;
    int rand = 0;

    public void nextAttack()
    {
        ataques[rand].SetActive(false);
        if(wait) completado = true;
        if(!completado)
        {
            do
            {
                rand = Random.Range(0, ataques.Length);
            }while(usados[rand]);

            ataques[rand].SetActive(true);
            usados[rand] = true;

            int completedAttacks = 0;
            for(int i=0; i < ataques.Length; i++)
            {
                if(usados[i]) completedAttacks++;
            }
            if(completedAttacks == ataques.Length) wait = true;
        }
    }

    public void blank()
    {
        for(int i=0; i < ataques.Length; i++) ataques[i].SetActive(false);
    }

    public bool hasEnded()
    {
        return completado;
    }
}
