namespace ExempleService
{
    public class Command : ICommand
    {
        public string CommandWithGet(string strCommand)
        {
            return "Voici la command Get :" + strCommand;
        }

        public string CommandWithPost(string strCommand)
        {
            return "Voici la command  Post:" + strCommand;
        }
    }
}