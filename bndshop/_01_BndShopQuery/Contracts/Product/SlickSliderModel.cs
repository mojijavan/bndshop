using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BndShopQuery.Contracts.Product
{
    public class SlickSliderModel
    {
        public SlickSliderModel()
        {
            ProductQueryModels = new List<ProductQueryModel>();
            IsShow = true;
        }

        public List<ProductQueryModel> ProductQueryModels;
        public string Title { get; set; }
        public bool IsShow { get; set; }
        public string SubTitle { get; set; }

    }
}
