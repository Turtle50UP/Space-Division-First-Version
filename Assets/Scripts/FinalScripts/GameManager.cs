using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* GameManager:
 * Manages the game, with management of UI elements and tracking/control of the game state set here.
 */

public class GameManager : MonoBehaviour
{
    public int score = 0;
    int hiScore = 0;
    public int health;
    public int maxHealth;
    public Vector2 offset;
    public Vector2 charOffset;
    public Spawner sp;
    Vector2 initPos;

    public Camera thisCam;
    public Text uiScore;
    public Text divDisp;
    public GameObject player;
    public Text hiScoreTxt;

    public Text[] enemyLabels;
    public Image[] hearts;
    public Vector2 heartsOffset;
    public Vector2 heartOffset;

    private void Start()
    {
        hiScoreTxt.text = "HiScore = 0";
        UpdateScore();
        initPos = player.transform.position;
    }
    
    void Update()
    {
        DrawUIElements();
    }

    /* We do the per frame draws for the UI elements which need to be redrawn each frame.
     * Specifically, this relates to the UI elements which follow players and enemies.
     * Following the player is simply transforming player coordinates in world space to screen space,
     * and setting the anchorePosition of the UI element to be relative to the player's postition.
     */
    void DrawUIElements()
    {
        if(health <= 0)
        {
            Reset();
        }
        Vector3 playerLocInScreen = thisCam.WorldToScreenPoint(player.transform.position);
        divDisp.rectTransform.anchoredPosition = (Vector2)playerLocInScreen + offset;
        uiScore.rectTransform.anchoredPosition = (Vector2)playerLocInScreen + offset + charOffset;
        DrawHealth();
        DrawLabels();
    }

    public void DrawHealth()
    {
        Vector3 playerLocInScreen = thisCam.WorldToScreenPoint(player.transform.position);
        for (int i = 0; i < hearts.Length; i++)
        {
            Vector2 heartloc = (heartOffset * i) + heartsOffset + (Vector2)playerLocInScreen;
            hearts[i].rectTransform.anchoredPosition = heartloc;
            if(i < health)
            {
                hearts[i].canvasRenderer.SetAlpha(1);
            }
            else
            {
                hearts[i].canvasRenderer.SetAlpha(0);
            }
        }
    }

    private void Reset()
    {
        if(hiScore < score)
        {
            hiScore = score;
            hiScoreTxt.text = "HiScore = " + hiScore.ToString();
        }
        score = 0;
        health = maxHealth;
        player.transform.position = initPos;
        sp.DespawnAll();
    }

    public void DrawLabels()
    {
        SetVisibleLabels();
        for (int i = 0; i < enemyLabels.Length; i++)
        {
            if(enemyLabels[i].text != "")
            {
                Vector3 enemyLocInScreen = thisCam.WorldToScreenPoint(sp.spawnedList[i].transform.position);
                enemyLabels[i].rectTransform.anchoredPosition = (Vector2)enemyLocInScreen + offset;
            }
        }
    }

    void SetVisibleLabels()
    {
        for(int i = 0; i < sp.spawnedList.Count; i++)
        {
            EnemyManager em = sp.spawnedList[i].GetComponent<EnemyManager>();
            enemyLabels[i].text = em.value.ToString();
        }
        for(int i = sp.spawnedList.Count; i < enemyLabels.Length; i++)
        {
            enemyLabels[i].text = "";
        }
    }

    public void UpdateScore()
    {
        uiScore.text = "Score = " + score.ToString();
    }

    public void UpdateDivText(int div)
    {
        divDisp.text = "Current Divisor = " + div.ToString();
    }
}
