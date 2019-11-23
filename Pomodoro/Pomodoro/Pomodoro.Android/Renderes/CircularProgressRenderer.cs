using Android.Content;
using com.refractored.monodroidtoolkit;
using Pomodoro.Control;
using Pomodoro;
using Pomodoro.Droid.Renderes;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircularProgress), typeof(CircularProgressRenderer))]
namespace Pomodoro.Droid.Renderes
{
    public class CircularProgressRenderer : ViewRenderer<CircularProgress, HoloCircularProgressBar>
    {
        public CircularProgressRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<CircularProgress> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
            {
                return;
            }

            var progress = new HoloCircularProgressBar(Context);
            progress.Max = Element.Max;
            progress.Indeterminate = Element.Indeterminate;
            progress.ProgressColor = Element.ProgressColor.ToAndroid();
            progress.ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid();
            progress.IndeterminateInterval = Element.IndeterminateSpeed;

            SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null || Element == null)
            {
                return;
            }

            if (e.PropertyName == CircularProgress.MaxProperty.PropertyName)
            {
                Control.Max = Element.Max;
            }
            else if (e.PropertyName == CircularProgress.ProgressProperty.PropertyName)
            {
                Control.Progress = Element.Progress;
            }
            else if (e.PropertyName == CircularProgress.IndeterminateProperty.PropertyName)
            {
                Control.Indeterminate = Element.Indeterminate;
            }
            else if (e.PropertyName == CircularProgress.ProgressBackgroundColorProperty.PropertyName)
            {
                Control.ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == CircularProgress.ProgressColorProperty.PropertyName)
            {
                Control.ProgressColor = Element.ProgressColor.ToAndroid();
            }
            else if (e.PropertyName == CircularProgress.IndeterminateSpeedProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.IndeterminateSpeed;
            }
        }

    }
}