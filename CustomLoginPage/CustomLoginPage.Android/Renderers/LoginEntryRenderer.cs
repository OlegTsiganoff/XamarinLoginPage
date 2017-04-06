using CustomLoginPage.Controls;
using CustomLoginPage.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryRenderer))]
namespace CustomLoginPage.Droid.Renderers
{
    public class LoginEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            
            Control.SetPadding(Control.PaddingLeft + 20, Control.PaddingTop , Control.PaddingRight + 5, Control.PaddingBottom);
            Control.SetCompoundDrawables(null, null, null, null);
        }
    }
}