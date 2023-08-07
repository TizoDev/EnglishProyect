using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuolingoResponse : MonoBehaviour
{
    //Este codigo permite a duolingo expresarse emocionalmente mediante dialogos

    public Text response; //Referencias al texto de dialogo
    public Text finalScoreText;
    public GameObject scoreText1, scoreText2;
    public int finalScore;
    public GameObject textSpace;
    public bool isCorrect = false, call = false, hasBeenCalled = false, showText = false;
    public bool hasStreak = false;
    public RandomAttack attackScript;
    public Animator animator;
    public PlayerLifeSystem playerLifes;

    void Start()
    {
        textSpace.SetActive(false); //Se desactiva el texto al comenzar
        attackScript.nextAttack();
    }

    void Update()
    {
        if(attackScript.hasEnded())
        {
            scoreText1.SetActive(true);
            finalScoreText.text = playerLifes.score.ToString();
            StartCoroutine(shortDelay());
        }
        if(call && !hasBeenCalled) {
            showText = true;
            StartCoroutine(showExpresion());
            hasBeenCalled = true;
        } //Si se llamo a la funcion desde otro script se habilita
        else if(!showText){   
            textSpace.SetActive(false);
        }//Si no no
    }

    IEnumerator showExpresion() {
        if(isCorrect) {
            response.text = "Good job.";
            FindObjectOfType<AudioManager>().Play("Good");
            textSpace.SetActive(true);
            if(hasStreak) playerLifes.addScore(2);
            else playerLifes.addScore(1);
            hasStreak = true;
            yield return new WaitForSeconds(2);
			call = false;
            hasBeenCalled = false;
            showText = false;

            if(!attackScript.completado)
            {
                attackScript.nextAttack();
            }
            else attackScript.blank();

        }
		else {
            response.text = "You are Dumb."; //Se edita el texto dependiendo de la respuesta
            textSpace.SetActive(true);
            hasStreak = false;
            yield return new WaitForSeconds(2);
            int randomNumber = Random.Range(0, 2);
            call = false;
            attackScript.blank();
            if(randomNumber == 0) 
            {
                animator.SetBool("FirstError", true);
                yield return new WaitForSeconds(4);
            }
            else if(randomNumber == 1 || randomNumber == 2)
            {
                animator.SetBool("SecondError", true);
                yield return new WaitForSeconds(7);
            }
            
            attackScript.nextAttack();
            showText = false;
            hasBeenCalled = false;
            if(randomNumber == 0) animator.SetBool("FirstError", false);
            else if(randomNumber == 1) animator.SetBool("SecondError", false);
        } //Y se activa el texto
    }

    IEnumerator shortDelay()
    {
        yield return new WaitForSeconds(2);
        scoreText2.SetActive(true);
    }

}

/*
...................................................................................................
...................................................................................................
.................................mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm......................
.........................mmmmmmmmmmmmmmmm..................................mmmmm...................
...................mmmmmmmmmmm..........mmmmm...............mm................mmm..................
.................mmmm............................................mm.............mmm................
..............mmmm....m..mmmmmm............mmm..............mm......m............mmm...............
............mmmm.................................................mm....m..........mmm..............
...........mmm............mmmmm....................m..........mmm...m....m.........mmm.............
..........mm...........m.........................m................mm...m....m.......mmm............
..........mm.........m............m..................................m..m....m.......mm............
..........mm........m..................................................m..m...........mm...........
.........mm..........................................mmmmmmmmmmmmmm...................mmm..........
........mmm............mmmmmmmm...................mmmmm...mmmmmmmmmmmm.................mmm.........
....mmmm...........mmmmmmmmmmmmmm.............mmmm......mmmmmmmm..mmm..................mmm.......
...mmm...mmmmm.mmm.mmmmmmmmmmmmmmm...........mmm.....mmmmmmmmmmmmmmmmm....m....mmmmmmmm.mmmm.....
..mm...m..................mmmmmmmmmmmmm.......mmmmmmmmm...........mm...m..................mmm....
.mm..m...mm.....................mmmm...........mmmmm......mmm..............mmmmmmmmmm.......mm...
.mm.m..m...mmmmmm................mm.........................mmmm.......mmmmmm......mmmm....m.mm..
.mmm.....mmmmmmmmmm....m.........mm...........................mmmmmmmmmmm.....mm.....mmm...m..mmm
.mmm.....m.......mmmmmmmm........mm...........................................mm......mm...m..mmm
.mmm..m.......mm..mmmm........mmmm.........................................mmmmm.......mm..m...mm
.mm....m......mm...........mmmm................mmmmmmmm................mmmmm...mmmmmm..mm..m...mm
.mmmm...mm..mmmm..........mmmmm....................mm..............mmmmmm.....mmm.mmm.mmm..m..mmm
..mm.mm.....mmmm.......mm..mmmmm.........mmmmmmm...mm..........mmmmmmm........mm......mm......mmm
..mmm....m..mm.mmm...m........mmm..............m.mmm......mmmmmmmm.mm.......mmmm.....mm...m..mmm.
...mmm.....mmmmmmmmm............mmmmmm...............mmmmmmmm......mm....mmmmmm.........mm..mm...
....mmm....mm.mm.mmmmmm...........mmm...........mmmmmmmm..........mmm.mmmmmmmm.......m.....mmm...
.....mm....mmmm..mm..mmmmmmmm........mmmmmmmmmmmmmm..mm..........mmmmmmm..mmm..........mmmmm.....
......mm....mmmm..mm....mmmmmmmmmmmmmmmmmmmm..........mm......mmmmmmmm....mmm............mmm.....
......mm....mmmm..mm...mmm.......mm.......mm..........mmm.mmmmmmmmm.mm...mmm...........mmm.......
......mm....mmmmmmmm...mm........mm.......mm.........mmmmmmmmmmm....mm..mmm...........mmm........
......mm....mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm.......mmmmmm............mm.........
......mm....mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm.mm...........mmm.............mmm.........
......mm.....mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm.......mm.........mmm..............mmm..........
......mm.....mm.mmmmmmmmmmmmmmmmmmmmmmmmmmm.mm..........mmm.....mmmm...............mmm...........
......mm......mm.mm..mm...mm.....mmm........mm...........mm...mmmm...............mmm.............
......mm......mmmmmm.mmm...mm.....mm........mm............mmmmmm................mmm..............
......mm.......mmmm...mmm..mmm....mm........mm.........mmmmmm.......m.....m...mmm................
......mm.........mmmmmmmmm..mm....mmm.......mm..mmmmmmmmm........m.....mm...mmmm.................
.....mm..............mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm.........mm....mm....mmmm....................
....mmm........m..........................................m.....mm....mmmmm......................
....mm..........m....................................mm......m.....mmmmm.........................
....mm............m..............................mm......mm.....mmmmm............................
..mm.....mm........mmm...........mmmmmmmmmm......mm.......mmmmmm.................................
.mm.........m.........................mmm............mmmmm.......................................
.mmm..........mmmmmmmmmmmmmmm.....................mmmmm..........................................
.mmm..........................................mmmmm..............................................
..mmm...................................mm.mmmmm.................................................
...mmmm............................mmmmmmmmmm....................................................
....mmmmm...................mmmmmmmmm............................................................
.......mmmmmmmmmmmmmmmmmmmmmmmm..................................................................

*/
