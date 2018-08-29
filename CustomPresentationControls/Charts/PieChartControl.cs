using CustomPresentationControls.Utilities;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CustomPresentationControls.Charts
{
    [TemplatePart(Name = "Figure", Type = typeof(Canvas))]
    [TemplatePart(Name = "Legend", Type = typeof(ItemsControl))]
    public class PieChartControl : Control
    {
        public double FigureSize
        {
            get { return (double)GetValue(FigureSizeProperty); }
            set
            {
                SetValue(FigureSizeProperty, value);
                UpdateChart();
            }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                UpdateChart();
            }
        }
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        public double LegendWidth
        {
            get { return (double)GetValue(LegendWidthProperty); }
            set { SetValue(LegendWidthProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(PieChartControl), new PropertyMetadata(OnItemsSourcePropertyChanged));
        public static readonly DependencyProperty FigureSizeProperty = DependencyProperty.Register("FigureSize", typeof(double), typeof(PieChartControl), new PropertyMetadata(OnFigureSizePropertyChanged));
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(PieChartControl), new PropertyMetadata(Orientation.Vertical));
        public static readonly DependencyProperty LegendWidthProperty = DependencyProperty.Register("LegendWidth", typeof(double), typeof(PieChartControl), new PropertyMetadata(0.0));
        private Canvas Figure { get; set; }
        static PieChartControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PieChartControl), new FrameworkPropertyMetadata(typeof(PieChartControl)));
        }
        public override void OnApplyTemplate()
        {
            Figure = GetTemplateChild("Figure") as Canvas;
            UpdateChart();
        }
        private void UpdateChart()
        {
            ObservableCollection<DataBin> stuff = ItemsSource as ObservableCollection<DataBin>;
            if (ItemsSource is ObservableCollection<PieSegment> data && Figure != null)
            {
                if (FigureSize == 0)
                {
                    FigureSize = 100;
                }
                Figure.Width = FigureSize;
                Figure.Height = FigureSize;
                double pieTotal = data.Sum(p => p.Value);
                double consumedPie = 0;
                Figure.Children.Clear();
                Path path;
                double radius = FigureSize / 2;
                if (data.Count == 1)
                {
                    EllipseGeometry geometry = new EllipseGeometry(new Point(radius, radius), radius, radius);
                    path = new Path
                    {
                        Data = geometry,
                        Stroke = new SolidColorBrush(Colors.White),
                        StrokeThickness = 2,
                        Fill = data[0].Color
                    };
                    Figure.Children.Add(path);
                }
                else
                {
                    int i = 0;
                    foreach (PieSegment dataPoint in data)
                    {
                        PathGeometry geometry = new PathGeometry();
                        double startAngle = consumedPie;
                        double angle = 2 * Math.PI * dataPoint.Value / pieTotal;
                        double endAngle = consumedPie + angle;
                        Point startPoint = new Point(radius * (1 - Math.Sin(startAngle)), radius * (1 - Math.Cos(startAngle)));
                        Point endPoint = new Point(radius * (1 - Math.Sin(endAngle)), radius * (1 - Math.Cos(endAngle)));
                        LineSegment start = new LineSegment(startPoint, true);
                        ArcSegment arc = new ArcSegment(endPoint, new Size(radius, radius), angle, angle > Math.PI, SweepDirection.Counterclockwise, true);
                        LineSegment end = new LineSegment(new Point(radius, radius), true);
                        PathFigure figure = new PathFigure(new Point(radius, radius), new PathSegment[] { start, arc, end }, false);
                        geometry.Figures.Add(figure);
                        path = new Path
                        {
                            Data = geometry,
                            Stroke = new SolidColorBrush(Colors.White),
                            StrokeThickness = 2,
                            Fill = dataPoint.Color
                        };
                        Figure.Children.Add(path);
                        consumedPie = endAngle;
                        i++;
                    }
                }
            }
        }
        private static void OnFigureSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PieChartControl control)
            {
                control.UpdateChart();
            }
        }
        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PieChartControl control)
            {
                control.UpdateChart();
            }
        }
        private void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            if (oldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= new NotifyCollectionChangedEventHandler(NotifyItemsSourceChanged);
            }
            if (newValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(NotifyItemsSourceChanged);
            }
            UpdateChart();
        }
        private void NotifyItemsSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateChart();
        }
    }
    public class PieSegment : ObservableObject
    {
        private string _name;
        private double _value;
        private SolidColorBrush _color;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }
        public double Value
        {
            get { return _value; }
            set { OnPropertyChanged(ref _value, value); }
        }
        public SolidColorBrush Color
        {
            get { return _color; }
            set { OnPropertyChanged(ref _color, value); }
        }
    }
    //internal class DataPointCollectionToPieSegmentCollectionConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value is ObservableCollection<DataBin> data)
    //        {
    //            return data.Select((d, i) => new PieSegment
    //            {
    //                Name = d.Name,
    //                Value = d.Value,
    //                Color = ChartColors.Colors[i]
    //            });
    //        }
    //        return null;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
