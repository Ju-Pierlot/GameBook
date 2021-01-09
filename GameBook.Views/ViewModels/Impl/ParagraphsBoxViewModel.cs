using System;
using System.Collections.ObjectModel;
using GameBook.Models.ReadingSession;

namespace GameBook.Views.ViewModels.Impl
{
    public class ParagraphsBoxViewModel : ObservableViewModel, IParagraphsBoxViewModel
    {
        private IReadingSession _readingSession;
        private string _top = "Selectionner un paragraphe...";

        public ParagraphsBoxViewModel(IReadingSession readingSession)
        {
            _readingSession = readingSession;
            ParagraphVisited = new ObservableCollection<string>();
            _readingSession.CurrentParagraphChanged += (o, e) => Update();
            Update();
        }

        public ObservableCollection<string> ParagraphVisited { get; }

        public string ParagraphSelected
        {
            get => (ParagraphVisited.Count > 0) ? ParagraphVisited[0] : _top;
            set
            {
                int i = GetParagraphNumber(value);
                if(i != -1) _readingSession.GoTo(i);
            }
        }

        private void Update()
        {
            ParagraphVisited.Clear();
            ParagraphVisited.Add(_top);
            foreach (var item in _readingSession.ParagraphsRead)
            {
                ParagraphVisited.Add(item);
            }
            RaisePropertiesChanged(nameof(ParagraphVisited));
        }

        private int GetParagraphNumber(string text)
        {
            if (!String.IsNullOrEmpty(text) && text[0] == 'P')
            {
                string[] parts = text.Split(' ');
                try
                {
                    return Convert.ToInt32(parts[1]) - 1;
                }
                catch{ }
            }
            return -1;
        }
    }
}