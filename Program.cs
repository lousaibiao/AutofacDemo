using System;

namespace autofac
{
  //this is a test line
  //line 2
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
