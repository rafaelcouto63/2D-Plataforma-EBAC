using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu; // Referência ao menu de pausa

    // Método para pausar o jogo e ativar o menu de pausa
    public void PauseGame()
    {
        Time.timeScale = 0; // Pausa o tempo do jogo
        pauseMenu.SetActive(true); // Ativa o menu de pausa
    }

    // Método para despausar o jogo e desativar o menu de pausa
    public void UnpauseGame()
    {
        Time.timeScale = 1; // Retoma o tempo do jogo
        pauseMenu.SetActive(false); // Desativa o menu de pausa
    }
}


