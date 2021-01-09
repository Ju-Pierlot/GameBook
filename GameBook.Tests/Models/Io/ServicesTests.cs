using System.Collections.Generic;
using System.IO;
using GameBook.Models.Answer;
using GameBook.Models.Book;
using GameBook.Models.History;
using GameBook.Models.Io;
using GameBook.Models.Paragraph;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels;
using NUnit.Framework;

namespace GameBook.Tests.Models.Io
{
    class ServicesTests
    {
        //Test d’acceptation US8 #1.1
        [Test, Order(1)]
        public void TestUS8_1_1()
        {
            string resource = @"..\..\..\Saves\";
            string applicationSave = Path.Combine(resource, @"saveTest.txt");

            Assert.IsFalse(File.Exists(applicationSave));
        }
        //Test d’acceptation US8 #1.2
        [Test, Order(2)]
        public void TestUS8_1_2()
        {
            string resource = @"..\..\..\Saves\";
            string applicationSave = Path.Combine(resource, @"saveTest.txt");

            createServices(@"saveTest.txt").Start();

            Assert.IsTrue(File.Exists(applicationSave));
            File.Delete(applicationSave);
        }
        //Test d’acceptation US8 #2
        [Test]
        public void TestUS8_2()
        {
            string path = @"..\..\..\Saves\HistoriesTest\BookTest.json";
            string line;

            //Le fichier de sauvegarde n'existe pas
            Assert.IsFalse(File.Exists(path));

            IServices services = createServices(@"saveTestBook.txt");
            //Lecture du livre test et création d'un fichier de sauvegarde dédié
            services.Start();

            //Le fichier existe
            Assert.IsTrue(File.Exists(path));

            IReadingSession rs = new ReadingSession(services.Book, services.History);

            rs.Next("A1");
            rs.Next("A2");

            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadToEnd();
            }
            //Le fichier de sauvegarde est vide (Pas encore de sauvegarde)
            Assert.AreEqual("", line);

            services.Save();

            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadToEnd();
            }

            //Résultat après sauvegarde
            Assert.AreEqual("{\"History\":[0,1,2],\"AlreadyRead\":[0,1],\"LastId\":0}", line);

            //Suppression du fichier
            File.Delete(path);
        }
        //Test d’acceptation US8 #3
        [Test]
        public void TestUS8_3()
        {
            string path = @"..\..\..\Saves\HistoriesTest\US8_3.json";

            IServices services = createServices(@"US8_3.txt");
            services.Start();

            IReadingSession rs = new ReadingSession(services.Book, services.History);

            rs.Next("A1");

            //Simulation de fermeture de l'application
            services.Save();

            //Création d'une nouvelle session
            IServices servicesToTest = createServices(@"US8_3.txt");
            //Chargement de la sauvegarde
            servicesToTest.Start();

            IReadingSession rsToTest = new ReadingSession(servicesToTest.Book, servicesToTest.History);

            //Paragraphe affiché à l'ouverture
            Assert.AreEqual("P2", rs.Paragraph);

            IList<string> lines = new List<string>()
            {
                "Paragraphe 1 : P1",
                "Paragraphe 2 : P2"
            };

            //Paragraphes déjà lus à l'ouverture
            for (int i = 0; i < rs.ParagraphsRead.Count; i++)
            {
                Assert.AreEqual(lines[i], rs.ParagraphsRead[i]);
            }
            //Suppression du fichier
            File.Delete(path);
        }
        //Test d’acceptation US8 #4
        [Test]
        public void TestUS8_4()
        {
            string path = @"..\..\..\Saves\HistoriesTest\US8_3.json";

            IServices services = createServices(@"US8_3.txt");
            services.Start();

            IReadingSession rs = new ReadingSession(services.Book, services.History);

            rs.Next("A1");
            rs.Next("A2");
            rs.Back();

            //Simulation de fermeture de l'application
            services.Save();

            //Création d'une nouvelle session
            IServices servicesToTest = createServices(@"US8_3.txt");
            //Chargement de la sauvegarde
            servicesToTest.Start();

            IReadingSession rsToTest = new ReadingSession(servicesToTest.Book, servicesToTest.History);

            //Paragraphe affiché à l'ouverture
            Assert.AreEqual("P2", rs.Paragraph);

            IList<string> lines = new List<string>()
            {
                "Paragraphe 1 : P1",
                "Paragraphe 2 : P2",
                "Paragraphe 3 : P3"
            };

            //Paragraphes déjà lus à l'ouverture
            for (int i = 0; i < rs.ParagraphsRead.Count; i++)
            {
                Assert.AreEqual(lines[i], rs.ParagraphsRead[i]);
            }
            //Suppression du fichier
            File.Delete(path);
        }
        //Test d’acceptation US9 #2
        [Test]
        public void TestUS9_2()
        {
            IServices s = createServices("US9.txt");
            s.Start();

            IReadingSession rs = new ReadingSession(s.Book, s.History);

            Assert.AreEqual("P1", rs.Paragraph);

            rs.Next("A1");

            Assert.AreEqual("P2", rs.Paragraph);

            //On quitte l'application
            s.Save();

            //On relance
            IServices sx = createServices("US9.txt");
            sx.Start();

            IReadingSession rsx = new ReadingSession(s.Book, s.History);

            Assert.AreEqual("P2", rsx.Paragraph);

            File.Delete(@"..\..\..\Saves\HistoriesTest\US9p1.json");
        }
        //Test d’acceptation US9 #3, #4
        [Test]
        public void TestUS9_3_4()
        {
            IServices s = createServices("US9.txt"); //Load f1
            s.Start();

            IReadingSession rs = new ReadingSession(s.Book, s.History);

            Assert.AreEqual("P1", rs.Paragraph);

            rs.Next("A1");

            Assert.AreEqual("P2", rs.Paragraph);

            s.Save();

            s.SetBookName(@"..\..\..\Saves\BooksTest\US9p2.json"); //Load f2

            rs.SetNewBook(s.Book, s.History);

            Assert.AreEqual("AAA", rs.Paragraph);

            s.Save();

            s.SetBookName(@"..\..\..\Saves\BooksTest\US9p1.json"); //Reload f1

            rs.SetNewBook(s.Book, s.History);

            Assert.AreEqual("P2", rs.Paragraph);

            File.Delete(@"..\..\..\Saves\HistoriesTest\US9p1.json");
            File.Delete(@"..\..\..\Saves\HistoriesTest\US9p2.json");
        }

        private IServices createServices(string appSave)
        {
            string resource = @"..\..\..\Saves\";
            string historiesSaves = Path.Combine(resource, @"HistoriesTest\");
            string applicationSave = Path.Combine(resource, appSave);

            return new Services(applicationSave,
                new ReadBook(),
                new ReadHistory(historiesSaves),
                new WriteHistory(historiesSaves));
        }
    }
}
