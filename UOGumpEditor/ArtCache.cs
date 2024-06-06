﻿namespace UOGumpEditor
{
    public class ArtCache(List<ArtEntity> allItems)
    {
        private readonly List<ArtEntity> _allItems = allItems;

        private readonly int _windowSize = UOSettings.Default.DisplayMax;

        private int _currentStartIndex = 0;

        public List<ArtEntity> GetCurrentWindow()
        {
            return _allItems.Skip(_currentStartIndex).Take(_windowSize).ToList();
        }

        public bool CanScrollNext()
        {
            return _currentStartIndex + _windowSize < _allItems.Count;
        }

        public bool CanScrollPrev()
        {
            return _currentStartIndex > 0;
        }

        public void ScrollNext()
        {
            if (CanScrollNext())
            {
                _currentStartIndex += _windowSize;
            }
        }

        public void ScrollPrev()
        {
            if (CanScrollPrev())
            {
                _currentStartIndex -= _windowSize;
            }
        }
    }
}
