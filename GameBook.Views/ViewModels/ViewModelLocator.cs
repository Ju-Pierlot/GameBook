using System.ComponentModel;
using System.IO;
using System.Windows;
using GameBook.Models.Answer;
using GameBook.Models.Book;
using GameBook.Models.History;
using GameBook.Models.Io;
using GameBook.Models.Paragraph;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels.Impl;


namespace GameBook.Views.ViewModels
{
    public class ViewModelLocator
    {
        private readonly DependencyObject _dependenciesProp;

        private IReadingSession _readingSession;
        private IServices _services;

        public ViewModelLocator() : this(new DependencyObject())
        {}
        public ViewModelLocator(DependencyObject dep = null)
        {
            _dependenciesProp = dep ?? new DependencyObject();

            if (DesignerProperties.GetIsInDesignMode(_dependenciesProp))
            {
                WindowVM = new Stubs.WindowViewModel();
                BackVM = new Stubs.BackViewModel();
                ParagraphsBoxVM = new Stubs.ParagraphsBoxViewModel();
                MessageVM = new Stubs.MessageViewModel();
                ParagraphAnswersVM = new Stubs.ParagraphAnswersViewModel();
                ParagraphInfosVM = new Stubs.ParagraphInfosViewModel();
            }
            else
            {
                string resource = @"..\..\..\Saves\";
                string historiesSaves = Path.Combine(resource, @"Histories\");
                string applicationSave = Path.Combine(resource, @"save.txt");
                _services = new Services(applicationSave, new ReadBook(), new ReadHistory(historiesSaves), new WriteHistory(historiesSaves));
                _services.Start();

                if (_services.Book == null) _readingSession = CreateReadingSession();
                else _readingSession = new ReadingSession(_services.Book, _services.History);

                WindowVM = new Impl.WindowViewModel(_readingSession, new FileResourceChooser(), _services);
                BackVM = new Impl.BackViewModel(_readingSession);
                ParagraphsBoxVM = new Impl.ParagraphsBoxViewModel(_readingSession);
                MessageVM = new Impl.MessageViewModel(_readingSession);
                ParagraphAnswersVM = new Impl.ParagraphAnswersViewModel(_readingSession);
                ParagraphInfosVM = new Impl.ParagraphInfosViewModel(_readingSession, new DynamicText());
            }
        }

        public IWindowViewModel WindowVM { get; }
        public IBackViewModel BackVM { get; }
        public IParagraphsBoxViewModel ParagraphsBoxVM { get; }
        public IMessageViewModel MessageVM { get; }
        public IParagraphAnswersViewModel ParagraphAnswersVM { get; }
        public IParagraphInfosViewModel ParagraphInfosVM { get; }
        private IReadingSession CreateReadingSession()
        {
            IParagraph p1 = new Paragraph(0,
                "Charger un livre :)",
                "#ffffff",
                "#f1a748");
            p1.AddAnswer(new Answer("Un réponse", 0));

            IBook book = new Book("Livre par defaut");
            book.AddParagraphs(p1);

            return new ReadingSession(book, new History());
        }
    }
}
