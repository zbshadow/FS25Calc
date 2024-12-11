using FS25Calc.DataLayer.Models;

namespace FS25Calc.Web.Components.Modules
{
    public partial class CalculatorHost
    {
        //Base line yeild
        //Crop: wheat
        //17800 per hectacre
        //1 hectacre = 2.471 acres

        bool Lime = false;
        bool Fertilized = false;
        bool FertilizedSecond = false;
        bool Rolled = false;
        bool Plowed = false;
        bool Mulched = false;
        bool Weeded = false;


        public List<Crop> Crops = new List<Crop>();
        private float _lime
        {
            get
            {
                return (Lime) ? (float)(_crop.BaseYield * 0.15) : 0; // goes down every harvest by 5%
            }
        }
        private float _fertilized
        {
            get
            {
                return (Fertilized) ? (float)(_crop.BaseYield * 0.225) : 0;
            }
        }
        private float _fertilizedSecond
        {
            get
            {
                return (FertilizedSecond) ? (float)(_crop.BaseYield * 0.225) : 0;
            }
        }
        private float _rolled
        {
            get
            {
                return (Rolled) ? (float)(_crop.BaseYield * 0.025) : 0;
            }
        }
        private float _plowed
        {
            get
            {
                return (Plowed) ? (float)(_crop.BaseYield * 0.15) : 0;
            }
        }

        private float _mulched
        {
            get
            {
                return (Mulched) ? (float)(_crop.BaseYield * 0.025) : 0;
            }
        }

        private float _weeded
        {
            get
            {
                return (Weeded) ? (float)(_crop.BaseYield * 0.20) : 0;
            }
        }

        private float _Yield 
        { 
            get
            {
                return (_crop.BaseYield + _lime + _fertilized + _fertilizedSecond + _rolled + _plowed + _mulched + _weeded) * FieldSize;
            }
        }

        public float FieldSize { get; set; } = 0;

        Crop _crop;

        protected override Task OnInitializedAsync()
        {
            Crops.Add(new Crop() { Name = "Wheat", BaseYield = 17800 });
            Crops.Add(new Crop() { Name = "Corn", BaseYield = 19250 });
            Crops.Add(new Crop() { Name = "Soy", BaseYield = 9421 });
            Crops.Add(new Crop() { Name = "Potatoes", BaseYield = 85487 });
            Crops.Add(new Crop() { Name = "Grass", BaseYield = 91532 });
            Crops.Add(new Crop() { Name = "Barley", BaseYield = 20095 });

            return base.OnInitializedAsync();
        }


        Func<Crop, string> converter = p => p?.Name;
    }
}
