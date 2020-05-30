using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCollectionViewTemplateSelect
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<int> PageIndice { get; set; }
        public int DisplayWidth { get; set; }
        public int DisplayHeight { get; set; }

        public List<Person> People { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.PageIndice = new List<int> { 0, 1 };

            People = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                People.Add(new Person
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}"
                });
            }

            this.BindingContext = this;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            DisplayWidth = (int)width;
            DisplayHeight = (int)height;
        }
    }

    public class CarouselDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstPageTemplate { get; set; }
        public DataTemplate SecondPageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //テンプレートを切り替える条件を指定
            return ((int)item) == 0 ? FirstPageTemplate : SecondPageTemplate;
        }
    }
}
