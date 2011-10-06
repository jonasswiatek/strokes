using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Strokes.GUI.VsAdornments
{
    #region Adornment Factory
    /// <summary>
    /// Establishes an <see cref="IAdornmentLayer"/> to place the adornment on and exports the <see cref="IWpfTextViewCreationListener"/>
    /// that instantiates the adornment on the event of a <see cref="IWpfTextView"/>'s creation
    /// </summary>
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class AchievementAdornmentsFactory : IWpfTextViewCreationListener
    {
        /// <summary>
        /// Test highlight adornment layer
        /// </summary>
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("AchievementAdornments")]
        [Order(After = PredefinedAdornmentLayers.Selection, Before = PredefinedAdornmentLayers.Text)]
        [TextViewRole(PredefinedTextViewRoles.Document)]
        public AdornmentLayerDefinition editorAdornmentLayer = null;

        /// <summary>
        /// Test highlight adornment layer
        /// </summary>
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("AchievementAdornmentsDescription")]
        [Order(After = PredefinedAdornmentLayers.Caret)]
        [TextViewRole(PredefinedTextViewRoles.Document)]
        public AdornmentLayerDefinition editorAdornmentDescriptionLayer = null;

        /// <summary>
        /// Instantiates a AchievementAdornments manager when a textView is created.
        /// </summary>
        /// <param name="textView">The <see cref="IWpfTextView"/> upon which the adornment should be placed</param>
        public void TextViewCreated(IWpfTextView textView)
        {
            new AchievementAdornments(textView);
        }
    }
    #endregion //Adornment Factory
}