using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    class LibraryGraphicConsole
    {
        LibraryController controller;
        public LibraryGraphicConsole()
        {
            controller = new LibraryController();
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
                    this.rechercheLivre();
                    this.librarianMode();
                    break;
                case 2:
                    this.ajouterLivre();
                    this.librarianMode();
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

        public void rechercheLivre()
        {
            Console.Write("Entrez le livre à chercher: ");
            String recherche = Console.ReadLine();
            List<Book> resultatRecherche = controller.SearchBook(recherche);
        }

        public void ajouterLivre()
        {
            Console.Write("Entrez le type de livre à rajouter: ");
            String type = Console.ReadLine();
            Console.Write("Entrez le titre du livre à rajouter: ");
            String titre = Console.ReadLine();
        }
 
    }
}
