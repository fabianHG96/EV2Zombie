using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0 = false;
    [SerializeField] private Animator animadorPerder;
    public Puntaje puntaje;
    public float timer = 0;
    public Text textoTimer;

    void Start()
    {
        vida = GetComponent<Vida>();
        puntaje.valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        Timer();
    }

    public void Timer()
    {
        timer += Time.deltaTime;

        textoTimer.text = "" + timer.ToString("f0");

        if (timer >= 30)
        {
            animadorPerder.SetTrigger("Mostrar");
            Vida0 = true;
            Invoke("ReiniciarJuego", 2f);
        }
    }

    void RevisarVida()
    {
        if (Vida0) return;
        if (vida.valor <= 0)
        {
            animadorPerder.SetTrigger("Mostrar");
            Vida0 = true;
            Invoke("ReiniciarJuego", 2f);
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        puntaje.valor = 0;
        AudioListener.volume = 1f;
    }


}
