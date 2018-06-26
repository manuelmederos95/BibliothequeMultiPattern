using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    class LibraryGraphicConsole
    {
        public LibraryGraphicConsole()
        {
            
        }

        public void start()
        {
            Console.WriteLine("------------Bienvenue------------");
            String login = this.consoleLogin();
            String mdp = this.consolePassword();
            
        }
        public String consoleLogin()
        {
            Console.Write("Login: ");
            String login = Console.ReadLine();
            return login;
        }

        public String consolePassword()
        {
            Console.Write("Mot de passe: ");
            String mdp = Console.ReadLine();
            return mdp;
        }
    }
}
