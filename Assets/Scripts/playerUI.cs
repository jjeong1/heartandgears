using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerUI : MonoBehaviour {

    [SerializeField]
    RectTransform playerHealth;
    [SerializeField]
    private float playerDamagedSpeed = 0.01f;

    public float playerStartingHealth = 1;
    public float playerCurrHealth = 1;

    void changeHealth()
    {
        playerCurrHealth -= playerDamagedSpeed * (float)Time.deltaTime;
    }

    void SetHealthAmount (float _currHealth)
    {
        playerHealth.localScale = new Vector3(1f, _currHealth, 1f) ;

    }

    void Update()
    {
        if (playerCurrHealth >=0)
        {
            changeHealth();
        }
        SetHealthAmount(playerCurrHealth);
        if (playerCurrHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
