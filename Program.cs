using System;

namespace autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

  /*
  这个接口用于write output方法和Console这个类的解耦。（因为调用writeoutpu的方法的时候用了console这个类）
  我们的关注点不在于他如何执行writeoutput这个方法，只要在意他能做。
   */
  public interface IOutput
  {
    void Write(string content);
  }

  /*
  通过实现接口来定义我们write output方法的具体实现（是用console来实现的）
  技术上来说，很容易可以把具体的实现放到比如Debug窗， Trace窗，或者其他任何地方。
   */
  public class ConsoleOutput : IOutput
  {
    public void Write(string content)
    {
      Console.WriteLine(content);
    }
  }

  // This interface decouples the notion of writing
  // a date from the actual mechanism that performs
  // the writing. Like with IOutput, the process
  // is abstracted behind an interface.
  /*
  这个接口解耦了write data和实际的writing方法的机制。
  
   */
   
  public interface IDateWriter
  {
    void WriteDate();
  }

  // This TodayWriter is where it all comes together.
  // Notice it takes a constructor parameter of type
  // IOutput - that lets the writer write to anywhere
  // based on the implementation. Further, it implements
  // WriteDate such that today's date is written out;
  // you could have one that writes in a different format
  // or a different date.
  /*
  TodayWriter这个里汇聚了所有东西。
  注意一下他把IOutput这个接口作为自己构造函数的参数。
  这使得这个writer可以根据IOutput这个接口的具体实现向任何地方做输出操作。
  进一步来说，实现了writedata所以今天得日期被打印出来。
  你可以自己实现一个其他的，以不同的形式，或者不同的日期。
   */
  public class TodayWriter : IDateWriter
  {
    private IOutput _output;
    public TodayWriter(IOutput output)
    {
      this._output = output;
    }

    public void WriteDate()
    {
      this._output.Write(DateTime.Today.ToString());
    }
  }
}
