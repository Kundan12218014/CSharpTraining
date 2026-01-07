using System;
namespace CricketMatchScoreNamespace
{
  public class CricketMatch
  {

    int[] playerScores;
    int currentIndex;

    public CricketMatch()
    {
      playerScores=new int[5];
      currentIndex =0;
    }
    public void AddPlayerScore(int score)
    {
      if (score < 0 || score > 50)
      {
        throw new ArgumentException("Invalid score. Score must be between 0 and 50.");
      }
      else if (currentIndex > 5)
      {
        throw new InvalidOperationException("Cannot add more than 5 player scores.");
      }
      else
      {
        playerScores[currentIndex] = score;
        currentIndex++;
      }
    }
    public int CalculateTotalScore()
    {
      int totalScore = 0;
      for (int i = 0; i < currentIndex; i++)
      {
        totalScore += playerScore[i];
      }
      return totalScore;
    }
  }
  public class Program
  {
    public static void Demo()
    {

        CricketMatch match = new CricketMatch();
      try
      {

        string stringScore = Console.ReadLine();
        string[] playerScore = stringScore.Split(' ');
        for (int i = 0; i < playerScore.Length; i++)
        {
          match.AddPlayerScore(Convert.ToInt32(playerScore[i]));
        }
      }
      catch (ArgumentException e)
      {
        System.Console.WriteLine(e.Message);
      }
      catch (InvalidOperationException e)
      {
        System.Console.WriteLine(e.Message);
      }
      catch(FormatException e)
      {
        System.Console.WriteLine(e.Message);
      }
      finally
      {
        int calculatedTotalScore= match.CalculateTotalScore();
        System.Console.WriteLine($"Total score of the cricket team: {calculatedTotalScore}");
      }
    }
  }
}