using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices {
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GamePlayController : MonoBehaviour{

    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private Text infoText;

    [SerializeField]
    private Text scoreText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController; 

    void Awake(){
        animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(GameChoices gameChoices){

        switch(gameChoices){

            case GameChoices.ROCK:
                playerChoice_Img.sprite = rock_Sprite;
                player_Choice = GameChoices.ROCK;
                break;

            case GameChoices.PAPER:
                playerChoice_Img.sprite = paper_Sprite;
                player_Choice = GameChoices.PAPER;
                break;

            case GameChoices.SCISSORS:
                playerChoice_Img.sprite = scissors_Sprite;
                player_Choice = GameChoices.SCISSORS;
                break;
        }

        SetOpponentChoice();

        SetScore(DetermineWinner());
    }

    void SetScore(int outcome){

        int x  = System.Convert.ToInt32(scoreText.text);
        
        if(outcome == 0){
            
        }

        if(outcome == 1){
            x += 1;
            scoreText.text = x.ToString();
        }

        if(outcome == 2){
            x = 0;
            scoreText.text = x.ToString();
        }
    }

    void SetOpponentChoice(){
        int rnd =Random.Range(0,3);

        switch(rnd){

            case 0:
                opponent_Choice = GameChoices.ROCK;
                opponentChoice_Img.sprite = rock_Sprite;
                break;

            case 1:
                opponent_Choice = GameChoices.PAPER;
                opponentChoice_Img.sprite = paper_Sprite;
                break;

            case 2:
                opponent_Choice = GameChoices.SCISSORS;
                opponentChoice_Img.sprite = scissors_Sprite;
                break;
        }
    }

    int DetermineWinner(){
        if(player_Choice == opponent_Choice){
            infoText.text = "Draw!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 0;
        }

        if(player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK){
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 1;
        }

        if(opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK){
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 2;
        }

        if(player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS){
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 1;
        }

        if(opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS){
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 2;
        }

        if(player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER){
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 1;
        }

        if(opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER){
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return 2;
        }

        return 3;
    }

    IEnumerator DisplayWinnerAndRestart(){
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }
}


