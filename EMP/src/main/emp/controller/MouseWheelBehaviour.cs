using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EMP.main.emp.controller
{
    /**
     * This class controls the behaviour of a mouse wheel over a slider.
     */
    public static class MouseWheelBehavior
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value",
                typeof(double),
                typeof(MouseWheelBehavior),
                new UIPropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty SliderProperty =
            DependencyProperty.RegisterAttached(
                "Slider",
                typeof(Slider),
                typeof(MouseWheelBehavior));

        public static double GetValue(Slider slider)
        {
            return (double) slider.GetValue(ValueProperty);
        }

        public static void SetValue(Slider slider, double value)
        {
            slider.SetValue(ValueProperty, value);
        }

        public static Slider GetSlider(UIElement parentElement)
        {
            return (Slider) parentElement.GetValue(SliderProperty);
        }

        public static void SetSlider(UIElement parentElement, Slider value)
        {
            parentElement.SetValue(SliderProperty, value);
        }


        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = d as Slider;
            slider.Loaded += (ss, ee) =>
            {
                var window = Window.GetWindow(slider);
                if (window != null)
                {
                    SetSlider(window, slider);
                    window.PreviewMouseWheel += Window_PreviewMouseWheel;
                }
            };
            slider.Unloaded += (ss, ee) =>
            {
                var window = Window.GetWindow(slider);
                if (window != null)
                {
                    SetSlider(window, null);
                    window.PreviewMouseWheel -= Window_PreviewMouseWheel;
                }
            };
        }

        private static void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var window = sender as Window;
            var slider = GetSlider(window);
            var value = GetValue(slider);
            if (slider != null && value != 0)
                slider.Value += slider.SmallChange * e.Delta / value;
        }

        public static DependencyProperty getSliderProperty()
        {
            return SliderProperty;
        }
    }
}