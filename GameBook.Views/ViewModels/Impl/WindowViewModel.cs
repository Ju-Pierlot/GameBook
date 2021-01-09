using System.Windows.Input;
using GameBook.Models.Io;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels.Commands;

namespace GameBook.Views.ViewModels.Impl
{
    public class WindowViewModel : IWindowViewModel
    {
        private IReadingSession _readingSession;
        private IChooseResource _chooseResource;
        private IServices _services;

        public WindowViewModel(IReadingSession readingSession, IChooseResource chooseResource, IServices services)
        {
            _readingSession = readingSession;
            _chooseResource = chooseResource;
            _services = services;
            LoadFile = new BasicRelayCommand(() => Load());
            Exit = new BasicRelayCommand(() => _services.Save());
            //Si jamais on veut choisir un livre au premier demarrage.
            //if(_services.Book == null) ChooseFile();
        }

        public ICommand Exit { get; }

        public ICommand LoadFile { get; }

        private void Load()
        {
            _services.Save();
            ChooseFile();
        }

        private void ChooseFile()
        {
            string path = _chooseResource.ResourceIdentifier;
            if (_services.SetBookName(path))
            {
                _readingSession.SetNewBook(_services.Book, _services.History);
            }
        }
    }
}
