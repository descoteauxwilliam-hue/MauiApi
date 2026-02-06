using System.Collections;
using System.Collections.Generic;

using ApiQuiz.Data;
using ApiQuiz.Logic.TimingService;
using ApiQuiz.ApiService;

namespace ApiQuiz.GameService;

public class QuizGame : IGame<QuizGame>, IEnumerable<(int, string)[]> {
    Api api;

    Question? current_question; // starts null
    Question[] _questions;      //list of question

    int score;
    TimerService timer;

    public QuizGame(Api api){
        this.api = api;

        current_question = null;
        _questions = Array.Empty<Question>();
        score     = 0;
        timer = new TimerService();
    }

    private async void LoadDataAsync(){
        var result = await api.fetch();

        this._questions = result?.Select(r => r.intoQuestion())
                                 .ToArray() 
                                 ?? Array.Empty<Question>();
    }

    public void CheckAnswer(int x) {
      if(current_question?.IsGoodAnswer(x) == true)
      {
          score+=1;
      }
    }

    //implement iterator
    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }

    public IEnumerator<(int, string)[]> GetEnumerator(){
        foreach(var q in _questions)
        {
          current_question = q;
          yield return q.GetAnswers(); //hides good answer
        }
    } 
    //implement DI
    public QuizGame play(){
        this.LoadDataAsync();
        return this;
    }
}
