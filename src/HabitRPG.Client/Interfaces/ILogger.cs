namespace HabitRPG.Client
{
   public interface ILogger
   {
      void Write(string text);
      void Write(string format, params object[] parameters);
   }
}