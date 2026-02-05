using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.Data
{
    internal interface IData<T>
    {
        T GetData();
    }
}
