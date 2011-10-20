using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Strokes.Core;
using System.Linq;

namespace Strokes.GUI.VsAdornments
{
    ///<summary>
    /// AchievementAdornments places red boxes behind all the "A"s in the editor window.
    ///</summary>
    public class AchievementAdornments
    {
        private readonly IAdornmentLayer layer;
        private readonly IAdornmentLayer descriptionLayer;
        private readonly IWpfTextView view;
        private readonly Brush brush;
        private readonly Pen pen;

        private AchievementCodeOrigin _codeOrigin;
        private UIElement achievementUiElement;
        private bool adornmentVisible = false;

        public AchievementAdornments(IWpfTextView view)
        {
            this.view = view;
            this.layer = view.GetAdornmentLayer("AchievementAdornments");
            this.descriptionLayer = view.GetAdornmentLayer("AchievementAdornmentsDescription");

            view.LayoutChanged += OnLayoutChanged;

            Brush brush = new SolidColorBrush(Color.FromArgb(0x20, 0x00, 0x00, 0xff));
            brush.Freeze();

            Brush penBrush = new SolidColorBrush(Colors.Red);
            penBrush.Freeze();

            Pen pen = new Pen(penBrush, 0.5);
            pen.Freeze();

            this.brush = brush;
            this.pen = pen;

            AchievementContext.AchievementClicked += (sender, args) =>
                                                         {
                                                             Reset();

                                                             var filePath = GetFilePath(view);
                                                             if (args.AchievementDescriptor.CodeOrigin.FileName != filePath)
                                                                 return;

                                                             _codeOrigin = args.AchievementDescriptor.CodeOrigin;
                                                             achievementUiElement = (UIElement)args.UIElement;

                                                             CreateAdornment();
                                                         };
        }

        public static string GetFilePath(IWpfTextView wpfTextView)
        {
            ITextDocument document;
            var properties = wpfTextView.TextDataModel.DocumentBuffer.Properties;

            if (!properties.TryGetProperty(typeof(ITextDocument), out document))
                return string.Empty;

            if ((document == null) || (document.TextBuffer == null))
                return string.Empty;

            return document.FilePath;
        }

        private void Reset()
        {
            _codeOrigin = null;
            achievementUiElement = null;
            adornmentVisible = false;            
            layer.RemoveAllAdornments();
            descriptionLayer.RemoveAllAdornments();
        }

        private void CreateAdornment()
        {
            var lines = view.VisualSnapshot.Lines;

            if (_codeOrigin == null)
                return;

            var startLine = lines.FirstOrDefault(a => a.LineNumber == _codeOrigin.From.Line - 1);
            var endLine = lines.FirstOrDefault(a => a.LineNumber == _codeOrigin.To.Line - 1);

            if (startLine == null || endLine == null)
                return;

            var startPosition = startLine.Start + _codeOrigin.From.Column - 1;
            var endPosition = endLine.Start + _codeOrigin.To.Column - 1;

            var span = new SnapshotSpan(view.TextSnapshot, Span.FromBounds(startPosition, endPosition));

            try
            {
                layer.TextView.ViewScroller.EnsureSpanVisible(span, EnsureSpanVisibleOptions.AlwaysCenter);
            } 
            catch (InvalidOperationException)
            {
                // Intentionally ignored. 
            }

            var g = view.TextViewLines.GetMarkerGeometry(span);
            if (g != null)
            {
                var drawing = new GeometryDrawing(brush, pen, g);
                drawing.Freeze();

                var drawingImage = new DrawingImage(drawing);
                drawingImage.Freeze();

                var image = new Image
                {
                    Source = drawingImage
                };

                // Align the image with the top of the bounds of the text geometry.
                Canvas.SetLeft(image, g.Bounds.Left);
                Canvas.SetTop(image, g.Bounds.Top);

                Canvas.SetLeft(achievementUiElement, g.Bounds.Right + 50);
                Canvas.SetTop(achievementUiElement, g.Bounds.Top);

                achievementUiElement.MouseDown += (sender, args) => Reset();

                adornmentVisible = true;
                
                try
                {

                    layer.AddAdornment(AdornmentPositioningBehavior.TextRelative,
                        span, null, image, (tag, element) => adornmentVisible = false);

                    descriptionLayer.AddAdornment(AdornmentPositioningBehavior.TextRelative,
                        span, null, achievementUiElement, null);
                }
                catch (ArgumentException)
                {
                    // Intentionally ignored. 
                }
            }
        }

        /// <summary>
        /// On layout change add the adornment to any reformatted lines
        /// </summary>
        private void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            // Save some time - if there isn't an active CodeOrigin, then just bail.
            if (_codeOrigin == null)
                return;

            if (e.OldSnapshot != e.NewSnapshot)
            {
                Reset();
            }
            else if (!adornmentVisible)
            {
                layer.RemoveAllAdornments();
                descriptionLayer.RemoveAllAdornments();

                CreateAdornment();
            }
        }
    }
}
