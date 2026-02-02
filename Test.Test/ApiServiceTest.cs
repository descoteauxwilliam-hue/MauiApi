using ApiQuiz.ApiService;
using ApiQuiz.Data;


namespace Test.Test;

public class TestApi
{
    [Fact]
    public void FetchData()
    {
          const int size = 11;

          UrlBuilder builder = new UrlBuilder()
                              .SetCategory(Category.History)  
                              .SetAmount(size);

          Api service = new Api(builder);

          var task = service.fetch();
          List<Question> questions = task.Result
                                         .ToList<Question>();
          
          Assert.True(size == questions.Count);

          foreach(Question q in questions)
          {
            Console.WriteLine(q.ToString());
          }
          
    }
}
