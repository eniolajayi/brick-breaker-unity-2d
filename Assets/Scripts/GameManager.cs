// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball {get; private set;}
    public Paddle paddle {get; private set;}
    public Brick[] bricks {get; private set;}

    public int score = 0;
    public int lives = 3;
    public int level = 1;
   
   private void Awake()
   {
       DontDestroyOnLoad(this.gameObject);
       SceneManager.sceneLoaded += OnLevelLoaded;
   }

   private void Start()
   {
       NewGame();
   }

   private void NewGame()
   {
       this.score = 0;
       this.lives = 3;
       LoadLevel(1);

   }

   private void LoadLevel(int level)
   {
       this.level = level;
       SceneManager.LoadScene("Level"+level);
   }

   private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
   {
       this.ball = FindObjectOfType<Ball>();
       this.paddle = FindObjectOfType<Paddle>();
       this.bricks = FindObjectsOfType<Brick>();
   }

   public void Hit(Brick brick)
   {
       this.score += brick.points;
   }

   private void ResetLevel()
   {
       this.ball.ResetBall();
       this.paddle.ResetPaddle();

    // To reset bricks after losing a life
    //    for(int i = 0; i <this.bricks.length; i++)
    //    {
    //        this.bricks[i].ResetBrick();
    //    }
   }

   private void GameOver()
   {
       // TODO proper game over functionality
       //SceneManager.LoadScene("GameOver");
       NewGame();

   }

   public void Miss()
   {
       this.lives--;
       if(this.lives > 0)
       {
           ResetLevel();
       } else
       {
           GameOver();
       }
   }
    
}
