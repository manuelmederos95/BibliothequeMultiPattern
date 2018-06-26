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
            LibraryController controller = new LibraryController();
            IUser user;
            Console.WriteLine("------------Connexion------------");
            do {
                String login = this.consoleLogin();
                String mdp = this.consolePassword();
                user = controller.Connect(login, mdp);
            }while (user == null) ;

            Console.WriteLine("------------Logged------------");
            Console.WriteLine("Bienvenue " + user.FirstName + " " + user.Name);
            if(user.GetRole().Equals("Librarian"))
            {
                this.librarianMode();
            }
            else
            {
                this.studentMode();
            }
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

        public void librarianMode()
        {
            Console.WriteLine("------------Librarian Menu------------");
            Console.WriteLine("1 - Recherche livre");
            Console.WriteLine("2 - Ajouter livre");
            Console.WriteLine("3 - Voir état livre");
            Console.WriteLine("4 - Inscrire étudiant");
            Console.WriteLine("5 - Deconnexion");
            String choise = Console.ReadLine();
            int choix = 0;
            try
            {
                choix = Int32.Parse(choise);
            }catch(Exception exception)
            {
                Console.WriteLine("Erreur de syntaxe");
                this.librarianMode();
            }
            switch (choix)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    this.start();
                    break;
                default:
                    Console.WriteLine("Erreur de syntaxe");
                    this.librarianMode();
                    break;
            }
        }

        public void studentMode()
        {
            Console.WriteLine("------------Student Menu------------");
            Console.ReadLine();
        }
 
    }
}
