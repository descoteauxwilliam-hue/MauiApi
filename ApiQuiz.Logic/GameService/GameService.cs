using ApiQuiz.Data;
using ApiQuiz.Logic.ApiService;
using ApiQuiz.Logic.Data;
using ApiQuiz.Logic.TimingService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace ApiQuiz.Logic.GameService
{
    public class GameService : IEnumerable<Question>
    {
        Api api;
        IData<Question>[] data;


        TimerService timer;
        int Score;

        public GameService(UrlBuilder builder)
        {
            api   = new Api(builder);
            timer = new TimerService();
        }
        public async Task LoadQuestionAsync()
        {
            var result = await api.fetch();
            this.data = result?.Select(r => r.intoQuestion())
                               .ToArray() 
                               ?? Array.Empty<Question>();
        }

        public Question Next()
        {

        }


        public IEnumerator<Question> GetEnumerator()
        {
            foreach(var question in this.quiz ?? Array.Empty<Question>())
            {
                yield return question;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
