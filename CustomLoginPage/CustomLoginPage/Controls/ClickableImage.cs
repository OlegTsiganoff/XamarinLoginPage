using System.Windows.Input;
using Xamarin.Forms;

namespace CustomLoginPage.Controls
{
    public class ClickableImage : Image
    {
        public static readonly BindableProperty CommandProperty
            = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ClickableImage), default(ICommand));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty
            = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ClickableImage));

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty ClickedImageProperty
            = BindableProperty.Create(nameof(ClickedImage), typeof(string), typeof(ClickableImage), "");

        public string ClickedImage
        {
            get { return (string)GetValue(ClickedImageProperty); }
            set { SetValue(ClickedImageProperty, value); }
        }

        public static readonly BindableProperty ToggledImageProperty
            = BindableProperty.Create(nameof(ToggledImage), typeof(string), typeof(ClickableImage), "");

        public string ToggledImage
        {
            get
            {
                return (string)GetValue(ToggledImageProperty);
            }
            set
            {
                SetValue(ToggledImageProperty, value);
            }

        }

        public bool Toggled { get; set; }

        ImageSource _normalImage, _activeImage;
        ImageSource _untoggledImage, _toggledImage;

        public ClickableImage()
        {
            var gesture = new TapGestureRecognizer();
            gesture.Tapped += (sender, e) =>
            {
                SetActive();

                if (Command != null && Command.CanExecute(BindingContext))
                {
                    Command.Execute(BindingContext);
                }

                SetInactive();
                Toggle();
            };
            GestureRecognizers.Add(gesture);
        }

        void SetActive()
        {
            if (!string.IsNullOrEmpty(ClickedImage))
            {
                _normalImage = Source;
                if (_activeImage == null)
                {
                    _activeImage = ImageSource.FromFile(ClickedImage);
                }
                Source = _activeImage;
            }
            else
            {
                Opacity = 0.6;
                this.FadeTo(1, 300);
            }
        }

        void SetInactive()
        {
            if (!string.IsNullOrEmpty(ClickedImage))
            {
                this.FadeTo(0.5, 100);
                Source = _normalImage;
                this.FadeTo(1, 100);
            }
        }

        void Toggle()
        {
            if (!string.IsNullOrEmpty(ToggledImage))
            {
                if (!Toggled)
                {
                    if (_untoggledImage == null && _toggledImage == null)
                    {
                        _untoggledImage = Source;
                        _toggledImage = ImageSource.FromFile(ToggledImage);
                    }
                    Source = _toggledImage;
                }
                else
                {
                    Source = _untoggledImage;
                }
                Toggled = !Toggled;
            }
        }
    }
}
