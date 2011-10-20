using System;

namespace Strokes.Core.Service
{
    public class HighlightCodeLocationEventArgs : EventArgs
    {
        public CodeAnchor CodeAnchor
        {
            get;
            set;
        }
    }
}
