using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace EMP.main.emp.view.empres
{
    public partial class SliderEMP : Slider
    {
        private static bool dragStarted, mouseOverVol;
        private MediaPlayer mediaPlayer;
        private double sliderVal;

        public SliderEMP()
        {
            InitializeComponent();

            SliderVolume.MouseEnter += mouseOverEnterVol;
            SliderVolume.MouseLeave += mouseOverLeaveVol;
            SliderVolume.ValueChanged += ActionListenerSliderValueChanged;
        }

        private void ActionListenerSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sliderVal = mediaPlayer.Volume * 100;
            if (mouseOverVol)
            {
                if (!dragStarted)
                    mediaPlayer.Volume = SliderVolume.Value / 100;
            }
            else
            {
                SliderVolume.Value = sliderVal;
            }
        }

        private void ActionListenerSliderDragStarted(object sender, DragStartedEventArgs e)
        {
            if (mouseOverVol)
                dragStarted = true;
        }

        private void ActionListenerSliderDragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (mouseOverVol)
            {
                mediaPlayer.Volume = SliderVolume.Value / 100;
                dragStarted = false;
            }
        }

        private void mouseOverEnterVol(object sender, EventArgs e)
        {
            mouseOverVol = true;
        }

        private void mouseOverLeaveVol(object sender, EventArgs e)
        {
            mouseOverVol = false;
        }

        public void setMediaPlayer(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }
    }
}