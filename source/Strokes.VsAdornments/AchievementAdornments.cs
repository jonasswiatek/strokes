using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Strokes.Core;
using System.Linq;

namespace Strokes.VsAdornments
{
    ///<summary>
    ///AchievementAdornments places red boxes behind all the "A"s in the editor window
    ///</summary>
    public class AchievementAdornments
    {
        readonly IAdornmentLayer _layer, _descriptionLayer;
        readonly IWpfTextView _view;
        readonly Brush _brush;
        readonly Pen _pen;

        public AchievementAdornments(IWpfTextView view)
        {
            _view = view;
            _layer = view.GetAdornmentLayer("AchievementAdornments");
            _descriptionLayer = view.GetAdornmentLayer("AchievementAdornmentsDescription");

            //Listen to any event that changes the layout (text changes, scrolling, etc)
            _view.LayoutChanged += OnLayoutChanged;

            //Create the pen and brush to color the box behind the a's
            Brush brush = new SolidColorBrush(Color.FromArgb(0x20, 0x00, 0x00, 0xff));
            brush.Freeze();
            Brush penBrush = new SolidColorBrush(Colors.Red);
            penBrush.Freeze();
            Pen pen = new Pen(penBrush, 0.5);
            pen.Freeze();

            _brush = brush;
            _pen = pen;

            //Subscribe to Strokes eventing
            AchievementContext.AchievementClicked += AchievementContext_AchievementClicked;
        }

        private AchievementCodeLocation _codeLocation;
        private UIElement _achievementUiElement;
        private bool _adornmentVisible = false;

        private void Reset()
        {
            _codeLocation = null;
            _achievementUiElement = null;
            _adornmentVisible = false;
            _layer.RemoveAllAdornments();
            _descriptionLayer.RemoveAllAdornments();
        }

        void AchievementContext_AchievementClicked(object sender, AchievementClickedEventArgs args)
        {
            Reset();
            
            var filePath = GetFilePath(_view);
            if (args.AchievementDescriptor.CodeLocation.FileName != filePath)
                return;

            _codeLocation = args.AchievementDescriptor.CodeLocation;
            _achievementUiElement = (UIElement) args.UIElement;

            CreateAdornment();
        }

        void CreateAdornment()
        {
            var lines = _view.VisualSnapshot.Lines;

            if (_codeLocation == null)
                return;

            var startLine = lines.FirstOrDefault(a => a.LineNumber == _codeLocation.From.Line - 1);
            var endLine = lines.FirstOrDefault(a => a.LineNumber == _codeLocation.To.Line - 1);

            if(startLine == null || endLine == null)
            {
                return;
            }

            var startPosition = startLine.Start + _codeLocation.From.Column - 1;
            var endPosition = endLine.Start + _codeLocation.To.Column - 1;

            var span = new SnapshotSpan(_view.TextSnapshot, Span.FromBounds(startPosition, endPosition));
            var g = _view.TextViewLines.GetMarkerGeometry(span);
            if (g != null)
            {
                var drawing = new GeometryDrawing(_brush, _pen, g);
                drawing.Freeze();

                var drawingImage = new DrawingImage(drawing);
                drawingImage.Freeze();

                var image = new Image {Source = drawingImage};

                //Align the image with the top of the bounds of the text geometry
                Canvas.SetLeft(image, g.Bounds.Left);
                Canvas.SetTop(image, g.Bounds.Top);

                Canvas.SetLeft(_achievementUiElement, g.Bounds.Right + 50);
                Canvas.SetTop(_achievementUiElement, g.Bounds.Top);

                _achievementUiElement.MouseDown += (sender, args) => Reset();

                _adornmentVisible = true;
                _layer.AddAdornment(AdornmentPositioningBehavior.TextRelative, span, null, image, (tag, element) => _adornmentVisible = false);
                _descriptionLayer.AddAdornment(AdornmentPositioningBehavior.TextRelative, span, null, _achievementUiElement, null);
            }
        }

        /// <summary>
        /// On layout change add the adornment to any reformatted lines
        /// </summary>
        private void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            if (_codeLocation == null) //Save some time - if there isn't an active codeLocation, then just bail.
                return;

            if(e.OldSnapshot != e.NewSnapshot)
            {
                //Reset
                Reset();
            }
            else if(!_adornmentVisible)
            {
                //A codeLocation is set, but now showing. Remove anything we have on screen, and rebuild.
                _layer.RemoveAllAdornments();
                _descriptionLayer.RemoveAllAdornments();
                CreateAdornment();
            }
        }

        public static string GetFilePath(IWpfTextView wpfTextView)
        {
            ITextDocument document;
            if ((wpfTextView == null) || (!wpfTextView.TextDataModel.DocumentBuffer.Properties.TryGetProperty(typeof(ITextDocument), out document)))
                return String.Empty;

            // If we have no document, just ignore it.
            if ((document == null) || (document.TextBuffer == null))
                return String.Empty;

            return document.FilePath;
        }
    }
}
