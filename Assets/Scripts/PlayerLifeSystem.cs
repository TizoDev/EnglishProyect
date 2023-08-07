using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeSystem : MonoBehaviour
{
    public int health = 5;
    public int score = 0;
    public bool canDamage = true;

    public Text scoreText;
    public Image healthBar;

    void Update()
    {
        healthBar.fillAmount = health / 5f;
        if(health <= 0)
        {
            score--;
            scoreText.text = score.ToString();
            health = 5;
        }
    }

    public void damagePlayer()
    {
        if(canDamage)
        {
            health--;
            FindObjectOfType<AudioManager>().Play("Damage");
            StartCoroutine(immunityTime());
        }
    }

    public void addScore(int num)
    {
        score = score + num;
        scoreText.text = score.ToString();
    }

    IEnumerator immunityTime()
    {
        canDamage = false;
        yield return new WaitForSeconds(0.1f);
        canDamage = true;
    }
}
