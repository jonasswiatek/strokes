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
    /// AchievementAdornments places red boxes behind all the "A"s in the editor window.
    ///</summary>
    public class AchievementAdornments
    {
        private readonly IAdornmentLayer layer;
        private readonly IAdornmentLayer descriptionLayer;
        private readonly IWpfTextView view;
        private readonly Brush brush;
        private readonly Pen pen;

        private AchievementCodeLocation codeLocation;
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

            AchievementContext.AchievementClicked += AchievementContext_AchievementClicked;
        }

        public static string GetFilePath(IWpfTextView wpfTextView)
        {
            ITextDocument document;
            var properties = wpfTextView.TextDataModel.DocumentBuffer.Properties;

            if ((wpfTextView == null) || (!properties.TryGetProperty(typeof(ITextDocument), out document)))
                return string.Empty;

            if ((document == null) || (document.TextBuffer == null))
                return string.Empty;

            return document.FilePath;
        }

        private void Reset()
        {
            codeLocation = null;
            achievementUiElement = null;
            adornmentVisible = false;            
            layer.RemoveAllAdornments();
            descriptionLayer.RemoveAllAdornments();
        }

        private void AchievementContext_AchievementClicked(object sender, AchievementClickedEventArgs args)
        {
            Reset();

            var filePath = GetFilePath(view);
            if (args.AchievementDescriptor.CodeLocation.FileName == filePath)
            {
                codeLocation = args.AchievementDescriptor.CodeLocation;
                achievementUiElement = (UIElement)args.UIElement;

                CreateAdornment();
            }
        }

        private void CreateAdornment()
        {
            var lines = view.VisualSnapshot.Lines;

            if (codeLocation == null)
                return;

            var startLine = lines.FirstOrDefault(a => a.LineNumber == codeLocation.From.Line - 1);
            var endLine = lines.FirstOrDefault(a => a.LineNumber == codeLocation.To.Line - 1);

            if (startLine == null || endLine == null)
                return;

            var startPosition = startLine.Start + codeLocation.From.Column - 1;
            var endPosition = endLine.Start + codeLocation.To.Column - 1;

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
            // Save some time - if there isn't an active codeLocation, then just bail.
            if (codeLocation == null)
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
