using System;
using GameBook.Models.ReadingSession;

namespace GameBook.Views.ViewModels.Impl
{
    public class ParagraphInfosViewModel : ObservableViewModel, IParagraphInfosViewModel
    {
        private IReadingSession _readingSession;
        private DynamicText _dynamicText;

        public ParagraphInfosViewModel(IReadingSession readingSession) : this(readingSession, null)
        {
        }
        public ParagraphInfosViewModel(IReadingSession readingSession, DynamicText dynamicText)
        {
            _readingSession = readingSession;
            _dynamicText = dynamicText;
            if (_dynamicText != null)
            {
                _dynamicText.EventText += Dynamic;
                _dynamicText.Start(_readingSession.Paragraph);
            }
            else
            {
                Label = _readingSession.Paragraph;
            }
            _readingSession.CurrentParagraphChanged += (o, e) => Update();
            PrecedingColorStart = "#fff";
            PrecedingColorEnd = "#fff";
            ColorStart = _readingSession.ColorStart;
            ColorEnd = _readingSession.ColorEnd;
        }
        public string BookTitle => _readingSession.Title;

        public string Number => $"Paragraphe n°{_readingSession.Id + 1}";

        public string Label { get; private set; }

        public string ColorStart { get; private set; }

        public string ColorEnd { get; private set; }

        public string PrecedingColorStart { get; private set; }

        public string PrecedingColorEnd { get; private set; }

        private void Update()
        {
            if (_dynamicText == null) Label = _readingSession.Paragraph;
            else _dynamicText.Start(_readingSession.Paragraph);

            PrecedingColorStart = ColorStart;
            PrecedingColorEnd = ColorEnd;

            ColorStart = _readingSession.ColorStart;
            ColorEnd = _readingSession.ColorEnd;

            RaisePropertiesChanged(nameof(BookTitle), nameof(Number), nameof(Label), nameof(ColorStart), nameof(ColorEnd), nameof(PrecedingColorStart), nameof(PrecedingColorEnd));
        }

        private void Dynamic(string text, EventHandler args)
        {
            Label = text;
            RaisePropertyChanged(nameof(Label));
        }
    }
}
