using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1emlakPortali.ViewModel
{
    public class kayitModel
    {
        public string KayitId { get; set; }
        public string kayitEvId { get; set; }
        public string kayitKulId { get; set; }

        public KullaniciModel kullaniciBilgi { get; set; }
        public EvlerModel evBilgi { get; set; }


    }
}