using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* GameManager:
 * Manages the game, with management of UI elements and tracking/control of the game state set here.
 * 
 * Your game should have one of these, as this is the backbone to the main game loop in a digital game.
 * Because of how intricately it operates with events in the game, it should be the only script that handles UI elements.
 * 
 * Images:
 * Images on the UI have a transform similar to 2D GameObjects. It also has things like an alpha channel
 * that can be changed for changing the element's visibility
 * 
 * Text:
 * Text in a UI element has a string attached that represents the contained text of that UI element. It also has a lot of the same
 * object components as Images (transform, visibility)
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
     * 
     * Remember, all objects have different reference frames to them, which is why the transforms are necessary.
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

    /* This allows us to draw the heart images representing the player's current health, as well as have it follow the player.
     */
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

    /* This method is useful for ensuring that the game loops properly. It also includes a HiScore text updater.
     */
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
