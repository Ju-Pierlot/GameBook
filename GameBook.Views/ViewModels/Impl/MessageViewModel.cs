using GameBook.Models.ReadingSession;

namespace GameBook.Views.ViewModels.Impl
{
    public class MessageViewModel : ObservableViewModel, IMessageViewModel
    {
        private IReadingSession _readingSession;

        public MessageViewModel(IReadingSession readingSession)
        {
            _readingSession = readingSession;
            _readingSession.CurrentParagraphChanged += (o, e) => Update();
            Color = "Transparente";
        }
        public string Message { get; private set; }

        public string Color { get; private set; }

        private void Update()
        {
            CreateMessage();
            RaisePropertiesChanged(nameof(Message), nameof(Color));
        }

        private void CreateMessage()
        {
            Message = "";
            Color = "#fddfca";
            if (_readingSession.AlreadyRead)
            {
                Message += $"Vous avez déjà lu le paragraphe {_readingSession.Id + 1}.";
                if (!_readingSession.IsFinish)
                {
                    Message += $" Vous êtes ensuite aller au paragraphe {_readingSession.IdNextCurrent + 1}.";
                }
            }
            else Message += $"Vous quittez le paragraphe {_readingSession.PrecedingId + 1} pour aller au paragraphe {_readingSession.Id + 1}.";

            if (_readingSession.IsFinish) Message += " Vous avez atteint la fin du livre.";
        }
    }
}
