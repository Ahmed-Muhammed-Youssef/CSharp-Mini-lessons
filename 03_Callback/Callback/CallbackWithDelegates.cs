using System.ComponentModel;

namespace Callback
{
    // Define a delegate that takes a string parameter.
    public delegate void TaskCompletedCallBack(string taskResult);
    // Define a class that contains a method that takes a TaskCompletedCallBack delegate as an argument.
    public class CallBack
    {
        public void StartNewTask(TaskCompletedCallBack taskCompletedCallBack)
        {
            Console.WriteLine("StartNewTask is invoked");
            if (taskCompletedCallBack != null)
            {
                taskCompletedCallBack("Calledback from inside the StartNewTask method");
            }
        }
    }
    // Define a class that contains a method that creates a TaskCompletedCallBack delegate and passes it to StartNewTask.
    public static class DelegateCaller
    {
        public static void Test()
        {
            TaskCompletedCallBack callback = TestCallBack;
            CallBack testCallBack = new CallBack();
            testCallBack.StartNewTask(callback);
        }

        public static void TestCallBack(string result)
        {
            Console.WriteLine(result);
        }
    }

}
