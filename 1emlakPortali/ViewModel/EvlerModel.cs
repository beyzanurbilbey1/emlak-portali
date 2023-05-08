using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1emlakPortali.ViewModel
{
    public class EvlerModel

    {
        public string evId { get; set; }
        public int evKat { get; set; }
        public int evFiyat { get; set; }
        public string evAdres { get; set; }
        public string evSatilikKiralik { get; set; }
        public string evEsya { get; set; }
        public int evOdaSayisi { get; set; }
        public string evGorsel { get; set; }
        public string evKatId { get; set; }
        public int evKodu { get; set; }
        public KategoriModel evKategoriBilgi { get; set; }
    }
}