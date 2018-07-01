using BibliothequeMultiPattern.book;
using BibliothequeMultiPattern.services.users.service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    class LibraryGraphicConsole
    {
        int counter = 3;
        LibraryController controller;
        public LibraryGraphicConsole()
        {
            controller = new LibraryController();
        }

        public void start()
        {
            LibraryController controller = new LibraryController();
            UserDto user;
            Console.WriteLine("------------Connexion------------");
            do {
                String login = this.consoleLogin();
                String mdp = this.consolePassword();
                user = controller.Connect(login, mdp);
            }while (user == null) ;

            Console.WriteLine("------------Logged------------");
            Console.WriteLine("Bienvenue " + user.FirstName + " " + user.Name);
            if(user.Role.Equals("Librarian"))
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
                    this.etatLivre();
                    this.librarianMode();
                    break;
                case 4:
                    this.inscrireEtudiant();
                    this.librarianMode();
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
            Console.WriteLine("1 - Recherche livre");
            Console.WriteLine("2 - Emprunter livre");
            Console.WriteLine("3 - Rendre livre");
            Console.WriteLine("4 - Deconnexion");
            String choise = Console.ReadLine();
            int choix = 0;
            try
            {
                choix = Int32.Parse(choise);
            }
            catch (Exception exception)
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
                    this.inscrireEtudiant();
                    this.librarianMode();
                    break;
                case 4:
                    this.start();
                    break;
                default:
                    Console.WriteLine("Erreur de syntaxe");
                    this.librarianMode();
                    break;
            }
        }

        public void rechercheLivre()
        {
            Console.Write("Entrez le livre à chercher: ");
            String recherche = Console.ReadLine();
            List<Book> resultatRecherche = controller.SearchBook(recherche);
            foreach (var item in resultatRecherche)
            {
                Console.WriteLine("id: " + item.Id + " titre: " + item.Title);
            }
        }

        private void etatLivre()
        {
            Console.Write("Entrez le livre à voir état: ");
            String recherche = Console.ReadLine();
            List<Book> resultatRecherche = controller.SearchBook(recherche);
            foreach (var item in resultatRecherche)
            {
                Console.WriteLine("id: " + item.Id + " titre: " + item.Title + "état: " + item.State);
            }
        }

        public void ajouterLivre()
        {
            counter++;
            Console.Write("Entrez le titre du livre à rajouter: ");
            String titre = Console.ReadLine();
            controller.AddBook(new BookBasic(counter.ToString(), titre));

        }

        private void inscrireEtudiant()
        {
            Console.Write("Entrez le nom de l'étudiant à inscrire: ");
            String name = Console.ReadLine();
            Console.Write("Entrez le prenom de l'étudiant à inscrire: ");
            String firstName = Console.ReadLine();
            Console.Write("Entrez le login de l'étudiant à inscrire: ");
            String login = Console.ReadLine();
            Console.Write("Entrez le mot de passe de l'étudiant à inscrire: ");
            String mdp = Console.ReadLine();
            UserDto student = new UserDto(login, name, firstName, "student", null);
            controller.Add(student, mdp);
        }
    }
}
