using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roslinkiXD.ViewModel
{
    using Model;
    using BaseClass;
    using DAL;

    class SecondViewModel
    {
        private Model model = new Model();
        public TabListaViewModel TabListaVM { get; set; }
        public TabDodajRoslinyViewModel TabDodajRoslinyVM { get; set; }
        public TabMojeRoslinyViewModel TabMojeRoslinyVM { get; set; }

        public SecondViewModel()
        {
            TabListaVM = new TabListaViewModel(model);
            TabDodajRoslinyVM = new TabDodajRoslinyViewModel(model);
            TabMojeRoslinyVM = new TabMojeRoslinyViewModel(model);
        }

    }
}
