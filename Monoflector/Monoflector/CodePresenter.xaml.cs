using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit;

namespace Monoflector
{
    /// <summary>
    /// Interaction logic for CodePresenter.xaml
    /// </summary>
    public partial class CodePresenter : UserControl
    {
        /// <summary>
        /// Gets or sets the text contained in the presenter.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Storage for <see cref="Text"/>.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CodePresenter), new UIPropertyMetadata(null));



        public CodePresenter()
        {
            InitializeComponent();
            _textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Text":
                    _textEditor.Text = (string)e.NewValue;
                    break;
            }
            base.OnPropertyChanged(e);
        }
    }
}
