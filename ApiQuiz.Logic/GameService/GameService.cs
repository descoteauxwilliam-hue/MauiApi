using ApiQuiz.Data;
using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.TimingService;
using System.Collections;
using ApiQuiz.GameService;

namespace ApiQuiz.Logic.GameService
{
    public class GameService :IGame<GameService>, IEnumerable<(int, string)[]>
    {
        Api _api;
        TimerService timer;

        Question[] questions;
        Question?   currentQuestion;
        int score;


        public GameService(UrlBuilder builder)
        {
            _api   = new Api(builder);
            timer = new TimerService();

            questions = Array.Empty<Question>();
            currentQuestion = null;
            score  = 0;
        }
        public async void LoadQuestionAsync()
        {
            var result = await _api.fetch();
            this.questions = result?.Select(r => r.intoQuestion())
                                    .ToArray() 
                                    ?? Array.Empty<Question>();
        }


        public void CheckAnswer(int x){
            if(currentQuestion?.IsGoodAnswer(x) == true) {
                score += 1;
            }
        }

        public IEnumerator<(int, string)[]> GetEnumerator()
        {
            foreach(var q in this.questions)
            {
                currentQuestion = q;
                yield return q.GetAnswers();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public GameService play(){
            this.LoadQuestionAsync();
            return this;
        }
    }
}
