using BibliothequeMultiPattern.book;
using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
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
        UserDto user;
        LibraryController controller;


        int counter = 3;
        public LibraryGraphicConsole()
        {
            controller = new LibraryController();

            initialUser(controller);
        }

        private void initialUser(LibraryController controller)
        {
            /* Création d'un utilisateur initial */
            UserDto userDto = new UserDto("admin", "KANE", "Harry", Role.librarian, null);
            controller.AddUser(userDto, "admin");

            BookBasic book = new BookBasic("FR1", "Chartreuse");
            controller.AddBook(book);

            BookBasic book1 = new BookBasic("FR2", "Code civil 2019 annoté. Édition limitée");
            controller.AddBook(book1);

            BookBasic book2 = new BookBasic("OI1", "Shakespeare, Le Songe d’une nuit d’été");
            controller.AddBook(book2);

            BookBasic book3 = new BookBasic("PO1", "L'Intelligence des plantes");
            controller.AddBook(book3);

            BookBasic book4 = new BookBasic("FU1", "Passage des Ombres");
            controller.AddBook(book4);

            BookBasic book5 = new BookBasic("TY8", "Les Lois naturelles de l'enfant");
            controller.AddBook(book5);

            BookWithDvd book6 = new BookWithDvd("TR8", "Le capitalisme expliqué à ma petite-fille",1);
            controller.AddBook(book6);

            BookWithDvd book7 = new BookWithDvd("PO1", "L'île des chasseurs d'oiseaux",2);
            controller.AddBook(book7);
        }

        public void start()
        {
           
            Console.WriteLine(
                "\n==========================================================" +
                "\n                        Connexion                         " +
                "\n==========================================================");
            do {
                String login = this.consoleLogin();
                String mdp = this.consolePassword();
                user = controller.ConnectUser(login, mdp);
                if(null == user)
                {
                    Console.WriteLine(
                  "\n==========================================================" +
                  "\n                    Connexion - denied                    " +
                  "\n==========================================================");
                    Console.WriteLine(">>> Veuillez entrer des identifiants valides.");
                }
            } while (user == null) ;

            Console.WriteLine(
                  "\n==========================================================" +
                  "\n                   Connexion - success                    " +
                  "\n==========================================================");
            Console.WriteLine(">>> Bienvenue " + user.FirstName + " " + user.Name);

            if (user.Role.Equals(Role.librarian))
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
            Console.Write("\nLogin: ");
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
            Console.WriteLine(
                  "\n==========================================================" +
                  "\n                   Menu Bibliothécaire                    " +
                  "\n==========================================================");
            Console.WriteLine("1 - Rechercher un livre");
            Console.WriteLine("2 - Ajouter un livre");
            Console.WriteLine("3 - Modifier le statut d'un livre");
            Console.WriteLine("4 - Inscrire un(e) étudiant(e)");
            Console.WriteLine("5 - Consulter les derniers mouvements de livres");
            Console.WriteLine("6 - Deconnexion");
            Console.WriteLine("\nVotre choix :");

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
                    this.logLivre();
                    this.librarianMode();
                    break;
                case 6:
                    this.logOut();
                    break;
                default:
                    Console.WriteLine("Erreur de syntaxe");
                    this.librarianMode();
                    break;
            }
        }

        public void studentMode()
        {
            Console.WriteLine(
                "\n==========================================================" +
                "\n                           Menu                           " +
                "\n==========================================================");
            Console.WriteLine("1 - Rechercher un livre");
            Console.WriteLine("2 - Emprunter un livre");
            Console.WriteLine("3 - Rendre un livre");
            Console.WriteLine("4 - Deconnexion");
            Console.WriteLine("\nVotre choix :");
            String choise = Console.ReadLine();
            int choix = 0;
            try
            {
                choix = Int32.Parse(choise);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Erreur de syntaxe");
                this.studentMode();
            }
            switch (choix)
            {
                case 1:
                    this.rechercheLivre();
                    this.studentMode();
                    break;
                case 2:
                    this.emprunteurLivre();
                    this.studentMode();
                    break;
                case 3:
                    this.etatLivre();
                    this.studentMode();
                    break;
                case 4:
                    this.logOut();
                    break;
                default:
                    Console.WriteLine("Erreur de syntaxe");
                    this.librarianMode();
                    break;
            }
        }

        public void rechercheLivre()
        {
            Console.WriteLine(
                 "\n==========================================================" +
                 "\n                   Rechercher un livre                    " +
                 "\n==========================================================");
            Console.Write("Entrez le titre du livre à rechercher: ");
            String recherche = Console.ReadLine();
            List<Book> resultatRecherche = controller.SearchBook(recherche);
            if(resultatRecherche.Count == 0)
            {
                Console.WriteLine("\n>>> Aucun résultat trouvé.");
            } else
            {
                Console.WriteLine(
                "\n----------------------------------------------------------" +
                "\nRésultat de la recherche :"+ recherche+
                "\n----------------------------------------------------------");
                foreach (var item in resultatRecherche)
                {
                    Console.WriteLine("identifiant: " + item.Id + " | titre: " + item.Title + " | status: " + item.State.getName());
                }
            }
            
        }

        public void logLivre()
        {
            Console.WriteLine(
                 "\n==========================================================" +
                 "\n       Liste des derniers mouvements de livres            " +
                 "\n==========================================================");

            List<Event> resultatRecherche = controller.GetEvents(user.Token);
            if (null == resultatRecherche || resultatRecherche.Count == 0)
            {
                Console.WriteLine("\n>>> Aucune nouvelle action.");
            }
            else
            {
                foreach (var item in resultatRecherche)
                {
                    Console.WriteLine( item.Type + " depuis le " + item.Value);
                }
            }

        }

        private void etatLivre()
        {
            Console.WriteLine(
                 "\n==========================================================" +
                 "\n              Modifier le statut d'un livre               " +
                 "\n==========================================================");
            Console.Write("\nRappel des différents statut : En Stock > En Rayon > Emprunté > Temporairement indisponible");

            Console.Write("\nEntrez l'identifiant du livre dont vous souhaitez modifier le status: ");
            String recherche = Console.ReadLine();
            Book book = controller.GetByIdBook(recherche);

            if(null == book)
            {
                Console.WriteLine("\n>>> Veuillez entrer un identifiant valide.");
            }
            else
            {
                Console.WriteLine(
               "\n----------------------------------------------------------" +
               "\nDétail du livre avant modification" +
               "\n----------------------------------------------------------");
                Console.WriteLine("identifiant: " + book.Id + " | titre: " + book.Title + " | status: " + book.State.getName());
                bool result = controller.NextStepForBook(recherche, user.Role);
                if (result)
                {
                    Console.WriteLine("\n>>> Modification de statut reussie.");

                    Console.WriteLine(
                  "\n----------------------------------------------------------" +
                  "\nDétail du livre après modification" +
                  "\n----------------------------------------------------------");
                   book = controller.GetByIdBook(recherche);
                    Console.WriteLine("identifiant: " + book.Id + " | titre: " + book.Title + " | status: " + book.State.getName());

                }
                else
                {
                    Console.WriteLine("\n>>> Vous ne disposez pas de droit suffisant pour modifier le statut de ce livre.\n Seul les étudiant(e)s peuvent emprunter un livre.");

                }
            }
        }

        private void emprunteurLivre()
        {
            Console.WriteLine(
                 "\n==========================================================" +
                 "\n              Emprunter un livre               " +
                 "\n==========================================================");
            Console.Write("\nRappel des différents statut : En Stock > En Rayon > Emprunté > Temporairement indisponible");

            Console.Write("\nEntrez l'identifiant du livre à emprunter: ");
            String recherche = Console.ReadLine();
            Book book = controller.GetByIdBook(recherche);
           
            if (null == book)
            {
                Console.WriteLine("\n>>> Veuillez entrer un identifiant valide.");
            }
            else
            {
                Console.WriteLine(
               "\n----------------------------------------------------------" +
               "\nDétail du livre avant modification" +
               "\n----------------------------------------------------------");
                Console.WriteLine("identifiant: " + book.Id + " | titre: " + book.Title + " | status: " + book.State.getName());
                bool result = controller.NextStepForBook(recherche, user.Role);
                if (result)
                {
                    Console.WriteLine("\n>>> Modification de statut reussie.");

                    Console.WriteLine(
                  "\n----------------------------------------------------------" +
                  "\nDétail du livre après modification" +
                  "\n----------------------------------------------------------");
                    book = controller.GetByIdBook(recherche);
                    Console.WriteLine("identifiant: " + book.Id + " | titre: " + book.Title + " | status: " + book.State.getName());

                }
                else
                {
                    Console.WriteLine("\n>>> Vous ne disposez pas de droit suffisant pour modifier le statut de ce livre.");

                }
            }
        }

        private void rendreLivre()
        {
            Console.WriteLine(
                 "\n==========================================================" +
                 "\n              Rendre un livre               " +
                 "\n==========================================================");
            Console.Write("\nRappel des différents statut : En Stock > En Rayon > Emprunté > Temporairement indisponible");

            Console.Write("\nEntrez l'identifiant du livre à rendre: ");
            String recherche = Console.ReadLine();
            Book book = controller.GetByIdBook(recherche);

            if (null == book)
            {
                Console.WriteLine("\n>>> Veuillez entrer un identifiant valide.");
            }
            else
            {
                Console.WriteLine(
               "\n----------------------------------------------------------" +
               "\nDétail du livre avant modification" +
               "\n----------------------------------------------------------");
                Console.WriteLine("identifiant: " + book.Id + " | titre: " + book.Title + " | status: " + book.State.getName());
                bool result = controller.NextStepForBook(recherche, user.Role);
                if (result)
                {
                    Console.WriteLine("\n>>> Modification de statut reussie.");

                    Console.WriteLine(
                  "\n----------------------------------------------------------" +
                  "\nDétail du livre après modification" +
                  "\n----------------------------------------------------------");
                    book = controller.GetByIdBook(recherche);
                    Console.WriteLine("identifiant: " + book.Id + " | titre: " + book.Title + " | status: " + book.State.getName());

                }
                else
                {
                    Console.WriteLine("\n>>> Vous ne disposez pas de droit suffisant pour modifier le statut de ce livre.");

                }
            }
        }

        public void ajouterLivre()
        {
            counter++;
            Console.WriteLine(
                  "\n==========================================================" +
                  "\n                     Ajouter un livre                     " +
                  "\n==========================================================");
            Console.Write("Entrez le titre du livre à rajouter: ");
            String titre = Console.ReadLine();
            controller.AddBook(new BookBasic(counter.ToString(), titre));
            Console.WriteLine("\n>>> Ajout reussi.");
        }

        private void inscrireEtudiant()
        {
            Console.WriteLine(
                "\n==========================================================" +
                "\n                Ajouter un(e) étudiant(e)                 " +
                "\n==========================================================");
            Console.Write("Entrez le nom de l'étudiant à inscrire: ");
            String name = Console.ReadLine();
            Console.Write("Entrez le prenom de l'étudiant à inscrire: ");
            String firstName = Console.ReadLine();
            Console.Write("Entrez le login de l'étudiant à inscrire: ");
            String login = Console.ReadLine();
            Console.Write("Entrez le mot de passe de l'étudiant à inscrire: ");
            String mdp = Console.ReadLine();
            UserDto student = new UserDto(login, name, firstName, Role.student, null);
            bool result = controller.AddUser(student, mdp);
            if (result)
            {
                Console.Write("\n>> Ajout réussi.");
            } else
            {
                Console.Write("\n>> Une erreur est survenue.");

            }
        }

        private void logOut()
        {
            controller.LogOut(user.Token);

            Console.WriteLine("\n>>> Déconnection reussi, redémarage.");

            start();
        }
    }
}
